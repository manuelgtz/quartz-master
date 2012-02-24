using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuartzMaster.Base;

namespace QuartzMaster.Controllers
{
    public class JobsController : BaseController
    {
        public ActionResult List(string id)
        {
            return View();
        }

    }
}
