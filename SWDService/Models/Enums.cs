using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models
{
   public enum PaymentTypeEnum
    {
        Cash = 1
    }
    public enum OrderStatusEnum
    {
       [Display(Name = "Mới")]
       New = 1,
       [Display(Name = "Hủy")]
       Dispose = 2,
       [Display(Name = "Hoàn Thành")]
       Finish = 3
    }
}

