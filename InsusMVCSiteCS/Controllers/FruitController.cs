using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insus.NET.Entities;
using Insus.NET.Models;

namespace Insus.NET.Controllers
{
    public class FruitController : Controller
    {
        FruitEntity objFruitEntity = new FruitEntity();

        //
        // GET: /Fruit/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllFuritData()
        {
            var model = objFruitEntity.GetAllFruit();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details()
        {
            return View();
        }

        public JsonResult GetFruitDataByPrimaryKey(byte? fruit_nbr)
        {
            var dataFruit = objFruitEntity.GetFruitByPrimarykey(fruit_nbr);
            return Json(dataFruit, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Fruit objFruit)
        {
            objFruitEntity.Insert(objFruit);

            return Json(objFruit, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(Fruit objFruit)
        {
             objFruitEntity.Update(objFruit);
          
            return Json(objFruit, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(Fruit objFruit)
        {
            objFruitEntity.Delete(objFruit);
          
            return Json(objFruit, JsonRequestBehavior.AllowGet);
        }       


    }
}

