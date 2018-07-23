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
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllSupplier()
        {
            SupplierApi supplierApi = new SupplierApi();
            List<SupplierViewModel> result = supplierApi.GetActive();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}