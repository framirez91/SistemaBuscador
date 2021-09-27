using System.ComponentModel.DataAnnotations;

namespace SistemaBuscador.Models
{
    public class UsuarioCreacionModel
    {
        [Display(Name = "Nombre de usuario")]
        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        public string Apellidos { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        public int? RolId { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [MinLength(8, ErrorMessage = "El Campo {0} debe tener como minimo {1} Caracteres")]


        [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$", ErrorMessage = "La contraseña debe tener minimo 8 caracteres, al menos un dígito, al menos una minúscula y al menos una mayúscula.")]
        public string Password { get; set; }

        [Display(Name = "Repetir Constraseña")]
        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [MinLength(8, ErrorMessage = "El Campo {0} debe tener como minimo {1} Caracteres")]

        [RegularExpression("^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$", ErrorMessage = "La contraseña debe tener minimo 8 caracteres, al menos un dígito, al menos una minúscula y al menos una mayúscula.")]
        [Compare("Password", ErrorMessage = "Las Contraseñas no son iguales")]

        public string RePassword { get; set; }
    }
}