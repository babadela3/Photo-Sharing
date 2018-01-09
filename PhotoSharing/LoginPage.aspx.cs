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
    public partial class LoginPage : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Search(object sender, EventArgs e)
        {
            Session["email"] = "";
            Session["option"] = RadioButton1.SelectedValue;
            Session["search"] = searchBar.Text;
            Response.Redirect("SearchPhoto.aspx");
        }

        protected void TransferDefault(object sender, EventArgs e)
        {
            Server.Transfer("Default.aspx", true);
        }

        protected void TransferSignUp(object sender, EventArgs e)
        {
            Server.Transfer("SignUpPage.aspx", true);
        }

        protected void Login(object sender, EventArgs e)
        {
            if (loginEmailText.Text.Equals("Admin") && loginPasswordText.Text.Equals("Admin")) {
                Response.Write("<script>alert('" + loginEmailText.Text + "')</script>");
                Session["email"] = loginEmailText.Text;
                Response.Redirect("ProfileAdmin.aspx");
            }
            if (loginEmailText.Text != String.Empty && loginPasswordText.Text != String.Empty)
            {
                string query = "select * from dbo.Users where Email = '" + loginEmailText.Text +
                "' and Password = '" + loginPasswordText.Text + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    Session["email"] = loginEmailText.Text;
                    Response.Redirect("Profile.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Email or password is invalid!')</script>");
                }
                con.Close();
            }
            else {
                Response.Write("<script>alert('Complete all fields!')</script>");
            }
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }
    }
}