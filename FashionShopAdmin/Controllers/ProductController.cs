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
        public ActionResult AddNewProduct(string name, string[] sizeList, string[] colorList, string description,
            int categoryID, int supplierID, decimal price)
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

            List<ProductImageViewModel> listProductImage = new List<ProductImageViewModel>();
            var orderCount = 0;
            byte[] avatarImage = null;
            if (Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    int fileSizeInBytes = file.ContentLength;

                    using (var br = new BinaryReader(file.InputStream))
                    {
                        avatarImage = br.ReadBytes(fileSizeInBytes);
                    }
                    string picUrl = null;
                    if (avatarImage != null)
                    {
                        picUrl = SaveImageToServer(avatarImage);
                        ProductImageViewModel productImage = new ProductImageViewModel();
                        productImage.PicUrl = picUrl;
                        productImage.DisplayOrder = ++orderCount;
                        listProductImage.Add(productImage);
                    }
                }

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
                ProductImages = listProductImage,
                Active = true,
            };
            ProductApi productApi = new ProductApi();
            productApi.CreateProduct(newProduct);
            return Json(new { success = true, message = "Successfully added!" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditProduct(string name, string[] sizeList, string[] colorList, string description,
            int categoryID, int supplierID, decimal price, int ID)
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

            List<ProductImageViewModel> listProductImage = new List<ProductImageViewModel>();
            var orderCount = 0;
            byte[] avatarImage = null;
            if (Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    int fileSizeInBytes = file.ContentLength;

                    using (var br = new BinaryReader(file.InputStream))
                    {
                        avatarImage = br.ReadBytes(fileSizeInBytes);
                    }
                    string picUrl = null;
                    if (avatarImage != null)
                    {
                        picUrl = SaveImageToServer(avatarImage);
                        ProductImageViewModel productImage = new ProductImageViewModel();
                        productImage.PicUrl = picUrl;
                        productImage.DisplayOrder = ++orderCount;
                        listProductImage.Add(productImage);
                    }
                }

            }

            ProductApi productApi = new ProductApi();
            var product = productApi.GetActive().Where(q => q.ID == ID).FirstOrDefault();
            product.Name = name;
            product.Size = size.ToString();
            product.Color = color.ToString();
            product.Description = description;
            product.ProductCategory = null;
            product.CategoryID = categoryID;
            product.Supplier = null;
            product.SupplierId = supplierID;
            product.Price = price;
            product.ProductImages = listProductImage;
            productApi.EditProduct(product);
            return Json(new { success = true, message = "Successfully edited!" }, JsonRequestBehavior.AllowGet);
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

        public ActionResult DeactivateProduct(int ID)
        {
            ProductApi productApi = new ProductApi();
            productApi.Deactivate(ID);
            return Json(new { success = true, message = "Successfully deactivate!"});
        }

        public JsonResult GetProductDetails(int ID)
        {
            ProductApi productApi = new ProductApi();
            ProductViewModel product = productApi.Get(ID);
            return Json( product , JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductImages(int ID)
        {
            ProductApi productApi = new ProductApi();
            ProductViewModel product = productApi.Get(ID);
            return Json( new {
                ProductImages = product.ProductImages
            }, JsonRequestBehavior.AllowGet);
        }
    }
}