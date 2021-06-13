using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectApp.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Kategoria")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<WordCategory> WordsCategories { get; set; }
    }
}