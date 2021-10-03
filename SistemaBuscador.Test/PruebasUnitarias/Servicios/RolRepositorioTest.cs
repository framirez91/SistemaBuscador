using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasUnitarias.Servicios
{
    [TestClass]
    public class RolRepositorioTest : TestBase
    {
        [TestMethod]
        public async Task InsertarRol()
        {//preparacion
            var nombreBd = Guid.NewGuid().ToString();//crea nombre aleatorio
            var context = BuildContext(nombreBd);// crea un contexto con el nombre aleatorio
            var repo = new RolRepositorio(context);//pasamos el contexto que acabos de crear--instacion al repositorio
            var modelo = new RolCreacionModel() { Nombre = "Rol Test" };//creamos modelo para pasar -- creamos un rol
            //Ejecucion
            await repo.InsertarRol(modelo);//pasamos el modelo que acabos de crear para guardar en la BD 
            var context2 = BuildContext(nombreBd);//Generamos un segundo contexto con el mismo nombre de la BD para revalidar que el registro este en la bd 
            //y no en la memoria del contexto y asi nos aseguramos del almacenado en la BD y no en la variable

            var list = await context2.Roles.ToListAsync();//listamos todos los roles de la BD
            var resultado = list.Count();//cuenta la cantidad de roles en la base de datos
            //Verificacion
            Assert.AreEqual(1, resultado);//esperamos que el resultado de conteo en listado sea 1 
        }
        [TestMethod]
        public async Task ObtenerRolPorId()
        {
            //preparacion
            var nombreBd = Guid.NewGuid().ToString();//crea nombre aleatorio
            var context = BuildContext(nombreBd);// crea un contexto 
            var rol = new Rol() { Nombre = "Rol 1" };//creamos un nuevo rol manualmente                                     
            context.Roles.Add(rol);//agregamos el nuevo rol que acabos de crear
            await context.SaveChangesAsync();//guardamos
            var context2 = BuildContext(nombreBd);// crea un contexto2 para evitar problemas de contexto
            var repo = new RolRepositorio(context2);//pasamos el contexto que acabos de crear--instacion al repositorio

            //ejecucion
            var rolDeLaBd = await repo.ObtenerRolPorId(1);//aca ocupamos el metodo

            //verficiacion
            Assert.IsNotNull(rolDeLaBd);//verificamos que no sea null

        }

        [TestMethod]
        public async Task ActualizarRol()
        {
            //preparacion
            var nombreBd = Guid.NewGuid().ToString();//crea nombre aleatorio
            var context = BuildContext(nombreBd);// crea un contexto 
            var rol = new Rol() { Nombre = "Rol 1" };//creamos un nuevo rol manualmente                                     
            context.Roles.Add(rol);//agregamos el nuevo rol que acabos de crear
            await context.SaveChangesAsync();//guardamos

            var context2 = BuildContext(nombreBd);// crea un contexto2 para evitar problemas de contexto
            var repo = new RolRepositorio(context2);//pasamos el contexto que acabos de crear--instacion al repositorio
            var model = new RolEdicionModel() { Id = 1, Nombre = "Rol 1 modificado" };//cambiamos el nombre del rol para actualizarlo
            //ejecucion
            await repo.ActualizarRol(model);//actualizamos el nombre del rol
            var context3 = BuildContext(nombreBd);// crea un contexto2 para evitar problemas de contexto
            var rolModificado = await context3.Roles.FirstOrDefaultAsync(x => x.Id == 1);//aca traigo de la bd el rol que tenga el id 1
            var resultado = rolModificado.Nombre;//pasamos el nombre del rol modificado a resultado

            //verficiacion
            Assert.AreEqual("Rol 1 modificado", resultado);//verificamos el los roles se llamen iguales

        }

        [TestMethod]
        public async Task EliminarRol()
        {
            //preparacion
            var nombreBd = Guid.NewGuid().ToString();//crea nombre aleatorio
            var context = BuildContext(nombreBd);// crea un contexto 
            var rol = new Rol() { Nombre = "Rol 1" };//creamos un nuevo rol manualmente                                     
            context.Roles.Add(rol);//agregamos el nuevo rol que acabos de crear
            await context.SaveChangesAsync();//guardamos

            var context2 = BuildContext(nombreBd);// crea un contexto2 para evitar problemas de contexto
            var repo = new RolRepositorio(context2);//pasamos el contexto que acabos de crear--instancia al repositorio
            //ejecucion
            await repo.EliminarRol(1);//llamamos al metodo y le pasamos el id
            var context3 = BuildContext(nombreBd);// instanciamos un 3er contexto para validar lo que hay en la BD+
            var listaRoles = await context3.Roles.ToListAsync();//
            var resultado = listaRoles.Count;//

            //verficiacion

            Assert.AreEqual(0, resultado);//esperamos que el resultado de conteo en listado sea 0 

        }
    }
}
