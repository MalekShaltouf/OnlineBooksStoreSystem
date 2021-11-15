using OnlineBooksStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooksStoreSystem.Pages.User
{
    public partial class Profile : System.Web.UI.Page
    {
        ProjectOperation op = new ProjectOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null) // here if user signIn so will execute the code that include if-statement
                {
                    if (op.IsUserAdmin(Session["UserName"].ToString()))// here => when enter to Profile page as a admin must be redirect him to UserDetails Page with UserId because the Db-Query that own admin depends on to UserId
                    {
                        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(conStr))
                        {
                            string Query = "select UserId from Users where UserName = @username";
                            SqlCommand cmd = new SqlCommand(Query, con);
                            cmd.Parameters.AddWithValue("@username", Session["UserName"].ToString());
                            con.Open();
                            int UserId = Convert.ToInt32(cmd.ExecuteScalar());
                            Response.Redirect("~/Pages/Admin/Users/UserDetails.aspx?id=" + UserId);
                        }
                    }
                    else// here => when enter to Profile page as a user not need to redirect him to UserDetails Page with UserId because the Db-Query that own user depends on to UserName
                    {
                        Response.Redirect("~/Pages/Admin/Users/UserDetails.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Pages/Home/Home.aspx");
                }
            }
        }
    }
}