//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class TIPO_EVALUACION
    {
        public TIPO_EVALUACION()
        {
            this.EVALUACION = new HashSet<EVALUACION>();
        }
    
        public decimal ID_TIPO_EVALUACION { get; set; }
        public Nullable<decimal> VALOR_AUTOEVALUACION { get; set; }
        public Nullable<decimal> VALOR_EVALUACION { get; set; }
    
        public virtual ICollection<EVALUACION> EVALUACION { get; set; }
    }
}