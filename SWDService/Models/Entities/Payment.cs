//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HmsService.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int ID { get; set; }
        public int ToOrderID { get; set; }
        public int Type { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public int ToOrderID { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
