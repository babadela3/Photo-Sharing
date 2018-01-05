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
    public partial class InsertImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile.FileName != "")
            {
                byte[] image;
                Stream s = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(s);
                image = br.ReadBytes((Int32)s.Length);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True");
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;

                comm.CommandText = "insert into Images values (2,@image)";
                comm.Parameters.AddWithValue("@image", image);

                con.Open();
                int row = comm.ExecuteNonQuery();
                con.Close();

                if (row > 0)
                {
                    LabelError.Text = "Success";
                }
            }
            else {
                LabelError.Text = "Insuccess";
            }
        }
    }
}