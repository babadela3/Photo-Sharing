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
    public partial class Profile : System.Web.UI.Page
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

                profileName.Text = name;
                profileEmail.Text = email;
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
            con.Close();
            DisplayInfo();

            string queryImages = "select Id, Description from dbo.Photos where UserId = " + idUser + " order by Date desc;";
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
            Session["isLog"] = "true";
            Session["email"] = profileEmail.Text;
            Response.Redirect("Default.aspx");
        }

        protected void Search(object sender, EventArgs e)
        {
            Session["email"] = profileEmail.Text;
            Session["option"] = RadioButton1.SelectedValue;
            Session["search"] = searchBar.Text;
            Response.Redirect("SearchPhoto.aspx");
        }

        protected void TransferLogIn(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
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

        protected void ClickImage(object sender, EventArgs e)
        {
            ImageButton div = (ImageButton)sender;
            Session["email"] = profileEmail.Text;
            Session["photoId"] = div.ID;
            Session["idUser"] = idUser;
            Response.Redirect("SeePhotoComment.aspx");
        }

        public void DisplayInfo() {
            string query = "select count(*) from dbo.Photos where UserId = " + Int32.Parse(idUser) + ";";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                profilePhotos.Text = dataReader[0].ToString() + " photos";
            }
            con.Close();

            string queryAlbums = "select count(*) from dbo.Albums where UserId = " + Int32.Parse(idUser) + ";";

            SqlCommand cmdAlbums = new SqlCommand(queryAlbums, con);
            con.Open();
            SqlDataReader dataReaderAlbums = cmd.ExecuteReader();
            if (dataReaderAlbums.Read())
            {
                profileAlbums.Text = dataReaderAlbums[0].ToString() + " albums";
            }
            con.Close();

            string queryComments = "select count(*) from dbo.Comments where UserId = " + Int32.Parse(idUser) + ";";

            SqlCommand cmdComments = new SqlCommand(queryComments, con);
            con.Open();
            SqlDataReader dataReaderComments = cmd.ExecuteReader();
            if (dataReaderComments.Read())
            {
                profileComments.Text = dataReaderComments[0].ToString() + " comments";
            }
            con.Close();

        }
    }
}