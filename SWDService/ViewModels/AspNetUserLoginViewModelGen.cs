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
    
    public partial class AspNetUserLoginViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<HmsService.Models.Entities.AspNetUserLogin>
    {
    	
    			public virtual string LoginProvider { get; set; }
    			public virtual string ProviderKey { get; set; }
    			public virtual string UserId { get; set; }
    	
    	public AspNetUserLoginViewModel() : base() { }
    	public AspNetUserLoginViewModel(HmsService.Models.Entities.AspNetUserLogin entity) : base(entity) { }
    
    }
}
