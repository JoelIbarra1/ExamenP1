using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenP1.Models
{
    public class Carrera
    {
        [Key, ForeignKey("Estudiante")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la carrera es requerido.")]
        [StringLength(100, ErrorMessage = "El nombre de la carrera no puede tener más de 100 caracteres.")]
        public string NombreCarrera { get; set; }
        [Required(ErrorMessage = "El campus es requerido.")]
        public string Campus { get; set; }
        [Required(ErrorMessage = "El número de semestres es requerido.")]
        [Range(1, 10, ErrorMessage = "El número de semestres debe estar entre 1 y 10.")]
        public int NumeroSemestres { get; set; }
        public virtual JIbarra Estudiante { get; set; }
    }
}
