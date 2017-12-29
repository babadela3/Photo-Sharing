using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PhotoSharing
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TransferLogIn(object sender, EventArgs e) {
            Server.Transfer("LoginPage.aspx", true);
        }

        protected void TransferSignUp(object sender, EventArgs e)
        {
            Server.Transfer("SignUpPage.aspx", true);
        }

    }
}