using AutoMapper;
using HmsService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.ViewModels
{
    public partial class OrderViewModel
    {
        private IQueryable<Order> list;
        private IMapper mapper;

        public OrderViewModel(IQueryable<Order> list, IMapper mapper)
        {
            this.list = list;
            this.mapper = mapper;
        }
        public StoreViewModel Store { get; set; }
        public CustomerViewModel Customer { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public List<PaymentViewModel> Payments { get; set; }
        public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
