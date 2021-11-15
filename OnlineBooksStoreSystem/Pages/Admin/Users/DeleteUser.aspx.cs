using OnlineBooksStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooksStoreSystem.Pages.Admin.Users
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        ProjectOperation op = new ProjectOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)//this check mean => if user enter this page without enter id so will redirect to Home Page
                {
                    if (Session["UserName"] != null) // here if user not Login so will redirect user to Login Page
                    {
                        if (!op.IsUserAdmin(Session["UserName"].ToString()))// this check mean => if user not admin =>so will redirect user to Home Page else => if user is admin so will store previous Category Name in Category Box 
                        {
                            Response.Redirect("~/Pages/Home/Home.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Pages/Login/Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Pages/Home/Home.aspx");
                }
                //here write code
                Session["Status"] = "delete";
                Response.Redirect("~/Pages/Admin/Users/UserDetails.aspx?id=" + Request.QueryString["id"]);
            }
        }
    }
}