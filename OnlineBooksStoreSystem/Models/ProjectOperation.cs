using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace OnlineBooksStoreSystem.Models
{
    public class ProjectOperation
    {
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        /*
            this(IsValueUnique) function check for any value if unique or not =>so
            just must pass the value that want to check if unique or not and sql Query
        */
        public bool IsValueUnique(string value, string Query, string valueType) //the value can be UserName or Email
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd2 = new SqlCommand(Query, con);
                con.Open();
                SqlDataReader rdr = cmd2.ExecuteReader();
                while (rdr.Read())
                {
                    if (valueType.ToLower() == "username")
                    {
                        if (value.ToLower() == rdr["UserName"].ToString())
                        {
                            return false;
                        }
                    }
                    else if (valueType.ToLower() == "email")
                    {
                        if (value.ToLower() == rdr["Email"].ToString())
                        {
                            return false;
                        }
                    }
                    else if (valueType.ToLower() == "categoryname") {

                         if (value.ToLower() == rdr["CategoryName"].ToString())
                         {
                             return false;
                         }
                    }

                }
                return true;
            }
        }
        public bool IsUserAdmin(string UserName) {
            using (SqlConnection con = new SqlConnection(conStr)) {
                string Query = "select UserTypes.TypeDesc from Users inner join UserTypes on Users.UserType = UserTypes.TypeId Where Users.UserName = @username";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@username", UserName);
                con.Open();
                string UserType = cmd.ExecuteScalar().ToString();

                return (UserType == "admin");
            }   
        }
        public bool IsFileImage(string FileName) {
            string[] ImageExtention = { ".jpg", ".png", "jpeg" };
            string fileExtention = Path.GetExtension(FileName).ToLower();

            return ImageExtention.Any(img => img == fileExtention);
        }
    }
}