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
    public partial class CreateAlbum : System.Web.UI.Page
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

        protected void Create(object sender, EventArgs e)
        {
            con.Open();


            string query = "insert into dbo.Albums(userId,name) values (" + Int32.Parse(id) + ",'" + editEmailText.Text + "');";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Session["email"] = profileEmail.Text;
            Response.Redirect("Profile.aspx");
        }
    }
}