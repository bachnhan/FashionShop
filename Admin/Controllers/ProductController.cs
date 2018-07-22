using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Models;
using HmsService.ViewModels;
using HmsService.Sdk;
using HmsService.Models.Entities;
using System.Text;

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
            List<ProductViewModel> result = productApi.GetActive().Where(q => q.ParentProductId == null).ToList();
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNewProduct(string name, string[] sizeList, string[] colorList, string description, int categoryID, int supplierID, decimal price)
        {
            StringBuilder size = new StringBuilder();
            StringBuilder color = new StringBuilder();

            for(int i = 0; i < sizeList.Length; i++)
            {             
                size.Append(sizeList[i]);
                if (i < sizeList.Length - 1)
                    size.Append(",");
            }

            for (int i = 0; i < colorList.Length; i++)
            {
                color.Append(colorList[i]);
                if (i < colorList.Length - 1)
                    color.Append(",");
            }

            ProductViewModel newProduct = new ProductViewModel()
            {
                Name = name,
                Size = size.ToString(),
                Color = color.ToString(),
                Description = description,
                CategoryID = categoryID,
                SupplierId = supplierID,
                Price = price,
                Active = true,
            };
            ProductApi productApi = new ProductApi();
            productApi.Create(newProduct);
            return Json(new { success = true, message = "Successfully added!" },JsonRequestBehavior.AllowGet);
        }
    }
}