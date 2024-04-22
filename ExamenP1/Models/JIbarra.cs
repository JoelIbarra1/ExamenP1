using System.ComponentModel.DataAnnotations;

namespace ExamenP1.Models
{
    public class JIbarra
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Peso { get; set; }
        public bool Madrilista { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public virtual Carrera Carrera { get; set; }



    }
}
