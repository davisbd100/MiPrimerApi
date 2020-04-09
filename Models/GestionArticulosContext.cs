using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerApi.Models
{
    public class GestionarArticulosContext: DbContext
    {
        public GestionarArticulosContext(DbContextOptions<GestionarArticulosContext> opciones) : base(opciones)
        {

        }

        public DbSet<Articulo> Articulos { set; get; }
    }
}