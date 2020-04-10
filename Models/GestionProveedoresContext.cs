using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerApi.Models
{
    public class GestionProveedoresContext: DbContext
    {
        public GestionProveedoresContext(DbContextOptions<GestionProveedoresContext> opciones) : base(opciones)
        {

        }

        public DbSet<Proveedor> Proveedores { set; get; }
    }
}