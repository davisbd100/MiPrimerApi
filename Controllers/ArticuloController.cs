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

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var articulo = articulos.FirstOrDefault (a=> a.Id ==id);
            if (articulos == null)
            {
                return NotFound();
            }
            return Ok(articulo);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Registrar(Articulo articulo)
        {
            articulo.FechaRegistro = DateTime.Now;
            articulos.Add(articulo);
            //return CreatedAtAction(nameof(ObtenerPorId), new {articulo.Id}, articulo);
            return Ok(articulos);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Editar(int id, Articulo articulo)
        {
            var articuloOriginal = articulos.FirstOrDefault(a => a.Id == id);
            articulo.Id = id;
            var indice = articulos.IndexOf(articuloOriginal);
            articulos[indice].Nombre = articulo.Nombre;
            articulos[indice].Descripcion = articulo.Descripcion;
            articulos[indice].Precio = articulo.Precio;
            return Ok(articulos);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Borrar(int id)
        {
            var articulo = articulos.FirstOrDefault(a => a.Id == id);
            articulos.Remove(articulo);
            return Ok(articulos);
        }
    }
}