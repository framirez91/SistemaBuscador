using Microsoft.AspNetCore.Mvc;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System.Threading.Tasks;

namespace SistemaBuscador.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolRepositorio _repositorio;

        public RolesController(IRolRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<IActionResult> Index()
        {
            var listaRoles = await _repositorio.ObtenerListaRoles();
            return View(listaRoles);
        }

        public IActionResult NuevoRol()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NuevoRol(RolCreacionModel model)//tiene logica hay que probar
        {
            if (ModelState.IsValid)
            {
                //Guardar en la bf
                await _repositorio.InsertarRol(model);
                return RedirectToAction("Index", "Roles");
            }
            return View("NuevoRol", model);
        }

        public async Task<IActionResult> ActualizarRol(int id)// no tiene logica pero si hay que probar el obtener repositorio por ID
        {
            var rol = await _repositorio.ObtenerRolPorId(id);
            return View(rol);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarRol(RolEdicionModel model)
        {
            if (ModelState.IsValid)
            {
                //Actualizar en la bd
                await _repositorio.ActualizarRol(model);
                return RedirectToAction("Index");
            }

            return View(model);

        }

        public async Task<IActionResult> EliminarRol(int id)
        {
            var rol = await _repositorio.ObtenerRolPorId(id);
            return View(rol);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarRol(RolEdicionModel model)
        {
            await _repositorio.EliminarRol(model.Id);
            return RedirectToAction("Index");
        }
    }
}