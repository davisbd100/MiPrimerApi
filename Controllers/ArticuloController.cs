using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MiPrimerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        List<Articulo> articulos { set; get; }

        private readonly GestionArticulosContext _contexto;
        public ArticuloController(GestionArticulosContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Obtener()
        {
            var articulos = _contexto.Articulos.ToList();
            return Ok(articulos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var articulo = _contexto.Articulos.FirstOrDefault (a=> a.Id == id);
            if (articulo == null)
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
            _contexto.Articulos.Add(articulo);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(ObtenerPorId), new{articulo.Id}, articulo);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Editar(int id, Articulo articulo)
        {
            var articuloOriginal = _contexto.Articulos.FirstOrDefault(a => a.Id == id);
            articuloOriginal.Nombre = articulo.Nombre;
            articuloOriginal.Descripcion = articulo.Descripcion;
            articuloOriginal.Precio = articulo.Precio;
            _contexto.SaveChanges();
            return Ok(_contexto.Articulos);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Borrar(int id)
        {
            var articulo = _contexto.Articulos.FirstOrDefault(a => a.Id == id);
            _contexto.Remove(articulo);
            _contexto.SaveChanges();
            return Ok(_contexto.Articulos);
        }
    }
}