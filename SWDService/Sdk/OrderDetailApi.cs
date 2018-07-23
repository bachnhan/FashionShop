using HmsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Sdk
{
    public partial class OrderDetailApi
    {
        public IEnumerable<OrderDetailViewModel> GetActiveWithProductByOrderId(int orderId)
        {
            var listOrderDetail = this.BaseService
                .GetActive(o => o.OrderID == orderId)
                .ToList()
                .Select(o => new OrderDetailViewModel(o)
                {
                    Product = new ProductViewModel(o.Product)
                });
            return listOrderDetail;
        }
    }
}
