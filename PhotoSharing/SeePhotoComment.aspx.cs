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
    public partial class SeePhotoComment : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True");
        private string idUser;
        private string email;
        private string photoId;
        private string deletePhoto;

        protected void Page_Load(object sender, EventArgs e)
        {
            email = (string)(Session["email"]);
            idUser = (string)(Session["idUser"]);
            photoId = (string)(Session["photoId"]);
            deletePhoto = (string)(Session["deletePhoto"]);
            Image.ImageUrl = "~/HandlerPhoto.ashx?id=" + photoId;

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
                profileName.Text = name;
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
            con.Close();
            LoadComment(Int32.Parse(photoId));
        }

        protected void AddComment(object sender, EventArgs e) {
            con.Open();
            
            string query = "insert into dbo.Comments(ImageId,UserId,Message,Date) values ('" + photoId +
                "','" + idUser + "','" + commentText.Text + "', SYSDATETIME() );";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            Session["email"] = email;
            Session["photoId"] = photoId;
            Session["idUser"] = idUser;
            Response.Redirect("SeePhotoComment.aspx");

        }

        protected void LoadComment(int photoId)
        {
            string queryImages = "select com.Message, usr.Name, com.Id from dbo.Comments com join dbo.Users usr on com.UserId = usr.Id " +
                "where com.ImageId = " + photoId + ";";
            SqlCommand command = new SqlCommand(queryImages, con);
            con.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                HtmlGenericControl divComment = new HtmlGenericControl("div");
                divComment.Attributes["class"] = "comment";

                Label labelName = new Label();
                labelName.Attributes["class"] = "commentName";
                labelName.Text = dataReader[1].ToString() + " : ";

                
                LinkButton labelComment = new LinkButton();
                labelComment.Text = dataReader[0].ToString();
                labelComment.ID = dataReader[2].ToString();
                labelComment.Font.Underline = false;
                labelComment.Attributes["class"] = "underlinedLinkButton";
                if (deletePhoto == null) {
                    labelComment.Click += new EventHandler(DeleteComment);
                }
                divComment.Controls.Add(labelName);
                divComment.Controls.Add(labelComment);

                PlaceHolder1.Controls.Add(divComment);
            }
            
            con.Close();
        }

        void DeleteComment(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Data inserted successfully')</script>");
            LinkButton div = (LinkButton)sender;

            string query = "delete from dbo.Comments where Id = " + Int32.Parse(div.ID);

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Session["email"] = email;
            Session["photoId"] = photoId;
            Session["idUser"] = idUser;
            Response.Redirect("SeePhotoComment.aspx");

        }
    }
}