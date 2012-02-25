using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.Mvc;
using QuartzMaster.Data.QuartzRemoting;
using QuartzMaster.Base;
using QuartzMaster.Data.Models;
using System.Collections;
using QuartzMaster.Models;

namespace QuartzMaster.Controllers
{    
    public class OverviewController : BaseController
    {       
        public OverviewController() : base()
        {            
        }

        public ActionResult ClearSchedulerSelection()
        {
            Session.Remove(Constants.SchedulerInstanceKey);
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            if (!Session.KeyExists(Constants.SchedulerInstanceKey))
                return View(RemoteSchedulerRepository.Instance.SchedulersInfo);
            else
                return RedirectToAction("Dashboard", new { id = Session[Constants.SchedulerInstanceKey] });
        }

        public ActionResult Dashboard(string id,bool changeSelection = false)
        {           
            if (!Session.KeyExists(Constants.SchedulerInstanceKey))
            {
                Session[Constants.SchedulerInstanceKey] = id;
            }

            var dashboardModel = new DashboardModel(id);

            return View(dashboardModel);
        }

    }
}
