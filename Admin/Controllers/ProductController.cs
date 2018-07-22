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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

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

        [HttpPost]
        public ActionResult AddNewProduct(string name,string[] sizeList,string[] colorList,string description,
            int categoryID,int supplierID, decimal price)
        {
            StringBuilder size = new StringBuilder();
            StringBuilder color = new StringBuilder();

            for (int i = 0; i < sizeList.Length; i++)
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

            byte[] avatarImage = null;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                int fileSizeInBytes = file.ContentLength;

                using (var br = new BinaryReader(file.InputStream))
                {
                    avatarImage = br.ReadBytes(fileSizeInBytes);
                }
            }

            string picUrl = null;
            if (avatarImage != null)
            {
                picUrl = SaveImageToServer(avatarImage);
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
                PicUrl = picUrl,
                Active = true,
            };
            ProductApi productApi = new ProductApi();
            productApi.Create(newProduct);
            return Json(new { success = true, message = "Successfully added!" },JsonRequestBehavior.AllowGet);
        }

        private string SaveImageToServer(byte[] avatarImage)
        {
            var ms = new MemoryStream(avatarImage);
            var image = Image.FromStream(ms);
            string imageServerPath = ConstantManager.PRODUCT_IMAGE_SERVER_PATH;
            if (Directory.Exists(imageServerPath) == false)
            {
                Directory.CreateDirectory(imageServerPath);
            }
            string fileName = DateTime.Now.Ticks.ToString() + ConstantManager.IMAGE_FORMAT_EXTENSION;
            string filePath = imageServerPath + "\\" + fileName;
            image.Save(filePath, ImageFormat.Png);
            return ConstantManager.PRODUCT_IMAGE_SERVER_BASEURL + "/" + fileName;
        }
    }
}