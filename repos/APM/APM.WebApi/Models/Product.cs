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
    
    public partial class Product
    {
        public int ProductId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
    }
}