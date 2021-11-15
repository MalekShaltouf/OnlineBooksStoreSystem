using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBooksStoreSystem.Models
{
    public class Books
    {
        public int BookId { get; set; }
        public string Subject { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public string PublishingHouse { get; set; }
        public double QuantityInStore { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string CategoryName { get; set; }

    }
}