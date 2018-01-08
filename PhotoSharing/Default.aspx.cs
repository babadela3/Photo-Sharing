using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace PhotoSharing
{
    public partial class Default : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True");
        private string email;
        private string userId;
        private bool checkEmail;

        protected void Page_Load(object sender, EventArgs e)
        {
            email = (string)(Session["email"]);
            string option = (string)(Session["option"]);
            checkEmail = CheckEmail(email);

            if (CheckEmail(email))
            {
                logIn.Visible = false;
                signUp.Visible = false;
            }
            else {
                profile.Visible = false;
                logOut.Visible = false;
            }
           
            LoadPhotos("Animal");
            LoadPhotos("Architecture");
            LoadPhotos("Food");
            LoadPhotos("Landscape");
            LoadPhotos("Nature");
            LoadPhotos("Portrait");
            LoadPhotos("Objects");
        }

        protected void TransferLogIn(object sender, EventArgs e) {
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
        }

        protected void TransferLogOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
        }

        protected void Search(object sender, EventArgs e)
        {
            Session["email"] = email;
            Session["option"] = RadioButton1.SelectedValue;
            Session["search"] = searchBar.Text;
            Response.Redirect("SearchPhoto.aspx");
        }

        protected void TransferSignUp(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
        }

        protected void ClickImage(object sender, EventArgs e)
        {
            if (checkEmail)
            {
                Response.Write("<script>alert('" + email + "')</script>");
                ImageButton div = (ImageButton)sender;
                Session["email"] = email;
                Session["photoId"] = div.ID;
                Session["idUser"] = userId;
                Session["deletePhoto"] = "false";
                Response.Redirect("SeePhotoComment.aspx");
            }
            else {
                ImageButton div = (ImageButton)sender;
                Session["photoId"] = div.ID;
                Response.Redirect("SeePhoto.aspx");
            }
        }

        protected void LoadPhotos(string category) {
            HtmlGenericControl divTitle = new HtmlGenericControl("div");
            Label categoryTitle = new Label();
            categoryTitle.Text = category;
            divTitle.Attributes["class"] = "divTitle";
            divTitle.Controls.Add(categoryTitle);
            PlaceHolder1.Controls.Add(divTitle);

            string queryImages = "select TOP 6 * from dbo.Photos where Category = '" + category + "' ORDER BY Date desc;";
            SqlCommand command = new SqlCommand(queryImages, con);
            con.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                String id = dataReader[0].ToString();
                
                HtmlGenericControl myDiv = new HtmlGenericControl("div");
                myDiv.Attributes["class"] = "divImg";
                ImageButton imageUpload = new ImageButton();
                imageUpload.ImageUrl = "~/HandlerPhoto.ashx?id=" + id;
                imageUpload.Click += new ImageClickEventHandler(ClickImage);
                imageUpload.ID = id;
                imageUpload.Attributes["class"] = "imgPresentation";
                HtmlGenericControl divDescription = new HtmlGenericControl("div");
                divDescription.Attributes["class"] = "description";
                Label description = new Label();
                description.Text = dataReader[7].ToString();
                myDiv.Controls.Add(imageUpload);
                divDescription.Controls.Add(description);
                myDiv.Controls.Add(divDescription);
                myDiv.Controls.Add(divDescription);
                PlaceHolder1.Controls.Add(myDiv);
            }
            con.Close();
        }

        protected bool CheckEmail(string email) {
            string query = "select * from dbo.Users where Email = '" + email + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                userId = dataReader[0].ToString();
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }

        protected void TransferProfile(object sender, EventArgs e)
        {
            Session["email"] = email;
            Response.Redirect("Profile.aspx");
        }
    }
}