using Insus.NET.Entities;
using Insus.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insus.NET.Controllers
{
    public class KindController : Controller
    {
        FruitKindEntity objFruitKindEntity = new FruitKindEntity();

        //
        // GET: /Kind/
        public ActionResult Index()
        {
            var model = objFruitKindEntity.GetAllFruitKind();
            return View(model);
        }

        public ActionResult Details(FruitKind fk)
        {
            return View(fk);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FruitKind fk)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", fk);
            }

            objFruitKindEntity.Insert(fk);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(byte fruitKind_nbr)
        {
            var model = objFruitKindEntity.GetFruitKindByPrimaryKey(fruitKind_nbr);

            if (model == null)
            {
                return HttpNotFound();
            }

            var objFruitKind = model.Find(o => o.FruitKind_nbr == fruitKind_nbr);

            return View(objFruitKind);
        }

        [HttpPost]
        public ActionResult Edit(FruitKind fk)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", fk);
            }

            objFruitKindEntity.Update(fk);

            return RedirectToAction("Edit", fk);
        }

        public ActionResult Delete(byte fruitKind_nbr)
        {
            var model = objFruitKindEntity.GetFruitKindByPrimaryKey(fruitKind_nbr);

            if (model == null)
            {
                return HttpNotFound();
            }

            var objFruitKind = model.Find(o => o.FruitKind_nbr == fruitKind_nbr);

            return View(objFruitKind);
        }

        [HttpPost]
        public ActionResult Delete(FruitKind fk)
        {
            objFruitKindEntity.Delete(fk);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetJsonFruit(byte? fruitCategory_nbr)
        {
            var model = objFruitKindEntity.SelectLists(fruitCategory_nbr);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetServiceData()
        {
            return View();
        }

        public ActionResult PostDataToService()
        {
            return View();
        }

        public ActionResult UpdateDataToService()
        {
            return View();
        }
    }
}