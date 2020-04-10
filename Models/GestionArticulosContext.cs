using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerApi.Models
{
    public class GestionArticulosContext: DbContext
    {
        public GestionArticulosContext(DbContextOptions<GestionArticulosContext> opciones) : base(opciones)
        {

        }

        public DbSet<Articulo> Articulos { set; get; }
        public DbSet<Proveedor> Proveedores { set; get; }
    }
}