using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IOrderService
    {
        bool CreateOrder(Order order);
    }
    public partial class OrderService
    {
        public bool CreateOrder(Order order)
        {
            try
            {
                this.Create(order);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
