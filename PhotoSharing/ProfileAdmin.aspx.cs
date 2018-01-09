using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;


namespace PhotoSharing
{
    public partial class ProfileAdmin : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True");
        private string cityUser;
        private string idUser;

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
                idUser = dataReader[0].ToString();
                cityUser = dataReader[4].ToString();

                profileName.Text = email;
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
            con.Close();

            string queryImages = "select Id, Description from dbo.Photos order by Date desc;";
            SqlCommand command = new SqlCommand(queryImages, con);
            con.Open();
            dataReader = command.ExecuteReader();
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
                description.Text = dataReader[1].ToString();
                myDiv.Controls.Add(imageUpload);
                divDescription.Controls.Add(description);
                myDiv.Controls.Add(divDescription);
                myDiv.Controls.Add(divDescription);
                PlaceHolder1.Controls.Add(myDiv);
            }
            con.Close();
        }

        protected void TransferDefault(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        protected void TransferLogIn(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
        }

        protected void Search(object sender, EventArgs e)
        {
            Session["email"] = profileName.Text;
            Session["option"] = RadioButton1.SelectedValue;
            Session["search"] = searchBar.Text;
            Response.Redirect("SearchPhoto.aspx");
        }

        protected void AddImage(object sender, EventArgs e)
        {
            Session["email"] = profileName.Text;
            Session["name"] = profileName.Text;
            Session["id"] = idUser;
            Response.Redirect("AddImage.aspx");
        }

        protected void SeeAlbums(object sender, EventArgs e)
        {
            Session["email"] = profileName.Text;
            Response.Redirect("ProfilAdminImages.aspx");
        }

        protected void ClickImage(object sender, EventArgs e)
        {
            ImageButton div = (ImageButton)sender;
            Session["email"] = profileName.Text;
            Session["photoId"] = div.ID;
            Session["idUser"] = idUser;
            Response.Redirect("SeePhotoComment.aspx");
        }
    }
}