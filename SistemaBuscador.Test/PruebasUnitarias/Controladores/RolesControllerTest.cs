﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaBuscador.Controllers;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasUnitarias.Controladores
{
    [TestClass]
    public class RolesControllerTest
    {
        [TestMethod]
        public async Task NuevoRol_modelo_invalido()
        {
            //preparacion
            var rolService = new Mock<IRolRepositorio>();
            var model = new RolCreacionModel();
            var controller = new RolesController(rolService.Object);

            //ejecucion
            controller.ModelState.AddModelError(string.Empty, "Datos invalidos");
            var resultado = await controller.NuevoRol(model) as ViewResult;


            //validacion
            Assert.AreEqual(resultado.ViewName, "NuevoRol");


        }

        [TestMethod]
        public async Task NuevoRol_modelo_valido()
        {
            //preparacion
            var rolService = new Mock<IRolRepositorio>();
            var model = new RolCreacionModel();
            var controller = new RolesController(rolService.Object);

            //ejecucion
            var resultado = await controller.NuevoRol(model) as RedirectToActionResult;


            //validacion
            Assert.AreEqual(resultado.ControllerName, "Roles");
            Assert.AreEqual(resultado.ActionName, "Index");



        }
    }
}
