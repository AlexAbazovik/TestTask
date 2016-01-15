using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;
using TestTask.Models.Repository;

namespace TestTask.Controllers
{
    public class ProductController : Controller
    {
        private IRepository _repository;

        public ProductController(IRepository rep)
        {
            _repository = rep;
        }

        public ActionResult Index()
        {
            return View(_repository.Products);
        }

        public ActionResult Add()
        {
            return View(_repository.AddProduct());
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.saveProduct(product);
                return RedirectToAction("Index");
            }
            else        
            {
                ViewBag.tempName = Request.Form["Name"];
                ViewBag.tempQuantity = Request.Form["Quantity"];
                ViewBag.tempBarcode = Request.Form["Barcode"];
                return View(product);
            }
        }

        public ActionResult Delete(int id)
        {
            if (Request.IsAjaxRequest())
            {
                _repository.deleteProduct(id);
                return PartialView("_ListAjax", _repository.Products);
            }
            else return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.tempName = _repository.Products.Where(p => p.ID == id).Select(p => p).First().Name;
            ViewBag.tempQuantity = _repository.Products.Where(p => p.ID == id).Select(p => p).First().Quantity;
            ViewBag.tempBarcode = _repository.Products.Where(p => p.ID == id).Select(p => p).First().Barcode;
            _repository.deleteProduct(id);
            return View("Add");
        }
    }
}
