using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Web.Mvc;


namespace readTextFile.Models
{
    public class customModel
    {   
        [Display(Name="Title"), Required]
        public string title { get; set; }
        [Display(Name="Content"), Required]
        public string content { get; set; }
        public DateTime timestamp { get;set; }
        public List<string> comments { get; set; }
        public int id { get; set; }

        public customModel()
        {
            comments = new List<string>();
        }

       
    }
}