using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectApp.Models
{
    public class UserProduct
    {
        public int ID { get; set; }
        public int UserID { get; set; } 
        public int ProductID { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime EndDate { get; set; }
        public int FavouriteCount { get; set; }
        public int VisitCount { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Product Product { get; set; }
    }
}