using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Models;
using HmsService.ViewModels;
using HmsService.Sdk;
using HmsService.Models.Entities;

namespace Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllProducts()
        {
            ProductApi productApi = new ProductApi();
            List<ProductViewModel> result = productApi.GetActive().Where(q => q.ParentProductId != null).ToList();
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
    }
}