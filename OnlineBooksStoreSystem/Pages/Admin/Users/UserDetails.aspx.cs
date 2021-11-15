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
    //comment in end of page that explain what's do this page.
    public partial class UserDetails : System.Web.UI.Page
    {
        ProjectOperation op = new ProjectOperation();
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)// this check mean if the request type is Get Request so will execute the code that incelude this If-statement
            {
                if (Session["UserName"] != null)//here this check mean => if the user Login so will execute code that include this If-statement else => will redirect user to Login Page
                {
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        string Query = null;
                        if (op.IsUserAdmin(Session["UserName"].ToString()))//when enter EditUser page as admin so must be enter page with UserId in query string because the db-statement when enter as admin depends on UserId why? because admin must be can see Details for any user he want so in order to do it must be depends on UserId
                        {
                            if (Request.QueryString["id"] != null) //here if admin enter UserDetails without enter id in QString so will redirect him to Home Page
                            {
                                BackToListLink.Visible = true;
                                EditUserLink.NavigateUrl = "~/Pages/Admin/Users/EditUser.aspx?id=" + Request.QueryString["id"]; 
                                Query = "select * from Users inner join UserTypes on Users.UserType = UserTypes.TypeId inner join Genders on Users.GenderId = Genders.GenderId where UserId = @userId";
                                cmd.Parameters.AddWithValue("@userId", Request.QueryString["id"]);

                                if (Session["Status"] != null)
                                {
                                    DelBtn.Visible = true;
                                    Session.Remove("Status");
                                }
                                else
                                {
                                    DelBtn.Visible = false;
                                }
                            }
                            else
                            {
                                Response.Redirect("~/Pages/Home/Home.aspx");
                            }
                        }
                        else//when enter EditUser page as user so must be enter page without UserId in query string because the db-statement when enter as user depends on UserName why? because user must be can only see Details for own information so in order to do it must be depends on UserName
                        {
                            BackToListLink.Visible = false;
                            Query = "select * from Users inner join Genders on Users.GenderId = Genders.GenderId inner join UserTypes on Users.UserType = UserTypes.TypeId where UserName = @userName";
                            cmd.Parameters.AddWithValue("@userName", Session["UserName"]);
                        }
                        cmd.CommandText = Query;
                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                FirstName.Text = rdr["Firstname"].ToString();
                                LastName.Text = rdr["LastName"].ToString();
                                UserName.Text = rdr["UserName"].ToString();
                                Password.Text = rdr["Password"].ToString();
                                Email.Text = rdr["Email"].ToString();
                                PhoneNumber.Text = rdr["PhoneNumber"].ToString();
                                BirthDate.Text = ((DateTime)rdr["BirthDate"]).ToString("yyyy-MM-dd");
                                Gender.Text = rdr["GenderDesc"].ToString();
                                UserType.Text = rdr["TypeDesc"].ToString();
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

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    string Query = "delete from Users where UserId = @userId";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.Add(new SqlParameter("@userId", Request.QueryString["id"]));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("~/Pages/Admin/Users/Users.aspx");
                }
            }
            catch
            {
                Status.Text = "Something error occurred during delete data.";
            }
        }
    }
}
/*
 * this page do more than thing
 * 1- if the usertype is admin:
 *     A- Display Details  for admin for any user he want.
 *     B- Admin can be delete any user he want.
 *     
 * 2- if usertype is user
 *      A- user can be see just own inforamtion.
 *      B- user can be update just own inforamtion.   
 */
