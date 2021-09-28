using System.Collections.Generic;

namespace SistemaBuscador.Entities
{
    public class Rol
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public List<Usuario> Usuario { get; set; }



    }
}
