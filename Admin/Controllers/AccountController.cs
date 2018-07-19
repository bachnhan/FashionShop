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
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: Account/Login
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            //AccountViewModel a = new AccountViewModel() {
            //    Username = username,
            //    Password = password            
            //};
            //AccountApi api = new AccountApi();
            //api.Create(a);
            AccountApi accountapi = new AccountApi();
            var result = accountapi.Get().Where(q => q.Username == username && q.Password == password);
            if(result != null)
            {
                return RedirectToAction("Index","Home");
            }
            return Content("Login failed");
        }
    }
}