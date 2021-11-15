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
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)// this check mean if the request type is Get Request so will execute the code that incelude this If-statement
            {
                ProjectOperation op = new ProjectOperation();

                if (Session["UserName"] != null)//here this check mean => if the user Login so will execute code that include this If-statement else => will redirect user to Login Page
                {
                    if (op.IsUserAdmin(Session["UserName"].ToString()))//here this check mean => if the user is Admin so will execute code that include this If-statement else => will redirect user to home Page
                    {
                        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(conStr))
                        {
                            string Query = "select * from categories";
                            SqlCommand cmd = new SqlCommand(Query, con);
                            con.Open();
                            using (SqlDataReader rdr = cmd.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    fform.Visible = true;
                                    EmptyData.Visible = false;
                                    GridView1.DataSource = rdr;
                                    GridView1.DataBind();
                                }
                                else {
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