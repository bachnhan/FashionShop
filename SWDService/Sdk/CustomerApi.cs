using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Sdk
{
    using HmsService.ViewModels;
    using System;
    using System.Collections.Generic;

    public partial class CustomerApi : HmsService.Sdk.BaseSdkApi<HmsService.Models.Entities.Customer, HmsService.ViewModels.CustomerViewModel, HmsService.Models.Entities.Services.ICustomerService>
    {
        public int AddCustomer(CustomerViewModel customer)
        {
            var entity = customer.ToEntity();
            this.BaseService.Create(entity);
            return entity.ID;
        }
    }
}
