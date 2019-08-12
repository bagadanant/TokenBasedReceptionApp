using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TokenBasedReceptionApp.Controllers
{
    public class WaitingListController : Controller
    {
        // GET: WaitingList
        public ActionResult Index()
        {
            return View();
        }
    }
}