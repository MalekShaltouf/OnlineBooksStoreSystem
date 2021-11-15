using OnlineBooksStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooksStoreSystem
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        ProjectOperation op = new ProjectOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null || Request.QueryString["catName"] != null)//this check mean => if user enter this page without enter id and Category Name so will redirect to Home Page
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
                CategoryName.Text = Request.QueryString["catName"];
            }
        }
        protected void AddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    string Query = "update categories set CategoryName = @categoryName where Category_Id = @categoryId";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@categoryName", CategoryName.Text.ToString().ToLower());
                    cmd.Parameters.Add(new SqlParameter("@categoryId", Request.QueryString["id"]));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("~/Pages/Admin/Categories/Categories.aspx");
                }
            }
            catch {
                Status.Text = "Something error occuerd during Updating data.";
            }
        }
    }
}