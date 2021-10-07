using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBuscador.Controllers;
using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasIntegracion
{
    [TestClass]
    public class RolControllerTest : TestBase
    {
        [TestMethod]

        public async Task NuevoRol()
        {   //preparacion
            var nombreBd = Guid.NewGuid().ToString();//crea nombre aleatorio
            var context = BuildContext(nombreBd);// crea un contexto con el nombre aleatorio
            var rolService = new RolRepositorio(context);
            var model = new RolCreacionModel() { Nombre = "Rol Test1" };
            var controller = new RolesController(rolService);
            //ejecucion
            await controller.NuevoRol(model);
            var context2 = BuildContext(nombreBd);
            var lista = await context2.Roles.ToListAsync();
            var resultado = lista.Count;


            //validacion

            Assert.AreEqual(1, resultado);

        }
        [TestMethod]

        public async Task ActualizarRol()
        {   //preparacion
            var nombreBd = Guid.NewGuid().ToString();//crea nombre aleatorio
            var context = BuildContext(nombreBd);// crea un contexto
            var rolService = new RolRepositorio(context);//instanciamos el repositorio con el contexto
            var rol = new Rol() { Nombre = "Rol Test" };//creamos un rol tipo entidad rol
            context.Roles.Add(rol);//Insertamos rol
            await context.SaveChangesAsync();//guardamos el rol en la BD

            var model = new RolEdicionModel() { Id = 1, Nombre = "Rol Test Modificado" };//cramos el modelo que actualiza el rol
            var controller = new RolesController(rolService);//instanciamos el controlador
            //ejecucion
            await controller.ActualizarRol(model);//accion de actualizar controlador
            var context2 = BuildContext(nombreBd);//Creamos nuevo contexto
            var rolDb = await context2.Roles.FirstOrDefaultAsync(x => x.Id == 1);//buscamos en forma manual el rol actualizado
            var resultado = rolDb.Nombre;//comparamos el rol


            //validacion

            Assert.AreEqual("Rol Test Modificado", resultado);

        }
    }



}
