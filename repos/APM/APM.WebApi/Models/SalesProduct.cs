//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APM.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesProduct
    {
        public int SaleProductId { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<float> Price { get; set; }
        public int SaleId { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
