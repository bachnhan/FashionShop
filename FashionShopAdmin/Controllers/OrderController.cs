using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Models;
using HmsService.ViewModels;
using HmsService.Sdk;
using HmsService.Models.Entities;

namespace FashionShopAdmin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllOrders()
        {
            OrderApi orderApi = new OrderApi();
            List<OrderViewModel> result = orderApi.GetActive().ToList();
            return Json(new { data = result}, JsonRequestBehavior.AllowGet);
        }
    }
}