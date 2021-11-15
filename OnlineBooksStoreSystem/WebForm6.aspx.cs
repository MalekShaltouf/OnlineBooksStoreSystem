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
    public partial class WebForm6 : System.Web.UI.Page
    {
        public List<Books> list = new List<Books>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                //SqlCommand cmd = new SqlCommand("select * from Books",con);
                SqlCommand cmd = new SqlCommand("select * from Books inner join categories on Books.CategoryId = categories.Category_Id", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    Books book = new Books();
                    book.Subject = rdr["Subject"].ToString();
                    book.Author = rdr["Author"].ToString();
                    book.BookTitle = rdr["BookTitle"].ToString();
                    book.CategoryName = rdr["CategoryName"].ToString();
                    list.Add(book);
                }

            }
        }
    }
}