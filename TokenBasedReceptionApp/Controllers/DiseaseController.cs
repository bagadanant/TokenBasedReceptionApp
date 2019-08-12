using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TokenBasedReception.Core.Entity;
using TokenBasedReception.Service;
using TokenBasedReception.ViewModel;

namespace TokenBasedReceptionApp.Controllers
{
    public class DiseaseController : Controller
    {
        private IDiseaseService diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            this.diseaseService = diseaseService;
        }

        // GET: Disease
        public ActionResult Index()
        {
            var records = diseaseService.GetDiseases().ToList();
            List<DiseaseViewModel> diseases = Mapper.Map<List<Disease>, List<DiseaseViewModel>>(records);

            return View(diseases);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DiseaseViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddedOn = DateTime.UtcNow;
                model.ModifiedOn = DateTime.UtcNow;
                var newDisease = Mapper.Map<DiseaseViewModel, Disease>(model);
                diseaseService.InsertDisease(newDisease);
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            // fetch record 

            return View(new DiseaseViewModel());
        }

        [HttpPost]
        public ActionResult Edit(DiseaseViewModel model)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            //soft delete record

            return View();
        }

    }
}