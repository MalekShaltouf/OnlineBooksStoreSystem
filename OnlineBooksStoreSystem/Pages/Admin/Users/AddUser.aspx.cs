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
    public partial class AddUser : System.Web.UI.Page
    {
        ProjectOperation op = new ProjectOperation();
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
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
                try
                {
                    //here we want to bind GenderDDList,UserTypeDDList with DataBase 
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        string Query = "select * from Genders";
                        string Query2 = "select * from UserTypes";
                        SqlCommand cmd = new SqlCommand(Query, con);
                        SqlCommand cmd2 = new SqlCommand(Query2, con);
                        con.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            GenderDDList.Items.Add(new ListItem("--Select Gender", "0"));
                            while (rdr.Read())
                            {
                                ListItem item = new ListItem(rdr["GenderDesc"].ToString(), rdr["GenderId"].ToString());
                                GenderDDList.Items.Add(item);
                            }
                        }
                        using (SqlDataReader rdr2 = cmd2.ExecuteReader())
                        {
                            UserTypeDDList.Items.Add(new ListItem("--Select User Type","0"));
                            while (rdr2.Read())
                            {
                                UserTypeDDList.Items.Add(new ListItem(rdr2["TypeDesc"].ToString(), rdr2["TypeId"].ToString()));
                            }
                        }
                    }
                }
                catch
                {
                    Status.Text = "Something error occurred during display Gender or UserTypes in DDList.";
                }
            }
        }

        protected void AddUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (op.IsValueUnique(UserName.Text, "select * from Users", "username"))// here check if username is unique or not
                {
                    if (op.IsValueUnique(Email.Text, "select * from Users", "Email"))//here check if email is unique or not
                    {
                        if (GenderDDList.SelectedIndex != 0 && UserTypeDDList.SelectedIndex != 0)//here check if admin select Gender and UserType or not => so if selected it will execute the code that include if-statement else => if admin not selected both gender and usertype will execute the code include else-keyword
                        {
                            using (SqlConnection con = new SqlConnection(conStr))
                            {
                                string Query = "insert into Users values(@firstName,@lastName,@userName,@password,@email,@phoneNumber,@birthDate,@genderId,@userType)";
                                SqlCommand cmd = new SqlCommand(Query, con);
                                cmd.Parameters.AddWithValue("@firstName", FirstName.Text.ToLower());
                                cmd.Parameters.AddWithValue("@lastName", LastName.Text.ToLower());
                                cmd.Parameters.AddWithValue("@userName", UserName.Text.ToLower());
                                cmd.Parameters.AddWithValue("@password", Password.Text);
                                cmd.Parameters.AddWithValue("@email", Email.Text.ToLower());
                                cmd.Parameters.AddWithValue("@phoneNumber", PhoneNumber.Text);
                                cmd.Parameters.AddWithValue("@birthDate", BirthDate.Text);
                                cmd.Parameters.AddWithValue("@genderId", GenderDDList.SelectedValue.ToLower());
                                cmd.Parameters.AddWithValue("@userType", UserTypeDDList.SelectedValue.ToLower());

                                con.Open();
                                cmd.ExecuteNonQuery();
                                Response.Redirect("~/Pages/Admin/Users/Users.aspx");
                            }
                        }
                        else
                        {
                            Status.Text = "must be Specify both Gender and UserType.";
                        }
                    }
                    else
                    {
                        Status.Text = "The email is already exists,try on anouther email.";
                    }
                }
                else {
                    Status.Text = "The username is already exists,try on anouther username.";
                }
            }
            catch
            {
                Status.Text = "Something error occurred during Adding User.";
            }
        }
    }
}