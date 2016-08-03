using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insus.NET.Models;
using Insus.NET.Entities;

namespace Insus.NET.Controllers
{
    public class CategoryController : Controller
    {
        FruitCategoryEntity objFruitCategoryEntity = new FruitCategoryEntity();
        IEnumerable<FruitCategory> model = null;

        //
        // GET: /Category/
        public ActionResult Index()
        {
            model = objFruitCategoryEntity.GetAllFruitCategory();

            return View(model);
        }

        public ActionResult Details(byte fruitCategory_nbr = 0)
        {
            model = objFruitCategoryEntity.GetFruitCategoryByPrimaryKey(fruitCategory_nbr);

            FruitCategory fc = new FruitCategory();

            foreach (var fc1 in model)
            {
                if (fc1.FruitCategory_nbr == fruitCategory_nbr)
                {
                    fc.FruitCategory_nbr = fc1.FruitCategory_nbr;
                    fc.CategoryName = fc1.CategoryName;
                }
            }

            return View(fc);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FruitCategory fc)
        {
            if (ModelState.IsValid)
            {
                objFruitCategoryEntity.Insert(fc);

                return RedirectToAction("Index");
            }
            else
            {
                return View(fc);
            }
        }

        public ActionResult Edit(byte fruitCategory_nbr = 0)
        {
            model = objFruitCategoryEntity.GetFruitCategoryByPrimaryKey(fruitCategory_nbr);

            if (model == null)
            {
                return HttpNotFound();
            }

            FruitCategory fc = new FruitCategory();

            foreach (var fc1 in model)
            {
                if (fc1.FruitCategory_nbr == fruitCategory_nbr)
                {
                    fc.FruitCategory_nbr = fc1.FruitCategory_nbr;
                    fc.CategoryName = fc1.CategoryName;
                }
            }

            return View(fc);
        }

        [HttpPost]
        public ActionResult Edit(FruitCategory fc)
        {
            if (ModelState.IsValid)
            {
                objFruitCategoryEntity.Update(fc);

                return RedirectToAction("Edit", fc);
            }
            else
            {
                return View(fc);
            }
        }

        public ActionResult Delete(byte fruitCategory_nbr = 0)
        {
            model = objFruitCategoryEntity.GetFruitCategoryByPrimaryKey(fruitCategory_nbr);

            FruitCategory fc = new FruitCategory();

            foreach (var fc1 in model)
            {
                if (fc1.FruitCategory_nbr == fruitCategory_nbr)
                {
                    fc.FruitCategory_nbr = fc1.FruitCategory_nbr;
                    fc.CategoryName = fc1.CategoryName;
                }
            }
            return View(fc);
        }

        [HttpPost]
        public ActionResult Delete(FruitCategory fc)
        {
            objFruitCategoryEntity.Delete(fc);

            return RedirectToAction("Index");
        }

        public JsonResult GetJsonCategory()
        {
            var model = objFruitCategoryEntity.SelectLists();

            return Json(model, JsonRequestBehavior.AllowGet);
        }       
    }
}


