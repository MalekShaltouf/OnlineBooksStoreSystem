using OnlineBooksStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBooksStoreSystem
{
    public partial class WebForm13 : System.Web.UI.Page
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
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        string Query = "select * from categories";
                        SqlCommand cmd = new SqlCommand(Query, con);
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        CategoryNameDDList.Items.Add(new ListItem("--Select CategoryName", "0"));
                        while (rdr.Read())
                        {
                            ListItem item = new ListItem(rdr["CategoryName"].ToString(), rdr["Category_Id"].ToString());
                            CategoryNameDDList.Items.Add(item);
                        }
                    }
                }
                catch {
                    Status.Text = "Something error occurred during display CategoryName in DDList.";
                }
                
            }
        }

        protected void AddBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (file.HasFile)//this check => mean if the user choose file so will execute the code that include if-statement else => will return label "must be upload Image"
                {
                    string ImagePath = "~/Images/BooksImage/" + file.FileName;
                    if (!op.IsFileImage(file.FileName)) // this check mean => if the user not upload image such as: video,pdf,sound,.. so will execute the code include if-statement else => if user upload img so will execute the code that include else-keyword
                    {
                        Status.Text = "Just image allowed to upload.";
                    }
                    else
                    {
                        if (CategoryNameDDList.SelectedIndex != 0) // here check if user choose CategoryName or not => so if selected it will execute the code that include if-statement else => if admin not selected CategoryName will execute the code include else-keyword
                        {
                            using (SqlConnection con = new SqlConnection(conStr))
                            {
                                string Query = "insert into Books values(@subject,@bookTitle,@author,@publishDate,@PublishingHouse,@bookQuantity,@imagePath,@description,@price,@categoryId)";
                                SqlCommand cmd = new SqlCommand(Query, con);
                                cmd.Parameters.AddWithValue("@subject", Subject.Text.ToLower());
                                cmd.Parameters.AddWithValue("@bookTitle", BookTitle.Text.ToLower());
                                cmd.Parameters.AddWithValue("@author", Author.Text.ToLower());
                                cmd.Parameters.AddWithValue("@publishDate", PublishDate.Text);
                                cmd.Parameters.AddWithValue("@PublishingHouse", PublishingHouse.Text.ToLower());
                                cmd.Parameters.AddWithValue("@bookQuantity", BookQuantity.Text);
                                cmd.Parameters.AddWithValue("@imagePath", ImagePath);
                                cmd.Parameters.AddWithValue("@description", Description.InnerText.ToLower());
                                cmd.Parameters.AddWithValue("@price", Price.Text);
                                cmd.Parameters.AddWithValue("@categoryId", CategoryNameDDList.SelectedValue.ToLower());

                                file.SaveAs(Server.MapPath(ImagePath));
                                con.Open();
                                cmd.ExecuteNonQuery();
                                Response.Redirect("~/Pages/Books/Books.aspx");
                            }
                        }
                        else
                        {
                            Status.Text = "must select Category Name.";
                        }
                        
                    }
                }
                else
                {
                    Status.Text = "Please Upload Book Image.";
                }
            }
            catch
            {
                Status.Text = "Something error occurred during Add Book.";
            }
        }
    }
}