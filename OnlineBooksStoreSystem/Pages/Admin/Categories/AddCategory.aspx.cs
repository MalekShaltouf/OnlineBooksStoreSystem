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
    public partial class WebForm12 : System.Web.UI.Page
    {
        ProjectOperation op = new ProjectOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null) // this check mean => if user login so will exexute the code that inclide if-statement else => will redirect user to Login Page
                {
                    if (!op.IsUserAdmin(Session["UserName"].ToString())) //this check mean => if user is not admin so will redirect user to Home Page
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

        protected void AddCategory_Click(object sender, EventArgs e)
        {
            string Query = "select CategoryName from categories";
            string categoryname = CategoryName.Text.ToLower();
            if (!op.IsValueUnique(categoryname, Query, "CategoryName"))// this check mean => if the category name is exists so will execute the code that include if-statement else => so will add category on table
            {
                Status.Text = "category name is already exists";
            }
            else {
                try
                {
                    string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        string Query2 = "insert into Categories values(@categoryName)";
                        SqlCommand cmd = new SqlCommand(Query2, con);
                        cmd.Parameters.Add(new SqlParameter("@categoryName", categoryname));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Response.Redirect("~/Pages/Admin/Categories/Categories.aspx");
                    }
                }
                catch {
                    Status.Text = "Something error occured during insertion data.";
                }
                
            }
        }
    }
}