using Microsoft.AspNetCore.Mvc;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;

namespace SistemaBuscador.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NuevoUsuario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NuevoUsuario(UsuarioCreacionModel model)
        {
            if (ModelState.IsValid)
            {
                //Guardar el usuario en la bd
                _repository.InsertatUsuario(model);
                return View("Index");
            }

            return View(model);
        }
    }
}