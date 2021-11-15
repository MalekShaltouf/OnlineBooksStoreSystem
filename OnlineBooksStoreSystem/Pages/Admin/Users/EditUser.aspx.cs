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
    public partial class EditUser : System.Web.UI.Page
    {
        //comment in end of page that explain what's do this page.
        ProjectOperation op = new ProjectOperation();
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null) // this check mean => if user login so will exexute the code that inclide if-statement else => will redirect user to Login Page
                {
                    try
                    {
                        /*
                         * here we want to bind GenderDDList with DataBase
                         * and we want to store the previous user information value in Input Boxes 
                         */
                        using (SqlConnection con = new SqlConnection(conStr))
                        {
                            string Query = "select * from Genders";//this query in order to bind GenderDDList with Genders table
                            SqlCommand cmd = new SqlCommand(Query, con);
                            SqlCommand cmd3 = new SqlCommand();
                            cmd3.Connection = con;
                            string Query3 = null;
                            if (op.IsUserAdmin(Session["UserName"].ToString()))//here when enter 
                            {
                                if (Request.QueryString["id"] != null)//this check mean => if user enter this page without enter id and so will redirect to Home Page
                                {
                                    Query3 = "select * from Users inner join Genders on Users.GenderId = Genders.GenderId where UserId = @userId";//this query in order to to store previous user information in input Boxes
                                    cmd3.Parameters.AddWithValue("@userId", Request.QueryString["id"]);
                                }
                                else
                                {
                                    Response.Redirect("~/Pages/Home/Home.aspx");
                                }
                            }
                            else//here if user enter as user
                            {
                                Query3 = "select * from Users inner join Genders on Users.GenderId = Genders.GenderId where UserName = @userName";//this query in order to to store previous user information in input Boxes
                                cmd3.Parameters.AddWithValue("@userName", Session["UserName"].ToString());
                            }
                            cmd3.CommandText = Query3;
                            con.Open();
                            string Gender = null;
                            int GenderItemSelectIndex = 0; // here we want to store the index for item in GenderDDList that we want to be selected when open EditUser Page.
                            using (SqlDataReader rdr = cmd3.ExecuteReader())
                            {
                                if (rdr.Read())
                                {
                                    FirstName.Text = rdr["FirstName"].ToString();
                                    LastName.Text = rdr["LastName"].ToString();
                                    UserName.Text = rdr["UserName"].ToString();
                                    Password.Attributes.Add("value", rdr["Password"].ToString());
                                    Email.Text = rdr["Email"].ToString();
                                    PhoneNumber.Text = rdr["PhoneNumber"].ToString();
                                    BirthDate.Text = ((DateTime)rdr["BirthDate"]).ToString("yyyy-MM-dd");
                                    Gender = rdr["GenderDesc"].ToString();
                                }
                            }
                            using (SqlDataReader rdr = cmd.ExecuteReader())
                            {
                                GenderDDList.Items.Add(new ListItem("--Select Gender", "0"));
                                while (rdr.Read())
                                {
                                    ListItem item = new ListItem(rdr["GenderDesc"].ToString(), rdr["GenderId"].ToString());
                                    if (Gender == rdr["GenderDesc"].ToString())
                                    {
                                        GenderItemSelectIndex = Convert.ToInt32(rdr["GenderId"]);
                                    }
                                    GenderDDList.Items.Add(item);
                                }
                                GenderDDList.SelectedIndex = GenderItemSelectIndex;
                            }
                        }
                    }
                    catch
                    {
                        Status.Text = "Something error occurred during display Gender or UserTypes in DDList.";
                    }
                }
                else
                {
                    Response.Redirect("~/Pages/Login/Login.aspx");
                }
            }
        }

        protected void EditUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (GenderDDList.SelectedIndex != 0)//here check if admin select Gender or not => so if selected it will execute the code that include if-statement else => if admin not selected gender will execute the code include else-keyword
                {
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        string Query = null;
                        if (op.IsUserAdmin(Session["UserName"].ToString())) //here if admin will update for any user so will execute this code (depends UserId) why if was admin must be depends UserId? because the admin must be can update data for any user he want
                        {
                            if (Request.QueryString["Id"] != null)
                            {
                                Query = "update Users set FirstName = @firstName,LastName = @lastName,UserName = @userName,Password = @password,Email = @email,PhoneNumber = @phoneNumber,BirthDate = @birthDate,GenderId = @genderId where UserId = @userId";
                                cmd.Parameters.AddWithValue("@userId", Request.QueryString["id"]);
                            }
                            else
                            {
                                Response.Redirect("~/Pages/Home/Home.aspx");
                            }
                        }
                        else // here if user want to update own information so will execute this code (depends UserName) why if was admin must be depends UserName? because the use must be just can update own information 
                        {
                            Query = Query = "update Users set FirstName = @firstName,LastName = @lastName,UserName = @userName,Password = @password,Email = @email,PhoneNumber = @phoneNumber,BirthDate = @birthDate,GenderId = @genderId where UserName = @UName";
                            cmd.Parameters.AddWithValue("@UName", Session["UserName"]);
                        }
                        cmd.CommandText = Query;
                        cmd.Parameters.AddWithValue("@firstName", FirstName.Text.ToLower());
                        cmd.Parameters.AddWithValue("@lastName", LastName.Text.ToLower());
                        cmd.Parameters.AddWithValue("@userName", UserName.Text.ToLower());
                        cmd.Parameters.AddWithValue("@password", Password.Text);
                        cmd.Parameters.AddWithValue("@email", Email.Text.ToLower());
                        cmd.Parameters.AddWithValue("@phoneNumber", PhoneNumber.Text);
                        cmd.Parameters.AddWithValue("@birthDate", BirthDate.Text);
                        cmd.Parameters.AddWithValue("@genderId", GenderDDList.SelectedValue);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        if (op.IsUserAdmin(Session["UserName"].ToString()))
                        {
                            Response.Redirect("~/Pages/Admin/Users/Users.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Pages/Admin/Users/UserDetails.aspx");
                        }
                        
                    }
                }
                else
                {
                    Status.Text = "must be specify Gender.";
                }
            }
            catch
            {
                Status.Text = "Somthing error occurred during updating data.";
            }
        }
    }
}
/*
 * this page do more than thing
 * 1- if the usertype is admin:
 *     A- Display GenderDDList,UserTypeDDList which the DDL was selected the value for admin for any user he want.
 *     B- Admin can be update any user he want.
 *     
 * 2- if usertype is user
 *      A- user can be see just own GenderDDList,UserTypeDDList which the DDL was selected the own value.
 *      B- user can be update just own inforamtion.   
 */
