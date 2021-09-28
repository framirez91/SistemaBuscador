using System.ComponentModel.DataAnnotations;

namespace SistemaBuscador.Models
{
    public class RolEdicionModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }
    }
}