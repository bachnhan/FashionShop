using Facebook;
using HmsService.Models;
using HmsService.Models.Entities;
using HmsService.Sdk;
using HmsService.ViewModels;
using Jose;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
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

        [System.Web.Mvc.HttpPost]
        public JsonResult LoginByFacebook(string fbAccessToken, string avatarUrl)
        {
            var customerApi = new CustomerApi();
            //Get Facebook client profile by accessToken
            var fb = new FacebookClient();
            fb.AccessToken = fbAccessToken;
            dynamic me = fb.Get("me?fields=id,name,gender,email,birthday,picture");
            string fbEmail = me.email;
            string fbName = me.name;
            bool? fbGender = null;
            string fbpicUrl = "";
            var jsonPic = me.picture;
            //get picture
            fbpicUrl = (string)(((JsonObject)(((JsonObject)jsonPic)["data"]))["url"]);
            if (me.gender == "male")
            {
                fbGender = true;
            }
            else if (me.gender == "female")
            {
                fbGender = false;
            }
            DateTime? fbBirthday = null;
            if (me.birthday != null)
            {
                fbBirthday = DateTime.ParseExact(me.birthday, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            }

            //Check Cusomter Facebook email exitested
            var customer = customerApi.Get().Where(q => q.fbEmail != null && q.fbEmail.Equals(fbEmail)).FirstOrDefault();
            if (customer != null)
            {
                //Check customer membershipcard
                customerApi.Edit(customer.ID, customer);
                var newToken = GenerateToken(customer.ID.ToString());
                return Json(new
                {
                    status = new
                    {
                        success = true,
                        message = ConstantManager.MES_LOGIN_SUCCESS,
                        status = ConstantManager.STATUS_SUCCESS
                    },
                    data = new
                    {
                        data = new
                        {
                            accessToken = newToken,
                            isfirstLogin = false,
                            isPhoneNoLogin = false,
                            CustomerInfo = customer
                        }
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
                newCustomer.Avatar = fbpicUrl;
                int resId = -1;
                resId = customerApi.AddCustomer(newCustomer);
                if (resId != -1)
                {
                    var createdCustomer = customerApi.Get().Where(q => q.ID == resId).FirstOrDefault();
                    var newToken = GenerateToken(createdCustomer.ID.ToString());
                    return Json(new
                    {
                        status = new
                        {
                            success = true,
                            message = ConstantManager.MES_LOGIN_SUCCESS,
                            status = ConstantManager.STATUS_SUCCESS
                        },
                        data = new
                        {
                            data = new
                            {
                                accessToken = newToken,
                                isfirstLogin = true,
                                isPhoneNoLogin = false,
                                CustomerInfo = createdCustomer
                            }
                        },
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                status = new
                {
                    success = false,
                    message = ConstantManager.MES_LOGIN_FAIL,
                    status = ConstantManager.STATUS_SUCCESS
                },
                data = new { }
            }, JsonRequestBehavior.AllowGet);
        }

        private static string GenerateToken(string customerID)
        {
            var payload = customerID + ":" + DateTime.Now.Ticks.ToString();

            return JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
        }

        private string getCustomerIdFromToken(string token)
        {
            string key = JWT.Decode(token, secretKey);
            string[] parts = key.Split(new char[] { ':' });
            return parts[0];
        }

        public JsonResult GetStoreInfo(int storeId)
        {
            var storeApi = new StoreApi();
            var store = storeApi.Get().Where(q => q.ID == storeId).FirstOrDefault();
            if (store != null)
            {
                return Json(new
                {
                    status = new
                    {
                        success = true,
                        status = ConstantManager.STATUS_SUCCESS,
                        message = ConstantManager.MES_SUCCESS
                    },
                    data = new
                    {
                        data = new
                        {
                            store = store
                        }
                    }
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = new
                    {
                        success = false,
                        status = ConstantManager.STATUS_SUCCESS,
                        message = ConstantManager.MES_FAIL
                    },
                    data = new
                    {
                    }
                });
            }
        }

        public JsonResult GetStoreList()
        {
            var storeApi = new StoreApi();
            var stores = storeApi.Get().ToList();
            if (stores != null)
            {
                return Json(new
                {
                    status = new
                    {
                        success = true,
                        status = ConstantManager.STATUS_SUCCESS,
                        message = ConstantManager.MES_SUCCESS
                    },
                    data = new
                    {
                        data = new
                        {
                            store_list = stores
                        }
                    }
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = new
                    {
                        success = false,
                        status = ConstantManager.STATUS_SUCCESS,
                        message = ConstantManager.MES_FAIL
                    },
                    data = new
                    {
                    }
                });
            }
        }

        public JsonResult getListProduct()
        {
            ProductApi productApi = new ProductApi();
            ProductCategoryApi productCategoryApi = new ProductCategoryApi();
            ProductImageApi productImageApi = new ProductImageApi();

            //get parent product
            var products = productApi.Get().Where(q => q.ParentProductId == null);

            if (products == null)
            {
                return Json(new
                {
                    status = new
                    {
                        success = false,
                        status = ConstantManager.STATUS_SUCCESS,
                        message = ConstantManager.MES_FAIL
                    },
                    data = new { }
                }, JsonRequestBehavior.AllowGet);
            }

            var data = (from p in products
                        select new
                        {
                            product_image_list = productImageApi.Get().Where(q => q.ProductId == p.ID).ToList(),
                            product_id = p.ID,
                            product_name = p.Name,
                            price = p.Price,
                            cat_id = p.CategoryID,
                            size = p.Size,
                            color = p.Color
                        }).ToList();

            //get product category
            var productCategory = productCategoryApi.Get();
            //get cateId and cateName
            var category = from pc in productCategory
                           select new
                           {
                               cat_id = pc.ID,
                               cat_name = pc.Name
                           };

            return Json(new
            {
                status = new
                {
                    success = true,
                    status = ConstantManager.STATUS_SUCCESS,
                    message = ConstantManager.MES_SUCCESS,
                },
                data = new
                {
                    data = new
                    {
                        product_list = data,
                        product_category_list = category.ToList()
                    }
                }

            }, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult setOrder([FromBody]OrderViewModel order, string accessToken)
        {
            var orderApi = new OrderApi();
            var customerApi = new CustomerApi();
            var employeeApi = new EmployeeApi();
            var productApi = new ProductApi();
            //Get CustomerId from token
            int number;
            order.CustomerID = 0;
            if (Int32.TryParse(getCustomerIdFromToken(accessToken),out number))
            {
                order.CustomerID = number;
            }
            //Check customer exist if customerId != 0 (customerId default is 0)
            if (order.CustomerID != 0 && (order.CustomerID == null || customerApi.GetActive().Where(q => q.ID == order.CustomerID) == null))
            {
                return Json(new
                {
                    status = new
                    {
                        success = false,
                        status = ConstantManager.STATUS_SUCCESS,
                        message = ConstantManager.MES_CHECK_CUSTOMER_FAIL
                    },
                    data = new { }
                });
            }
            //Check employee exist if employeeId != 0 (employeeId is 0 for online Order)
            order.EmployeeID = null;
            //Check order details
            if (order.OrderDetails == null || order.OrderDetails.Count() == 0)
            {
                return Json(new
                {
                    status = new
                    {
                        success = false,
                        status = ConstantManager.STATUS_SUCCESS,
                        message = ConstantManager.MES_CHECK_ORDER_DETAIL_FAIL
                    },
                    data = new { }
                });
            }
            //Calculate order
            decimal totalAmount = 0;
            foreach (var orderdetail in order.OrderDetails)
            {
                //Check Order detail ProductId not null and product exist
                if (orderdetail.ProductID == null)
                {
                    return Json(new
                    {
                        status = new
                        {
                            success = false,
                            status = ConstantManager.STATUS_SUCCESS,
                            message = ConstantManager.MES_CHECK_PRODUCT_FAIL
                        },
                        data = new { }
                    });
                }
                //Check product exist
                var product = productApi.GetActive().Where(q => q.ID == orderdetail.ProductID).FirstOrDefault();
                if (product == null)
                {
                    return Json(new
                    {
                        status = new
                        {
                            success = false,
                            status = ConstantManager.STATUS_SUCCESS,
                            message = ConstantManager.MES_CHECK_PRODUCT_FAIL
                        },
                        data = new { }
                    });
                }
                //Check Order detail Quantity
                if (orderdetail.Quantity == null || orderdetail.Quantity < 1)
                {
                    return Json(new
                    {
                        status = new
                        {
                            success = false,
                            status = ConstantManager.STATUS_SUCCESS,
                            message = ConstantManager.MES_CHECK_QUANTITY_FAIL
                        },
                        data = new { }
                    });
                }
                //Set OrderDetail
                orderdetail.Price = product.Price;
                orderdetail.Amount = product.Price * orderdetail.Quantity;
                //Calculate total amount
                totalAmount += orderdetail.Amount;
            }
            //Create payment
            List<PaymentViewModel> listPayment = new List<PaymentViewModel>();
            PaymentViewModel payment = new PaymentViewModel();
            payment.Amount = totalAmount;
            payment.Type = (int)PaymentTypeEnum.Cash;
            listPayment.Add(payment);
            //Create Order
            order.CheckInDate = DateTime.Now;
            order.TotalAmount = totalAmount;
            order.Payments = listPayment;
            order.InvoiceID = generateInvoiceID();
            order.Status = (int)OrderStatusEnum.Finish;
            var rs = orderApi.CreateOrder(order);
            if (rs == false)
            {
                return Json(new
                {
                    status = new
                    {
                        success = false,
                        status = ConstantManager.STATUS_SUCCESS,
                        message = ConstantManager.MES_CREATE_ORDER_FAIL
                    },
                    data = new { }
                });
            }
            return Json(new
            {
                status = new
                {
                    success = true,
                    status = ConstantManager.STATUS_SUCCESS,
                    message = ConstantManager.MES_CREATE_ORDER_SUCCESS
                },
                data = new
                {
                    data = new
                    {
                        InvoiceID = order.InvoiceID,
                        Status = order.Status
                    }
                }
            });
        }

        private static string generateInvoiceID()
        {
            return ConstantManager.INVOICEID_PREFIX + DateTime.Now.Ticks.ToString();
        }
    }
}