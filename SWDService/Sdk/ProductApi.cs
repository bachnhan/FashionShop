using HmsService.Models.Entities;
using HmsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Sdk
{
    public partial class ProductApi : HmsService.Sdk.BaseSdkApi<HmsService.Models.Entities.Product, HmsService.ViewModels.ProductViewModel, HmsService.Models.Entities.Services.IProductService>
    {
        public void EditProduct(ProductViewModel product)
        {
            var entity = new Product();
            product.CopyToEntity(entity);
            this.BaseService.Update(entity);
            this.BaseService.Save();
        }
    }
}
