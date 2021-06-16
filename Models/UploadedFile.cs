using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectApp.Models
{
    public class UploadedFile
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}