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
            List<OrderViewModel> result = orderApi.Get().ToList();
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateStaus(int Status, int ID)
        {
            OrderApi orderApi = new OrderApi();
            var order = orderApi.Get().Where(q => q.ID == ID).FirstOrDefault();
            if (order != null)
            {
                order.Status = Status;
                try
                {
                    orderApi.Edit(ID,order);
                    return Json(new { success = true, message = "Successfully updated!" }, JsonRequestBehavior.AllowGet);
                }
                catch(Exception e)
                {
                    return Json(new { success = false, message = "Update failed!" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = "Update failed!" }, JsonRequestBehavior.AllowGet);
        }
    }
}