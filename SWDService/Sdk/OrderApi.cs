using HmsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Sdk
{
    public partial class OrderApi : HmsService.Sdk.BaseSdkApi<HmsService.Models.Entities.Order, HmsService.ViewModels.OrderViewModel, HmsService.Models.Entities.Services.IOrderService>
    {
        public bool CreateOrder(OrderViewModel order)
        {
            var entity = order.ToEntity();
            if (!this.BaseService.Get(q => q.InvoiceID == order.InvoiceID).Any())
            {
                return this.BaseService.CreateOrder(entity);
            }
            return false;
        }
    }
}
