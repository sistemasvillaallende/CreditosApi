using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditosApi.Entities.LOGIN
{
    [Table("USUARIOS_V2")]
    public class Usuario
    {
        [Key]
        [Column("Cod_usuario")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Column("Nombre")]
        public string User { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
        [Column("Nombre_completo")]
        public string Nombre_completo { get; set; }
        public string Celular { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo debe ser un correo electrónico válido")]
        public string Email { get; set; }
        public bool Administrador { get; set; }
        public string Tipo { get; set; }
        [Display(Name = "Recuérdame")]
        public bool Recuerdame { get; set; }
    }
}
