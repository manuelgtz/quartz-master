using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuartzMaster.Base;
using QuartzMaster.Models;

namespace QuartzMaster.Controllers
{
    public class TriggersController : BaseController
    {
        public ActionResult List(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction("List","Overview");
            }
            
            TriggersModel model = new TriggersModel(id);
            return View(model);
        }



        [HttpPost]
        public ActionResult Create(FormCollection TriggerData)
        {            
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}
