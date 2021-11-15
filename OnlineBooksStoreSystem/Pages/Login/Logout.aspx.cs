using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooksStoreSystem
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)// this check mean if the request type is Get Request so will execute the code that incelude this If-statement
            {
                if (Session["UserName"] != null)
                {
                    Session.Remove("UserName");
                }
                Response.Redirect("~/Pages/Home/Home.aspx");
            }
        }
    }
}