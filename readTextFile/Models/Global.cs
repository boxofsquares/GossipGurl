using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace readTextFile.Models
{
    public static class Global
    {
        public static List<customModel> obj = JsonConvert.DeserializeObject<List<customModel>>(System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/json.json")));
    }
}