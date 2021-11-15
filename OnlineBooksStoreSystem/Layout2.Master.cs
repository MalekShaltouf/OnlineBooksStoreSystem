using OnlineBooksStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooksStoreSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                ProjectOperation op = new ProjectOperation();
                if (op.IsUserAdmin(Session["UserName"].ToString()))
                {
                    Admin.Visible = true;
                }
                profileLink.Visible = true;
                UserNameSpan.Text = Session["UserName"].ToString();
                UserNameSpan.Visible = true;
                Login.Visible = false;
                Logout.Visible = true;
            }
        }
    }
}