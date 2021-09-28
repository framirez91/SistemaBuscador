using System.ComponentModel.DataAnnotations;

namespace SistemaBuscador.Models
{
    public class RolCreacionModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }
    }
}