using OnlineBooksStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooksStoreSystem
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    ProjectOperation po = new ProjectOperation();
                    string UserNameQuery = "select UserName from Users";
                    string EmailQuery = "select Email from Users";
                    if (!po.IsValueUnique(UserName.Text.ToLower(), UserNameQuery, "UserName"))
                    {
                        Status.Text = "UserName is already exists.";
                        Status.ForeColor = Color.Red;
                    }
                    else if (!po.IsValueUnique(Email.Text.ToLower(), EmailQuery, "Email"))
                    {
                        Status.Text = "Email is already exists.";
                        Status.ForeColor = Color.Red;
                    }
                    else
                    {
                        Status.Text = string.Empty;
                        string Query = "insert into Users values(@firstName,@lastName,@userName,@password,@email,@phoneNumber,@birthDate,@genderId,@userType)";
                        SqlCommand cmd = new SqlCommand(Query, con);
                        cmd.Parameters.AddWithValue("@firstName", FirstName.Text.ToLower());
                        cmd.Parameters.AddWithValue("@lastName", LastName.Text.ToLower());
                        cmd.Parameters.AddWithValue("@userName", UserName.Text.ToLower());
                        cmd.Parameters.AddWithValue("@password", Password.Text.ToLower());
                        cmd.Parameters.AddWithValue("@birthDate", Birthdate.Text.ToLower());
                        cmd.Parameters.AddWithValue("@email", Email.Text.ToLower());
                        cmd.Parameters.AddWithValue("@phoneNumber", "0" + PhoneNumber.Text);
                        cmd.Parameters.AddWithValue("@genderId", Gender.Text);
                        cmd.Parameters.AddWithValue("@userType", 2);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        //Status.ForeColor = ColorTranslator.FromHtml("#03ff07");
                        Response.Redirect("~/Pages/Login/SignUp.aspx", false);
                    }
                }
            }
            catch
            {
                Status.Text = "Registration Failed.";
            }
        }
    }
}