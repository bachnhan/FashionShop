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
    
    public partial class ProductViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<HmsService.Models.Entities.Product>
    {
    	
    			public virtual int ID { get; set; }
    			public virtual string Name { get; set; }
    			public virtual string Size { get; set; }
    			public virtual string Color { get; set; }
    			public virtual string Description { get; set; }
    			public virtual int CategoryID { get; set; }
    			public virtual int SupplierId { get; set; }
    			public virtual decimal Price { get; set; }
    			public virtual Nullable<int> ParentProductId { get; set; }
    			public virtual bool Active { get; set; }
    			public virtual string PicUrl { get; set; }
    	
    	public ProductViewModel() : base() { }
    	public ProductViewModel(HmsService.Models.Entities.Product entity) : base(entity) { }
    
    }
}
