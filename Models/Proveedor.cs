using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerApi.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}