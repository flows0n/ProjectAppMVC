using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectApp.Models
{
    public class Keyword
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<KeywordCategory> KeywordsCategories { get; set; }

    }
}