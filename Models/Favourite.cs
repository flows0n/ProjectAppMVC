using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectApp.Models
{
    public class Favourite
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int UserProductID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual UserProduct UserProduct { get; set; }
    }
}