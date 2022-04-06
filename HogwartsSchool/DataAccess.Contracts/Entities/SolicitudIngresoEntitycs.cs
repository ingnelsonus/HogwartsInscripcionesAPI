using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts.Entities
{
    public class SolicitudIngresoEntitycs:IEntity
    {
        public long Id { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(20, ErrorMessage = "Ingrese su nombre")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(20, ErrorMessage = "Ingrese sus apellidos")]
        [Required]
        public string Apellidos { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(10, ErrorMessage = "Ingrese su número de documento")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Solo se admiten numeros en el numero de documento")]
        [Required]
        public string Documento { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(2, ErrorMessage = "Ingrese su número de documento")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Solo se admiten numeros en el numero de documento")]
        [Required]
        public int Edad { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(10, ErrorMessage = "Ingrese su número de documento")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Solo se admiten numeros en el numero de documento")]        
        [Required]
        public string CasaHechicera { get; set; }

    }
}
