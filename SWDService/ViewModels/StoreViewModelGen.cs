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
    
    public partial class StoreViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<HmsService.Models.Entities.Store>
    {
    	
    			public virtual int ID { get; set; }
    			public virtual string Name { get; set; }
    			public virtual string Address { get; set; }
    			public virtual int Status { get; set; }
    	
    	public StoreViewModel() : base() { }
    	public StoreViewModel(HmsService.Models.Entities.Store entity) : base(entity) { }
    
    }
}
