using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoSharing
{
    public partial class SignUpPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TransferDefault(object sender, EventArgs e)
        {
            Server.Transfer("Default.aspx", true);
        }

        protected void TransferLogIn(object sender, EventArgs e)
        {
            Server.Transfer("LoginPage.aspx", true);
        }

        protected void CreateAccount(object sender, EventArgs e)
        {
            if (IsValidEmail(createEmailText.Text))
            {

                con.Open();
                string query = "select * from dbo.Users where Email = '" + createEmailText.Text + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    Response.Write("<script>alert('Email already exists!')</script>");
                    con.Close();
                }
                else
                {
                    con.Close();
                    con.Open();
                    byte[] image = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/images/profile.jpg"));

                    query = "insert into dbo.Users(Email,Password,Name,City,Role,Image) values ('" + createEmailText.Text +
                        "','" + createPasswordText.Text + "','" + createNameText.Text + "','" + createCityText.Text + "','User',@image)";

                    cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@image", image);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Session["email"] = createEmailText.Text;
                    Response.Redirect("Profile.aspx");
                }
                
            }
            else {
                Response.Write("<script>alert('Email is not valid!')</script>");
            }

            
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}