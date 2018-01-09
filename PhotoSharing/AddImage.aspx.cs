using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace PhotoSharing
{
    public partial class AddImage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True");
        String id;

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = (string)(Session["email"]);
            string name = (string)(Session["name"]);
            id = (string)(Session["id"]);

            if (email != String.Empty)
            {

                ImageProfile.ImageUrl = "~/HandlerImage.ashx?id=" + id;
                profileName.Text = name;
                profileEmail.Text = email;
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }

            string query = "select alb.Name, alb.Id from dbo.Users usr join dbo.Albums alb on (alb.UserId = usr.Id) where usr.Email = '" + email + "'";

            editAlbumText.Items.Clear();
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                editAlbumText.Items.Add(new ListItem(dataReader[0].ToString(), dataReader[1].ToString()));
            }
            con.Close();
        }

        protected void TransferDefault(object sender, EventArgs e)
        {
            Server.Transfer("Default.aspx", true);
        }

        protected void TransferLogIn(object sender, EventArgs e)
        {
            Server.Transfer("LoginPage.aspx", true);
        }

        protected void TransferProfile(object sender, EventArgs e)
        {
            Session["email"] = profileEmail.Text;
            Response.Redirect("Profile.aspx");
        }

        protected void Save(object sender, EventArgs e)
        {
            
            if (editNameText.PostedFile.FileName != "")
            {
                byte[] byteArrayIn;
                byte[] image;
                Stream s = editNameText.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(s);
                byteArrayIn = br.ReadBytes((Int32)s.Length);
                image = byteArrayIn;

                if (editImageDrop.SelectedItem.Text.Equals("Contrast")) {
                    var ms = new MemoryStream(byteArrayIn);
                    Bitmap btm = SetContrast(System.Drawing.Image.FromStream(ms), 200);
                    image = ImageToByte(btm);
                }
                if (editImageDrop.SelectedItem.Text.Equals("Grayscale"))
                {
                    var ms = new MemoryStream(byteArrayIn);
                    Bitmap btm = CopyAsGrayscale(System.Drawing.Image.FromStream(ms));
                    image = ImageToByte(btm);
                }
                if (editImageDrop.SelectedItem.Text.Equals("Negative"))
                {
                    var ms = new MemoryStream(byteArrayIn);
                    Bitmap btm = CopyAsNegative(System.Drawing.Image.FromStream(ms));
                    image = ImageToByte(btm);
                }
                if (editImageDrop.SelectedItem.Text.Equals("Sepia"))
                {
                    var ms = new MemoryStream(byteArrayIn);
                    Bitmap btm = CopyAsSepiaTone(System.Drawing.Image.FromStream(ms));
                    image = ImageToByte(btm);
                }
               

                SqlCommand comm = new SqlCommand();
                comm.Connection = con;

                comm.CommandText = "insert into Photos(Image,UserId,AlbumId,Name,Category,Location,Description, Date) values" +
                    " (@image,@userId,@albumId,@name,@category,@location,@description,SYSDATETIME() )";
                comm.Parameters.AddWithValue("@image", image);
                comm.Parameters.AddWithValue("@userId", Convert.ToInt32(id));
                comm.Parameters.AddWithValue("@albumId", Convert.ToInt32(editAlbumText.SelectedValue));
                comm.Parameters.AddWithValue("@name", editEmailText.Text);
                comm.Parameters.AddWithValue("@category", editCategoryDrop.SelectedItem.Text);
                comm.Parameters.AddWithValue("@location", editLocationText.Text);
                comm.Parameters.AddWithValue("@description", editCityText.Text);

                con.Open();
                int row = comm.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                
            }

            Session["email"] = profileEmail.Text;
            Response.Redirect("Profile.aspx");
        }

        public byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public Bitmap SetContrast(System.Drawing.Image sourceImage, double contrast)
        {
            Bitmap temp = (Bitmap)sourceImage;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    bmap.SetPixel(i, j,
        Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            return (Bitmap)bmap.Clone();
        }

        public Bitmap CopyAsNegative(System.Drawing.Image sourceImage)
        {
            Bitmap bmpNew = GetArgbCopy(sourceImage);
            BitmapData bmpData = bmpNew.LockBits(new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            IntPtr ptr = bmpData.Scan0;


            byte[] byteBuffer = new byte[bmpData.Stride * bmpNew.Height];


            Marshal.Copy(ptr, byteBuffer, 0, byteBuffer.Length);
            byte[] pixelBuffer = null;


            int pixel = 0;


            for (int k = 0; k < byteBuffer.Length; k += 4)
            {
                pixel = ~BitConverter.ToInt32(byteBuffer, k);
                pixelBuffer = BitConverter.GetBytes(pixel);


                byteBuffer[k] = pixelBuffer[0];
                byteBuffer[k + 1] = pixelBuffer[1];
                byteBuffer[k + 2] = pixelBuffer[2];
            }


            Marshal.Copy(byteBuffer, 0, ptr, byteBuffer.Length);


            bmpNew.UnlockBits(bmpData);


            bmpData = null;
            byteBuffer = null;


            return bmpNew;
        }

        public Bitmap CopyAsSepiaTone(System.Drawing.Image sourceImage)
        {
            Bitmap bmpNew = GetArgbCopy(sourceImage);
            BitmapData bmpData = bmpNew.LockBits(new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            IntPtr ptr = bmpData.Scan0;


            byte[] byteBuffer = new byte[bmpData.Stride * bmpNew.Height];


            Marshal.Copy(ptr, byteBuffer, 0, byteBuffer.Length);


            byte maxValue = 255;
            float r = 0;
            float g = 0;
            float b = 0;


            for (int k = 0; k < byteBuffer.Length; k += 4)
            {
                r = byteBuffer[k] * 0.189f + byteBuffer[k + 1] * 0.769f + byteBuffer[k + 2] * 0.393f;
                g = byteBuffer[k] * 0.168f + byteBuffer[k + 1] * 0.686f + byteBuffer[k + 2] * 0.349f;
                b = byteBuffer[k] * 0.131f + byteBuffer[k + 1] * 0.534f + byteBuffer[k + 2] * 0.272f;


                byteBuffer[k + 2] = (r > maxValue ? maxValue : (byte)r);
                byteBuffer[k + 1] = (g > maxValue ? maxValue : (byte)g);
                byteBuffer[k] = (b > maxValue ? maxValue : (byte)b);
            }


            Marshal.Copy(byteBuffer, 0, ptr, byteBuffer.Length);


            bmpNew.UnlockBits(bmpData);


            bmpData = null;
            byteBuffer = null;


            return bmpNew;
        }

        public Bitmap CopyAsGrayscale(System.Drawing.Image sourceImage)
        {
            Bitmap bmpNew = GetArgbCopy(sourceImage);
            BitmapData bmpData = bmpNew.LockBits(new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            IntPtr ptr = bmpData.Scan0;


            byte[] byteBuffer = new byte[bmpData.Stride * bmpNew.Height];


            Marshal.Copy(ptr, byteBuffer, 0, byteBuffer.Length);


            float rgb = 0;


            for (int k = 0; k < byteBuffer.Length; k += 4)
            {
                rgb = byteBuffer[k] * 0.11f;
                rgb += byteBuffer[k + 1] * 0.59f;
                rgb += byteBuffer[k + 2] * 0.3f;


                byteBuffer[k] = (byte)rgb;
                byteBuffer[k + 1] = byteBuffer[k];
                byteBuffer[k + 2] = byteBuffer[k];


                byteBuffer[k + 3] = 255;
            }


            Marshal.Copy(byteBuffer, 0, ptr, byteBuffer.Length);


            bmpNew.UnlockBits(bmpData);


            bmpData = null;
            byteBuffer = null;


            return bmpNew;
        }

        private static Bitmap GetArgbCopy(System.Drawing.Image sourceImage)
        {
            Bitmap bmpNew = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);


            using (Graphics graphics = Graphics.FromImage(bmpNew))
            {
                graphics.DrawImage(sourceImage, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), GraphicsUnit.Pixel);
                graphics.Flush();
            }


            return bmpNew;
        }
    }
}