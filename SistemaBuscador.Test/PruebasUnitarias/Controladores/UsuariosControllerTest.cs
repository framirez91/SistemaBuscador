using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaBuscador.Controllers;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasUnitarias.Controladores
{
    [TestClass]
    public class UsuariosControllerTest
    {
        [TestMethod]
        public async Task NuevoUsuario_modelo_invalido()
        {
            //preparacion
            var usuarioServices = new Mock<IUsuarioRepository>();
            var model = new UsuarioCreacionModel() { NombreUsuario = "j23", Nombres = "juan", Apellidos = "as d", Password = "Hola123456", RePassword = "Hola123456" };
            var controller = new UsuariosController(usuarioServices.Object);

            //ejecucion
            controller.ModelState.AddModelError(string.Empty, "Datos invalidos");
            var resultado = await controller.NuevoUsuario(model) as ViewResult;


            //validacion
            Assert.AreEqual(resultado.ViewName, "NuevoUsuario");


        }
        [TestMethod]
        public async Task NuevoUsuario_modelo_valido()
        {
            //preparacion
            var usuarioServices = new Mock<IUsuarioRepository>();
            var model = new UsuarioCreacionModel() { NombreUsuario = "j23", Nombres = "juan", Apellidos = "as d", Password = "Hola123456", RePassword = "Hola123456" };
            var controller = new UsuariosController(usuarioServices.Object);

            //ejecucion

            var resultado = await controller.NuevoUsuario(model) as RedirectToActionResult;


            //validacion
            Assert.AreEqual(resultado.ControllerName, "Usuarios");
            Assert.AreEqual(resultado.ActionName, "Index");



        }
    }


}
