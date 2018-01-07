using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

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
            Response.Write("<script>alert('" + editAlbumText.SelectedValue +"')</script>");

            if (editNameText.PostedFile.FileName != "")
            {
                byte[] image;
                Stream s = editNameText.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(s);
                image = br.ReadBytes((Int32)s.Length);

                

                SqlCommand comm = new SqlCommand();
                comm.Connection = con;

                comm.CommandText = "insert into Photos(Image,UserId,AlbumId,Name,Category,Location,Description, Date) values" +
                    " (@image,@userId,@albumId,@name,@category,@location,@description,SYSDATETIME() )";
                comm.Parameters.AddWithValue("@image", image);
                comm.Parameters.AddWithValue("@userId", Convert.ToInt32(id));
                comm.Parameters.AddWithValue("@albumId", Convert.ToInt32(editAlbumText.SelectedValue));
                comm.Parameters.AddWithValue("@name", editEmailText.Text);
                comm.Parameters.AddWithValue("@category", editCategoryText.Text);
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
    }
}