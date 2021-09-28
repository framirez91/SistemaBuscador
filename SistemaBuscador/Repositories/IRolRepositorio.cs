
using SistemaBuscador.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public interface IRolRepositorio
    {
        Task ActualizarRol(RolEdicionModel model);
        Task EliminarRol(int id);
        Task InsertarRol(RolCreacionModel model);
        Task<List<RolListaModelo>> ObtenerListaRoles();
        Task<RolEdicionModel> ObtenerRolPorId(int id);
    }
}