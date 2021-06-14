using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Zdjęcie")]
        public byte[] Image { get; set; }
        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Stan produktu")]
        public ConditionName? Condition { get; set; }
        [Display(Name = "Cena")]
        public int Price { get; set; }
        [Display(Name = "Liczba polubionych")]
        public int FavoriteCount { get; set; }
        [Display(Name = "Liczba odwiedzin")]
        public int VisitCount { get; set; }
        [Display(Name = "Kategoria")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
