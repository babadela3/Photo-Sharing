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
    
    public partial class EditProfile : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = (string)(Session["email"]);
            string name = (string)(Session["name"]);
            string city = (string)(Session["city"]);
            string id = (string)(Session["id"]);

            if(email != String.Empty){

                ImageProfile.ImageUrl = "~/HandlerImage.ashx?id=" + id;
                profileName.Text = name;
                profileEmail.Text = email;
                editEmailText.Text = email;
                editNameText.Text = name;
                editCityText.Text = city;

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


    }
}