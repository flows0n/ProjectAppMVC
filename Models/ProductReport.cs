using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectApp.Models
{
    public class ProductReport
    {
        public int ID { get; set; }
        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public int productID { get; set; }
        public Product product { get; set; }
    }
}