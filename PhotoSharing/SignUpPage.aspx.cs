using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            string query = "insert into dbo.Users(Email,Password,Name,City) values ('" + createEmailText.Text +
                "','" + createPasswordText.Text +"','" + createNameText.Text + "','" + createCityText.Text + "')";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}