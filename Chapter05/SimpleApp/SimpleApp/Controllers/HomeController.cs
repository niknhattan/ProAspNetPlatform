﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ApplicationModel am = new ApplicationModel()
            {
                Events = HttpContext.Application["events"] as List<string>,
                TimeStamps = GetTimeStamps()
            };
            
            return View(am);
        }

        [HttpPost]
        public ActionResult Index(Color color) 
        {
            Color? oldColor = Session["color"] as Color?;
            if (oldColor != null)
            {
                Votes.ChangeVote(color, (Color)oldColor);
            }
            else 
            {
                Votes.RecordVote(color);
            }

            ViewBag.SelectedColor = Session["color"] = color;

            ApplicationModel am = new ApplicationModel()
            {
                Events = HttpContext.Application["events"] as List<string>,
                TimeStamps = GetTimeStamps()
            };

            return View(am);
        }

        public ActionResult Modules() 
        {
            var modules = HttpContext.ApplicationInstance.Modules;
            Tuple<string, string>[] data = modules.AllKeys
                .Select(x =>
                    new Tuple<string, string>(x.StartsWith("__Dynamic") ? x.Split('_', ',')[3] : x,
                        modules[x].GetType().Name)
                    )
                    .OrderBy(x => x.Item1)
                    .ToArray();
            return View(data);
                   
        }

        private List<String> GetTimeStamps() 
        {
            return new List<string>()
            {
                string.Format("App timestamp: {0}",
                    HttpContext.Application["app_timestamp"]),
                string.Format("Request_timestamp: {0} ",
                    Session["request_timestamp"])
            };
        }
    }
}