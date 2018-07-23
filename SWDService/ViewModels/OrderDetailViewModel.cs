using AutoMapper;
using HmsService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.ViewModels
{
    public partial class OrderDetailViewModel
    {
        private IQueryable<Product> list;
        private IMapper mapper;

        public OrderDetailViewModel(IQueryable<Product> list, IMapper mapper)
        {
            this.list = list;
            this.mapper = mapper;
        }
        public ProductViewModel Product { get; set; }
    }
}
