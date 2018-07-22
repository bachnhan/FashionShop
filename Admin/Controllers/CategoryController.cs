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
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllCategories()
        {
            ProductCategoryApi categoryApi = new ProductCategoryApi();
            List<ProductCategoryViewModel> result = categoryApi.GetActive();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}