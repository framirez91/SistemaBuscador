using System.ComponentModel.DataAnnotations;

namespace SistemaBuscador.Models
{
    public class UsuarioEdicionModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre de usuario")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Apellidos { get; set; }
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? RolId { get; set; }
    }
}