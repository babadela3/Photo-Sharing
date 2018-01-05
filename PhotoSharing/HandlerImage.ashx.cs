using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PhotoSharing
{
    /// <summary>
    /// Summary description for HandlerImage
    /// </summary>
    public class HandlerImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.QueryString["id"].ToString());
            

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MINDIT-PC\source\repos\PhotoSharing\PhotoSharing\App_Data\Database.mdf;Integrated Security=True");
            SqlCommand comm = new SqlCommand();
            comm.Connection = con;

            comm.CommandText = "select * from Users where Id = @id";
            comm.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();

            da.Fill(dt);

            byte[] image = (byte[])dt.Rows[0][6];

            context.Response.ContentType = "image/jpeg";
            context.Response.ContentType = "image/jpg";
            context.Response.ContentType = "image/png";

            context.Response.BinaryWrite(image);
            context.Response.Flush();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}