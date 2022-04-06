using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsSchool.Api.Bussiness.Models
{
    public class SolicitudIngreso 
    {
        public string Id { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(20, ErrorMessage = "Ingrese su nombre")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(20, ErrorMessage = "Ingrese sus apellidos")]
        [Required]
        public string Apellidos { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(10, ErrorMessage = "Ingrese su número de documento")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Solo se admiten numeros")]
        [Required]
        public string Documento { get; set; }


        [Display(Name = "Edad")]
        [RegularExpression("(^[0-9]*$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        [StringLength(2, ErrorMessage = "El número es demasiado largo")]
        public string Edad { get; set; }

        [Display(Name = "CasaHechicera")]
        [MaxLength(10, ErrorMessage = "Ingrese su número de documento")]        
        [Required]
        public string CasaHechicera { get; set; }


    }
}
