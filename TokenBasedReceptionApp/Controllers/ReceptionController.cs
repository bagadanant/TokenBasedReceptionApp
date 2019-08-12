using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TokenBasedReception.ViewModel;
using TokenBasedReceptionApp.Helpers;

namespace TokenBasedReceptionApp.Controllers
{
    public class ReceptionController : Controller
    {
        WaitingQueueHelper queue = WaitingQueueHelper.Instance;

        // GET: Reception
        public ActionResult Index()
        {
            //ViewBag.AllQueue = queue.GetAll();

            return View();
        }


        //[HttpGet]
        //public ActionResult NewArrival()
        //{
        //    //ViewBag.AllQueue = queue.GetAll();

        //    return PartialView();
        //}

        [HttpPost]
        public JsonResult NewArrival(PatientViewModel model)
        {
            //var lastToken = queue.Peek;
            var arrivalToken = queue.LastToken + 1;

            queue.Arrival(arrivalToken);

            return Json(
                new { result = true, message = String.Format("Token number {0} added to queue", arrivalToken), token = arrivalToken },
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWaitingList()
        {
            var allElements = queue.GetAll();

            return Json(
                new { result = true, waitingList = allElements },
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetActionOnToken()
        {
            int currentToken = queue.InActionToken;

            return PartialView("_GetActionOnToken", new ActionTokenViewModel() { CurrentToken = currentToken });
        }

        public JsonResult Attended()
        {
           int attendedToken = queue.Attended();

            return Json(
                new { result = true, message = string.Format("Token {0} attended successfully.", attendedToken), token = attendedToken },
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult Unattended()
        {
            int unAttendedToken = queue.Unattended();

            return Json(
                new { result = true, message = string.Format("Token {0} unattended, added back to queue.", unAttendedToken), token = unAttendedToken },
                JsonRequestBehavior.AllowGet);
        }
    }
}