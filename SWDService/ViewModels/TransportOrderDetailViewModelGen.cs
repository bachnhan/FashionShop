//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HmsService.ViewModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransportOrderDetailViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<HmsService.Models.Entities.TransportOrderDetail>
    {
    	
    			public virtual int ID { get; set; }
    			public virtual int TransportOrderID { get; set; }
    			public virtual int ProductID { get; set; }
    			public virtual int Quantity { get; set; }
    			public virtual Nullable<decimal> Price { get; set; }
    	
    	public TransportOrderDetailViewModel() : base() { }
    	public TransportOrderDetailViewModel(HmsService.Models.Entities.TransportOrderDetail entity) : base(entity) { }
    
    }
}
