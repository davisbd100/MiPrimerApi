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
        public ProveedorController()
        {
            proveedores = new List<Proveedor>()
            {
                new Proveedor { Id = 1, Nombre = "Acer", Telefono = "2281270021", FechaRegistro = DateTime.Now },
                new Proveedor { Id = 2, Nombre = "Lenovo", Telefono = "2288183991", FechaRegistro = DateTime.Now }
            };
        }

        [HttpGet]
        [Route("")]
        public IActionResult Obtener()
        {
            return Ok(proveedores);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var proveedor = proveedores.FirstOrDefault (a=> a.Id ==id);
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
            proveedores.Add(proveedor);
            //return CreatedAtAction(nameof(ObtenerPorId), new {proveedor.Id}, proveedor);
            return Ok(proveedores);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Editar(int id, Proveedor proveedor)
        {
            var proveedorOriginal = proveedores.FirstOrDefault(a => a.Id == id);
            proveedor.Id = id;
            var indice = proveedores.IndexOf(proveedorOriginal);
            proveedores[indice].Nombre = proveedor.Nombre;
            proveedores[indice].Telefono = proveedor.Telefono;
            return Ok(proveedores);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Borrar(int id)
        {
            var proveedor = proveedores.FirstOrDefault(a => a.Id == id);
            proveedores.Remove(proveedor);
            return Ok(proveedores);
        }
    }
}