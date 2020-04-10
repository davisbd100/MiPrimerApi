using MiPrimerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerApi.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly GestionArticulosContext _contexto;

        public ArticuloRepository(GestionArticulosContext contexto){
            _contexto = contexto;
        }

        public List<Articulo> ObtenerTodos()
        {
            var articulos = _contexto.Articulos.ToList();
            return articulos;
        }

        public Articulo ObtenerPorId(int id)
        {
            var articulo = _contexto.Articulos.FirstOrDefault(a => a.Id == id);
            return articulo;
        }
    }
}