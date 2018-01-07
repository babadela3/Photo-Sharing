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
    public partial class ProfileAlbumPhotos : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True");
        private string cityUser;
        private string idUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = (string)(Session["email"]);
            string albumId = (string)(Session["albumId"]);

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

                profileName.Text = name;
                profileEmail.Text = email;
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
            con.Close();

            string queryImages = "select Id, Description from dbo.Photos where UserId = " + idUser + "and AlbumId = " +
                albumId + " order by Date desc;";
            SqlCommand command = new SqlCommand(queryImages, con);
            con.Open();
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                String id = dataReader[0].ToString();

                HtmlGenericControl myDiv = new HtmlGenericControl("div");
                myDiv.Attributes["class"] = "divImg";
                System.Web.UI.WebControls.Image imageUpload = new System.Web.UI.WebControls.Image();
                imageUpload.ImageUrl = "~/HandlerPhoto.ashx?id=" + id;
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
            Server.Transfer("Default.aspx", true);
        }

        protected void TransferLogIn(object sender, EventArgs e)
        {
            Server.Transfer("LoginPage.aspx", true);
        }

        protected void EditProfile(object sender, EventArgs e)
        {
            Session["email"] = profileEmail.Text;
            Session["name"] = profileName.Text;
            Session["city"] = cityUser;
            Session["id"] = idUser;
            Response.Redirect("EditProfile.aspx");
        }

        protected void CreateAlbum(object sender, EventArgs e)
        {
            Session["email"] = profileEmail.Text;
            Session["name"] = profileName.Text;
            Session["id"] = idUser;
            Response.Redirect("CreateAlbum.aspx");
        }

        protected void AddImage(object sender, EventArgs e)
        {
            Session["email"] = profileEmail.Text;
            Session["name"] = profileName.Text;
            Session["id"] = idUser;
            Response.Redirect("AddImage.aspx");
        }

        protected void SeeAlbums(object sender, EventArgs e)
        {
            Session["email"] = profileEmail.Text;
            Response.Redirect("ProfileAlbums.aspx");
        }
    }
}