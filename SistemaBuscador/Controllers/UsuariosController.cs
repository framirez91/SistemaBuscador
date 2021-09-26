using Microsoft.AspNetCore.Mvc;

namespace SistemaBuscador.Controllers
{
    public class UsuariosController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NuevoUsuario()
        {
            return View();

        }
    }

}