using System;

namespace SistemaBuscador.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public int RolId { get; set; }
        public string Password { get; set; }

        public Rol Rol { get; set; }
    }
}
