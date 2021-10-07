using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using SistemaBuscador.Utilidades;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasUnitarias.Servicios
{
    [TestClass]

    public class UsuarioRepositoryTest : TestBase
    {
        [TestMethod]
        public async Task InsertatUsuario()
        {       //preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var serviceSeguridad = new Mock<ISeguridad>();
            var serviceRol = new Mock<IRolRepositorio>();
            var repo = new UsuarioRepository(context, serviceSeguridad.Object, serviceRol.Object);
            var modelo = new UsuarioCreacionModel() { NombreUsuario = "j23", Nombres = "juan", Apellidos = "as d", Password = "Hola123456", RePassword = "Hola123456", RolId = 1 };
            //ejecucion
            await repo.InsertatUsuario(modelo);
            var context2 = BuildContext(nombreBd);


            var list = await context2.Usuarios.ToListAsync();
            var resultado = list.Count();
            //verificacion
            Assert.AreEqual(1, resultado);




        }

        [TestMethod]

        public async Task ObtenerListaUsuarios()
        { //preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var usuario = new Usuario() { Id = 1, NombreUsuario = "j23", Nombres = "juan", Apellidos = "as d", Password = "Hola123456", RolId = 1 };
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();
            var context2 = BuildContext(nombreBd);
            var serviceSeguridad = new Mock<ISeguridad>();
            var serviceRol = new Mock<IRolRepositorio>();
            var repo = new UsuarioRepository(context2, serviceSeguridad.Object, serviceRol.Object);

            //ejecucion
            var usuarioDeLaBd = await repo.ObtenerListaUsuarios();
            //verficiacion
            Assert.IsNotNull(usuarioDeLaBd);//verificamos que no sea null

        }

        [TestMethod]
        public async Task ObtenerUsuarioPorID()
        {
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var usuario = new Usuario() { Id = 1, NombreUsuario = "j23", Nombres = "juan", Apellidos = "as d", Password = "Hola123456", RolId = 1 };
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();
            var context2 = BuildContext(nombreBd);
            var serviceSeguridad = new Mock<ISeguridad>();
            var serviceRol = new Mock<IRolRepositorio>();
            var repo = new UsuarioRepository(context2, serviceSeguridad.Object, serviceRol.Object);

            var usuarioDeLaBd = await repo.ObtenerUsuarioPorId(1);
            //verficiacion
            Assert.IsNotNull(usuarioDeLaBd);//verificamos que no sea null

        }

        [TestMethod]
        public async Task ActualizarUsuario()
        {
            //preparacion

            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var usuario = new Usuario()
            {
                NombreUsuario = "Usuario T",
                Nombres = "Nombre t",
                Apellidos = "Apellido Tst",
                Password = " Hola123456 ",
                RolId = 1,
                Id = 1,
            };
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();

            var context2 = BuildContext(nombreBd);
            var serviceSeguridad = new Mock<ISeguridad>();
            var serviceRol = new Mock<IRolRepositorio>();
            var repo = new UsuarioRepository(context2, serviceSeguridad.Object, serviceRol.Object);
            var model = new UsuarioEdicionModel()
            {
                Nombres = "User",
                NombreUsuario = "Nombre Mod",
                Apellidos = "Apellido Mod",
                Id = 1,
                RolId = 1
            };
            //ejecucion
            await repo.ActualizarUsuario(model);
            var context3 = BuildContext(nombreBd);
            var usuarioModificado = await context3.Usuarios.FirstOrDefaultAsync(x => x.Id == 1);
            var resultado = usuarioModificado.Nombres;

            //verificacion
            Assert.AreEqual("User", resultado);
        }

        [TestMethod]
        public async Task EliminarUsuario()
        {
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var usuario = new Usuario()
            {
                NombreUsuario = "Usuario T",
                Nombres = "Nombre t",
                Apellidos = "Apellido Tst",
                Password = " Hola123456 ",
                RolId = 1,
                Id = 1,
            };
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();
            var context2 = BuildContext(nombreBd);
            var serviceSeguridad = new Mock<ISeguridad>();
            var serviceRol = new Mock<IRolRepositorio>();
            var repo = new UsuarioRepository(context2, serviceSeguridad.Object, serviceRol.Object);



            await repo.EliminarUsuario(1);
            var context3 = BuildContext(nombreBd);
            var listaRoles = await context3.Usuarios.ToListAsync();//
            var resultado = listaRoles.Count;//

            Assert.AreEqual(0, resultado);
        }







    }
}
