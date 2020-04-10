using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerApi.Models{
    public class Articulo
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Ingrese un nombre")]
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        public double Precio { set; get; }
        public DateTime FechaRegistro { set; get; }
        public int ProveedorId { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}