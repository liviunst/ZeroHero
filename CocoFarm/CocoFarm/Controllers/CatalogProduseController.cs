using CocoFarm.DataAccess;
using CocoFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CocoFarm.Controllers
{
    //commm 
    public class CatalogProduseController : Controller
    {
        private IDataStore<Produs> store = new MemoryDataStore<Produs>();
        private IDataStore<Proprietate> propList = new MemoryDataStore<Proprietate>();

        public ActionResult AddPropToProd(int id)
        {
            IEnumerable<Proprietate> proprietati = propList.GetAll();
            ViewData["proprietate"] = proprietati;

            var model = new ProprietateValoare();
            model.ProdusId = id;

            return View(model);
            //return View();
        }

        [HttpPost]
        public ActionResult AddPropToProd(ProprietateValoare model)
        {
            // luam produsul, ii adaugam proprietatea, salvam produsul

            var produs = store.GetById(model.ProdusId + 1);
            produs.ProprietatiProdus.Add(model);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            IEnumerable<Produs> produse = store.GetAll();
            return View(produse);
        }

        public ActionResult IndexProp()
        {
            IEnumerable<Proprietate> proprietati = propList.GetAll();
            return View(proprietati);
        }

        public ActionResult Details(int id)
        {
            var produs = store.GetById(id);
            return View(produs);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddProp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProp(Proprietate total)
        {
            try
            {
                propList.Create(total);
                return RedirectToAction("IndexProp");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(Produs produs)
        {
            try
            {
                produs.ProprietatiProdus = new Proprietati();
                store.Create(produs);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var produs = store.GetById(id);
            return View(produs);
        }

        [HttpPost]
        public ActionResult Edit(Produs produs)
        {
            try
            {
                store.Update(produs);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(produs);
            }
        }

        public ActionResult Delete(int id)
        {
            var produs = store.GetById(id);
            return View(produs);
        }

        [HttpPost]
        public ActionResult Delete(Produs produs)
        {
            try
            {
                store.Delete(produs.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
