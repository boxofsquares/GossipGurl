using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Newtonsoft.Json;
using readTextFile.Models;

namespace readTextFile.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //List<customModel> obj = JsonConvert.DeserializeObject<List<customModel>>(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/json.json")));
            return View(Global.obj);
        }

        [HttpGet]
        public ActionResult Create()
        {
            customModel blog = new customModel { timestamp = DateTime.Now };
            return View(blog);
        }

        [HttpPost]
        public ActionResult Create(customModel model)
        {
            //List<customModel> obj = JsonConvert.DeserializeObject<List<customModel>>(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/json.json")));
            Global.obj.Insert(0, model);

            SerializeBlogJson(Global.obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Password()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Password(Credentials creds)
        {
            if (creds.username.Trim() == "username" && creds.pw.Trim() == "password")
            {
                return RedirectToAction("ChooseOption");
            }
            return RedirectToAction("Index");
        }
        public ActionResult ChooseOption()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChooseOption(string option)
        {
            if (option == "Create New")
            {
                return RedirectToAction("Create");
            }
            return RedirectToAction("EditDelete");
        }

        public ActionResult EditDelete()
        {
            //List<customModel> obj = JsonConvert.DeserializeObject<List<customModel>>(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/json.json")));

            return View(Global.obj);
        }

        public ActionResult Delete(string title)
        {
            //List<customModel> obj = JsonConvert.DeserializeObject<List<customModel>>(System.IO.File.ReadAllText(Server.MapPath("~/App_Data/json.json")));
            Global.obj.Remove(Global.obj.First(r => r.title == title));
            SerializeBlogJson(Global.obj);
            return RedirectToAction("Index");
        }

        public PartialViewResult AddComment(customModel model, string addedComment)
        {
            model = Global.obj.Find(m => m.title == model.title);
            model.comments.Add(addedComment);
            //notadded to model yet
            SerializeBlogJson(Global.obj);
            //ModelState is passed instead of model (call to same view somehow always does that)
            ModelState.Clear();
            return PartialView("Blog", model);
        }

        //Helper Methods
        public void SerializeBlogJson(List<customModel> obj)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(HttpContext.Server.MapPath("~/App_Data/json.json")))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, obj);
                }
            }
        }
    }

}