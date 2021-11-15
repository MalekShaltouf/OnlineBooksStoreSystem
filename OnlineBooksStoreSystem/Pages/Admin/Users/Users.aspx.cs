using OnlineBooksStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooksStoreSystem.Pages.Admin.Users
{
    public partial class Users : System.Web.UI.Page
    {
        ProjectOperation op = new ProjectOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)// this check mean if the request type is Get Request so will execute the code that incelude this If-statement
            {
                if (Session["UserName"] != null)//here this check mean => if the user Login so will execute code that include this If-statement else => will redirect user to Login Page
                {
                    if (op.IsUserAdmin(Session["UserName"].ToString()))//here this check mean => if the user is Admin so will execute code that include this If-statement else => will redirect user to home Page
                    {
                        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(conStr))
                        {
                            string Query = "select * from Users inner join UserTypes on Users.UserType = UserTypes.TypeId";
                            SqlCommand cmd = new SqlCommand(Query, con);
                            con.Open();
                            using (SqlDataReader rdr = cmd.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    GridView1.DataSource = rdr;
                                    GridView1.DataBind();
                                    fform.Visible = true;
                                    EmptyData.Visible = false;
                                }
                                else
                                {
                                    fform.Visible = false;
                                    EmptyData.Visible = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Pages/Home/Home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Pages/Login/Login.aspx");
                }
            }
        }
    }
}