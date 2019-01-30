using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KISSG.Templates.OnePageSite;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KISSG.Controllers
{
    public class SiteGeneratorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("SSiteGen");
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(welcome w)
        {
            string cont=w.TransformText();
            System.IO.File.WriteAllText("outputPage.html", cont);
            return View("SSiteGen");
        }
    }
}