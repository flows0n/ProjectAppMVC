using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectApp.Models
{
    public class KeywordCategory
    {
        public int ID { get; set; }

        public int WordID { get; set; }
        public int CategoryID { get; set; }
        public virtual Keyword Keyword { get; set; }
        public virtual Category Category { get; set; }
    }
}