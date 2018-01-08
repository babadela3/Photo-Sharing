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
    public partial class SeePhoto : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True");
        private string idUser;
        private string email;

        protected void Page_Load(object sender, EventArgs e)
        {
            email = (string)(Session["email"]);
            idUser = (string)(Session["idUser"]);
            string photoId = (string)(Session["photoId"]);
            Image.ImageUrl = "~/HandlerPhoto.ashx?id=" + photoId;
            con.Close();
        }
         
    }
}