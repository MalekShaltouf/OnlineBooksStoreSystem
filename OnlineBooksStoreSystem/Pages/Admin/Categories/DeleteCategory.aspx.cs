using OnlineBooksStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooksStoreSystem
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        ProjectOperation op = new ProjectOperation();
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
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
                try
                {
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        string Query = "select * from categories where Category_Id = @categoryId";
                        SqlCommand cmd = new SqlCommand(Query, con);
                        cmd.Parameters.Add(new SqlParameter("@categoryId", Request.QueryString["id"]));
                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                CategoryName.Text = rdr["CategoryName"].ToString();
                            }
                        }
                    }
                }
                catch {
                    Status.Text = "Something Error occuerd during display Category information.";
                    Status.ForeColor = Color.Red;
                }
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    /*[start]
                     * here we want to check if the category contains Books or not because if we not do this check so will return error that Categories table is foriegn key with books table 
                     *      if category contains Books so will return for user message that must be delete books that followed to this categorty before delete the category
                     *      else if category not contains any book so will delete this category
                     */
                    string Query1 = "select * from Books where CategoryId = @categoryId";//this query return all books that followed to this @categoryId 
                    SqlCommand cmd = new SqlCommand(Query1, con);
                    cmd.Parameters.AddWithValue("@categoryId",Request.QueryString["id"]);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();//if rdr contains at least one row so mean => this category contains Books
                    if (rdr.Read()) 
                    {
                        Status.Text = "This Category contains Books,if you want to delete this category must be delete all Books that follwed for this category.";
                        Status.ForeColor = Color.Red;
                    }
                    else {
                        con.Close();
                        string Query2 = "Delete from categories where Category_Id = @categoryId";
                        SqlCommand cmd2 = new SqlCommand(Query2, con);
                        cmd2.Parameters.Add(new SqlParameter("@categoryId", Request.QueryString["id"]));
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        Response.Redirect("~/Pages/Admin/Categories/Categories.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                //Status.Text = "Something error occuerd during delete this recorde.";
                Status.Text = ex.Message;
                Status.ForeColor = Color.Red;
            }
        }
    }
}