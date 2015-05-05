using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace readTextFile.Models
{
    public class Credentials
    {
        [Display(Name="Username"), Required]
        public string username { get; set; }
        [Display(Name="Password"), Required]
        [DataType(DataType.Password)]
        public string pw { get; set; }
    }
}