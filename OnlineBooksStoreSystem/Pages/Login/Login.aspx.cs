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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // this check mean if the request type is Get Request so will execute the code that incelude this If-statement
            {
                if (Session["UserName"] != null)
                {
                    Response.Redirect("~/Pages/Home/Home.aspx");
                }
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    string Query = "select UserName from Users where Username = @username and Password = @password";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.Add(new SqlParameter("@username", UserName.Text.ToLower()));
                    cmd.Parameters.Add(new SqlParameter("@password", Password.Text));
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        Session["UserName"] = UserName.Text;
                        ProjectOperation op = new ProjectOperation();
                        if (op.IsUserAdmin(Session["UserName"].ToString()))
                        {
                            Response.Redirect("~/Pages/Admin/Categories/Categories.aspx");
                        }
                        Response.Redirect("~/Pages/Books/Books.aspx");
                    }
                    else
                    {
                        Status.Text = "username or password is wrong.";
                    }
                }

            }
            catch(Exception ex)
            {
                Status.Text = "something error occurred during Login.";
            }
        }
    }
}