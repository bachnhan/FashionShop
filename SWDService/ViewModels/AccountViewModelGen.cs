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
    
    public partial class AccountViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<HmsService.Models.Entities.Account>
    {
    	
    			public virtual string Username { get; set; }
    			public virtual string Password { get; set; }
    			public virtual Nullable<int> CusomerID { get; set; }
    			public virtual Nullable<int> EmployeeID { get; set; }
    	
    	public AccountViewModel() : base() { }
    	public AccountViewModel(HmsService.Models.Entities.Account entity) : base(entity) { }
    
    }
}
