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
    
    public partial class CustomerViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<HmsService.Models.Entities.Customer>
    {
    	
    			public virtual int ID { get; set; }
    			public virtual string Name { get; set; }
    			public virtual string Phone { get; set; }
    			public virtual string DeliveryAddress { get; set; }
    			public virtual string fbEmail { get; set; }
    			public virtual Nullable<bool> Gender { get; set; }
    			public virtual Nullable<System.DateTime> Birthday { get; set; }
    			public virtual bool Active { get; set; }
    	
    	public CustomerViewModel() : base() { }
    	public CustomerViewModel(HmsService.Models.Entities.Customer entity) : base(entity) { }
    
    }
}
