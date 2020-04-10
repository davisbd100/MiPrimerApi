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
    public class ProveedorController : ControllerBase
    {
        List<Proveedor> proveedores { set; get; }

        private readonly GestionArticulosContext _contexto;
        public ProveedorController(GestionArticulosContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Obtener()
        {
            var proveedores = _contexto.Proveedores.ToList();
            return Ok(proveedores);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var proveedor = _contexto.Proveedores.FirstOrDefault (a=> a.Id ==id);
            if (proveedores == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Registrar(Proveedor proveedor)
        {
            proveedor.FechaRegistro = DateTime.Now;
            _contexto.Proveedores.Add(proveedor);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(ObtenerPorId), new{proveedor.Id}, proveedor);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Editar(int id, Proveedor proveedor)
        {
            var proveedorOriginal = _contexto.Proveedores.FirstOrDefault(a => a.Id == id);
            proveedorOriginal.Nombre = proveedor.Nombre;
            proveedorOriginal.Telefono = proveedor.Telefono;
            _contexto.SaveChanges();
            return Ok(proveedores);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Borrar(int id)
        {
            var proveedor = _contexto.Proveedores.FirstOrDefault(a => a.Id == id);
            _contexto.Remove(proveedor);
            _contexto.SaveChanges();
            return Ok(proveedores);
        }
    }
}