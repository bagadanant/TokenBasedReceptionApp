using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TokenBasedReception.Core.Entity;
using TokenBasedReception.Service;
using TokenBasedReception.ViewModel;

namespace TokenBasedReceptionApp.Controllers
{
    public class PatientController : Controller
    {
        private IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        //// GET: Patient
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult Add()
        //{
        //    var patient = new PatientViewModel();
        //    return PartialView(patient);
        //}

        //[HttpPost]
        //public ActionResult Add(PatientViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return Json(
        //         new { result = true },
        //         JsonRequestBehavior.AllowGet);
        //    }

        //    return Json(
        //         new { result = false },
        //         JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Create()
        {
            return View(new PatientViewModel());
        }

        [HttpPost]
        public ActionResult Create(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var patient = AutoMapper.Mapper.Map<PatientViewModel, Patient>(model);
                patient.ModifiedOn = patient.AddedOn = DateTime.UtcNow;

                patientService.InsertPatient(patient);
            }

            return View();
        }

        public ActionResult Search()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Search(SearchPatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var patients = patientService.SearchPatient(model.Keyword).ToList();

                if(patients != null && patients.Count > 0)
                    return Json(
                        new { result = true, records = patients },
                        JsonRequestBehavior.AllowGet);
            }

            return Json(
                new { result = false, message = "Provide keyword to search for"},
                JsonRequestBehavior.AllowGet);
        }


        private string ConvertViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }
    }
}