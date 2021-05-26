using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectApp.Models
{
    public class Product
    {
        public enum ConditionName
        {
            New,
            Used
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ConditionName Condition { get; set; }
        public int Price { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
