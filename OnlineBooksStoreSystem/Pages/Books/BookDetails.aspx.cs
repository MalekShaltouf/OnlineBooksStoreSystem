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
    public partial class WebForm5 : System.Web.UI.Page
    {
        //public Books book = new Books();
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)// this check mean if the request type is Get Request so will execute the code that incelude this If-statement
            {
                if (Session["UserName"] != null)
                {
                    if (Request.QueryString["id"] != null) //if user enter BookDetails Page without enter BookId will return user to Home Page
                    {
                        using (SqlConnection con = new SqlConnection(conStr))
                        {
                            int BookId = int.Parse(Request.QueryString["id"].ToString());
                            string query = "select * from Books inner join categories on Books.CategoryId = categories.Category_Id where BookId = @Id";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@Id", BookId);
                            con.Open();
                            using (SqlDataReader rdr = cmd.ExecuteReader())
                            {
                                if(rdr.Read())
                                {
                                    Subject.Text = rdr["Subject"].ToString();
                                    BookTitle.Text = rdr["BookTitle"].ToString();
                                    Author.Text = rdr["Author"].ToString();
                                    PublishDate.Text = rdr["PublishDate"].ToString();
                                    PublishingHouse.Text = rdr["PublishingHouse"].ToString();
                                    QuantityInStore.Text = rdr["QuantityInStore"].ToString();
                                    Description.Text = rdr["Description"].ToString();
                                    CategoryName.Text = rdr["CategoryName"].ToString();
                                    Price.Text = rdr["Price"].ToString();
                                    BookImage.ImageUrl = rdr["CoverImagePath"].ToString();
                                    /*
                                     * here we want to check if user want Details Page or Delete Page
                                     */
                                    if (Session["Status"] != null) // here if user want delete Page so will execute the code that include if-statement else => if user want Details Page so will execute the code that include else-keyword
                                    {
                                        Session.Remove("Status");
                                        DeleteBtn.Visible = true;
                                        BuyBtn.Visible = false;
                                    }
                                    else {
                                        DeleteBtn.Visible = false;
                                        BuyBtn.Visible = true;
                                    }
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

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    string Query = "delete from Books where BookId = @bookId";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@bookId", Request.QueryString["id"]);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("~/Pages/Books/Books.aspx");
            }
            }
            catch {
                Status.Text = "Something error occurred during delete this book.";
            }
        }
    }
}
