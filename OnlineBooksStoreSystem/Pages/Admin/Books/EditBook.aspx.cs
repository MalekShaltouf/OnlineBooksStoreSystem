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
    public partial class WebForm14 : System.Web.UI.Page
    {
        ProjectOperation op = new ProjectOperation();
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null || Request.QueryString["catName"] != null)//this check mean => if user enter this page without enter id and Category Name so will redirect to Home Page
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
                    try
                    {
                        using (SqlConnection con = new SqlConnection(conStr))
                        {
                            string Query = "select * from Books where BookId = @bookId";
                            string Query2 = "select * from categories";
                            SqlCommand cmd = new SqlCommand(Query, con);

                            cmd.Parameters.AddWithValue("@bookId", Request.QueryString["id"]);

                            con.Open();
                            using (SqlDataReader rdr = cmd.ExecuteReader())
                            {
                                SqlCommand cmd2 = new SqlCommand(Query2, con);
                                SqlDataReader rdr2 = cmd2.ExecuteReader();
                                if (rdr.Read())
                                {
                                    Subject.Text = rdr["Subject"].ToString();
                                    BookTitle.Text = rdr["BookTitle"].ToString();
                                    Author.Text = rdr["Author"].ToString();
                                    PublishDate.Text = ((DateTime)rdr["PublishDate"]).ToString("yyyy-MM-dd"); //here => if we store value for input[type='date'] in value attribue so must the date format should be yyyy-MM-dd in order to display in input[type='date']
                                    PublishingHouse.Text = rdr["PublishingHouse"].ToString();
                                    BookQuantity.Text = rdr["QuantityInStore"].ToString();
                                    Description.InnerText = rdr["Description"].ToString();
                                    Price.Text = rdr["Price"].ToString();
                                    int index = 0;
                                    CategoryNameDDList.Items.Add(new ListItem("--Select Category Nmae", "0"));
                                    while (rdr2.Read())
                                    {
                                        ListItem list ;
                                        if (rdr["CategoryId"].ToString() == rdr2["Category_Id"].ToString())
                                        {
                                            list = new ListItem(rdr2["CategoryName"].ToString(), rdr2["Category_Id"].ToString());
                                            index = int.Parse(rdr2["Category_Id"].ToString());//this index represent the index for the item that user want to do updating
                                        }
                                        else
                                        {
                                            list = new ListItem(rdr2["CategoryName"].ToString(), rdr2["Category_Id"].ToString());
                                        }
                                        CategoryNameDDList.Items.Add(list);
                                    }
                                    CategoryNameDDList.SelectedIndex = index;
                                }
                            }
                        }
                    }
                    catch
                    {
                        Status.Text = "Something error during occurred during Edit Book.";
                    }
                }
                else
                {
                    Response.Redirect("~/Pages/Home/Home.aspx");
                }
            }
        }

        protected void EditBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (CategoryNameDDList.SelectedIndex != 0)// here check if user choose CategoryName or not => so if selected it will execute the code that include if-statement else => if admin not selected CategoryName will execute the code include else-keyword
                {
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        /*
                         * we put the SqlCommand and give it Parameter value in order write SqlCommand one time.
                         */
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        string Query = null;
                        cmd.Parameters.AddWithValue("@bookId", Request.QueryString["id"]);
                        cmd.Parameters.Add(new SqlParameter("subject", Subject.Text.ToLower()));
                        cmd.Parameters.AddWithValue("@bookTitle", BookTitle.Text.ToLower());
                        cmd.Parameters.AddWithValue("@author", Author.Text.ToLower());
                        cmd.Parameters.AddWithValue("@publishDate", PublishDate.Text);
                        cmd.Parameters.AddWithValue("@publishingHouse", PublishingHouse.Text.ToLower());
                        cmd.Parameters.AddWithValue("@quantityInStore", BookQuantity.Text);
                        cmd.Parameters.AddWithValue("@description", Description.InnerText.ToLower());
                        cmd.Parameters.AddWithValue("@price", Price.Text);
                        cmd.Parameters.AddWithValue("@categoryId", CategoryNameDDList.SelectedValue.ToLower());

                        if (file.HasFile) // if admin upload image that mean => that admin want to update Book Image 
                        {
                            if (op.IsFileImage(file.FileName)) // check if admin upload image not video,sound,pdf,...
                            {
                                string ImagePath = "~/Images/BooksImage/" + file.FileName;
                                Query = "update Books set Subject = @subject,BookTitle = @bookTitle,Author = @author,PublishDate = @publishDate,PublishingHouse = @publishingHouse,QuantityInStore = @quantityInStore,CoverImagePath = @ImagePath,Description = @description,Price = @price,CategoryId = @categoryId where BookId =@bookId"; // this query update all Books column with Image file
                                cmd.CommandText = Query;
                                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
                                file.SaveAs(Server.MapPath(ImagePath));
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                Response.Redirect("~/Pages/Books/Books.aspx");
                            }
                            else
                            {
                                Status.Text = "Just can be Upload Book Image.";
                            }
                        }
                        else // if admin not upload image that mean => that admin does not want to update image
                        {
                            Query = "update Books set Subject = @subject,BookTitle = @bookTitle,Author = @author,PublishDate = @publishDate,PublishingHouse = @publishingHouse,QuantityInStore = @quantityInStore,Description = @description,Price = @price,CategoryId = @categoryId where BookId = @bookId";//this query update all Books column without update Image file
                            cmd.CommandText = Query;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Response.Redirect("~/Pages/Books/Books.aspx");
                        }
                    }
                }
                else
                {
                    Status.Text = "must be specify the category name.";
                }
            }
            catch
            {
                Status.Text = "Something error occurred during Updating data.";
            }
        }
    }
}