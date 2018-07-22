using AutoMapper;
using HmsService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.ViewModels
{
    public partial class ProductViewModel
    {
        private IQueryable<Product> list;
        private IMapper mapper;

        public ProductViewModel(IQueryable<Product> list, IMapper mapper)
        {
            this.list = list;
            this.mapper = mapper;
        }
        public ProductCategoryViewModel ProductCategory { get; set; }
        public SupplierViewModel Supplier { get; set; }
    }
}
