using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimerApi.Models;

namespace MiPrimerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        List<Articulo> articulos { set; get; }
        public ArticuloController()
        {
            articulos = new List<Articulo>()
            {
                new Articulo { Id = 1, Nombre = "Laptop", Descripcion = "Laptop HP", Precio = 15000, FechaRegistro = DateTime.Now },
                new Articulo { Id = 2, Nombre = "Impresora", Descripcion = "Impresora Epson", Precio = 8700, FechaRegistro = DateTime.Now },
                new Articulo { Id = 3, Nombre = "Monito", Descripcion = "Monitor Asus", Precio = 1600, FechaRegistro = DateTime.Now },
                new Articulo { Id = 4, Nombre = "Cable USB", Descripcion = "Cable USB generico", Precio = 193, FechaRegistro = DateTime.Now }
            };
        }

        [HttpGet]
        [Route("")]
        public IActionResult Obtener()
        {
            return Ok(articulos);
        }
    }
}