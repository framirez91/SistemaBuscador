
using SistemaBuscador.Models;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public interface IUsuarioRepository
    {
        Task InsertatUsuario(UsuarioCreacionModel model);
    }
}