using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectApp.Models
{
    public class UserProduct
    {
        public int ID { get; set; }
        public string UserID { get; set; } 
        public int ProductID { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Product Product { get; set; }
    }
}