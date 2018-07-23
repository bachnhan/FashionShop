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
    public class OrderDetailsController : Controller
    {
        // GET: OrderDetails
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetOrderDetails(int orderID)
        {
            OrderDetailApi orderApi = new OrderDetailApi();
            IEnumerable<OrderDetailViewModel> result = orderApi.GetActiveWithProductByOrderId(orderID);

            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            //return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}