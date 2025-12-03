using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OLabrador
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["autenticado"] != null)
            {
                Login.Visible = false;
                InsertPost.Visible = true;
                ShowPost.Visible = true;
                Logout.Visible = true;
            }
            else
            {
                Login.Visible = true;
                InsertPost.Visible = false;
                ShowPost.Visible = false;
                Logout.Visible = false;
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}