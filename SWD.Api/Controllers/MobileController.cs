using Facebook;
using HmsService.Models;
using HmsService.Sdk;
using HmsService.ViewModels;
using Jose;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SWD.Api.Controllers
{
    public class MobileController : Controller
    {
        private const string privateKey = ConstantManager.PRIVATE_KEY;
        private static byte[] secretKey = Encoding.UTF8.GetBytes(privateKey);

        // GET: Mobile
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoginByFacebook(string fbAccessToken)
        {
            var customerApi = new CustomerApi();
            //Get Facebook client profile by accessToken
            var fb = new FacebookClient();
            fb.AccessToken = fbAccessToken;
            dynamic me = fb.Get("me?fields=id,name,gender,email,birthday");
            string fbEmail = me.email;
            string fbName = me.name;
            bool? fbGender = null;
            if (me.gender == "male")
            {
                fbGender = true;
            }
            else if (me.gender == "female")
            {
                fbGender = false;
            }
            DateTime fbBirthday = new DateTime();
            if (me.birthday != null)
            {
                fbBirthday = DateTime.ParseExact(me.birthday, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            }

            //Check Cusomter Facebook email exitested
            var customer = customerApi.Get().Where(q => q.fbEmail.Equals(fbEmail)).FirstOrDefault();
            if (customer != null)
            {
                //Check customer membershipcard
                customerApi.Edit(customer.ID,customer);
                var newToken = GenerateToken(customer.ID.ToString());
                return Json(new
                {
                    success = true,
                    message = ConstantManager.MES_LOGIN_SUCCESS,
                    status = ConstantManager.STATUS_SUCCESS,
                    data = new
                    {
                        accessToken = newToken,
                        isfirstLogin = false,
                        isPhoneNoLogin = false,
                        CustomerInfo = customer
                    },
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //Create customer by facebook profile data
                CustomerViewModel newCustomer = new CustomerViewModel();
                newCustomer.Name = fbName;
                newCustomer.Birthday = fbBirthday;
                newCustomer.Gender = fbGender;
                newCustomer.fbEmail = fbEmail;
                int resId = -1;
                resId = customerApi.AddCustomer(newCustomer);
                if (resId != -1)
                {
                    var createdCustomer = customerApi.Get().Where(q => q.ID == resId).FirstOrDefault();
                    var newToken = GenerateToken(createdCustomer.ID.ToString());
                    return Json(new
                    {
                        success = true,
                        message = ConstantManager.MES_LOGIN_SUCCESS,
                        status = ConstantManager.STATUS_SUCCESS,
                        data = new
                        {
                            accessToken = newToken,
                            isfirstLogin = true,
                            isPhoneNoLogin = false,
                            CustomerInfo = customer
                        },
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                success = false,
                message = ConstantManager.MES_LOGIN_FAIL,
                status = ConstantManager.STATUS_SUCCESS,
            }, JsonRequestBehavior.AllowGet);
        }

        public static string GenerateToken(string customerID)
        {
            var payload = customerID + ":" + DateTime.Now.Ticks.ToString();

            return JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
        }

    }
}