using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectApp.Models
{
    public class AdminMessage
    {
        public int ID { get; set; }
        [Display(Name = "Wiadomość")]
        [DataType(DataType.MultilineText)]
        public string message { get; set; }
    }
}