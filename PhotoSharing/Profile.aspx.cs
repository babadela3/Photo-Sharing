using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PhotoSharing
{
    public partial class Profile : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = (string)(Session["email"]);

            string query = "select * from dbo.Users where Email = '" + email + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                int id = Int32.Parse(dataReader[0].ToString());
                ImageProfile.ImageUrl = "~/HandlerImage.ashx?id=" + id;
                string name = dataReader[3].ToString();

                profileName.Text = name;
                profileEmail.Text = email;
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
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

        protected void EditProfile(object sender, EventArgs e)
        {
            Session["email"] = profileEmail.Text;
            Response.Redirect("EditProfile.aspx");
        }


    }
}