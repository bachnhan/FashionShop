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
        // GET: Account
        public ActionResult Login(string username, string password)
        {
            //AccountViewModel a = new AccountViewModel() {
            //    Username = username,
            //    Password = password            
            //};
            //AccountApi api = new AccountApi();
            //api.Create(a);
            SWDEntities db = new SWDEntities();
            var user = db.Accounts.Where(q => q.Username == username && q.Password == password);
            if(user != null)
            {
                return Redirect("/Home/Index");
            }
            return Content("Login failed");
        }
    }
}