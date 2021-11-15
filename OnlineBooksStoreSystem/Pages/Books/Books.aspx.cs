using OnlineBooksStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooksStoreSystem
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)// this check mean if the request type is Get Request so will execute the code that incelude this If-statement
            {
                if (Session["UserName"] != null)
                {
                    string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        string Query = "select * from Books inner join categories on Books.CategoryId = categories.Category_Id";
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
                            else {
                                fform.Visible = false;
                                EmptyData.Visible = true;
                            }

                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Pages/Login/Login.aspx");
                }
            }
        }

        protected void OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            ProjectOperation op = new ProjectOperation();
            string UserName = Session["UserName"].ToString();
            if (UserName != null && op.IsUserAdmin(UserName))
            {
                e.Row.Cells[6].Visible = true;
                e.Row.Cells[7].Visible = true;
                AddBook.Visible = true;
            }
            else {
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                AddBook.Visible = false;
            }
        }
    }
}