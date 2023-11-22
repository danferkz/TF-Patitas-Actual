using System.ComponentModel.DataAnnotations;

namespace PATITAS.Models
{
    public class Diagnostico
    {
        [Key]
        public int Diagnostico_Id { get; set; }

        public string Sintomas { get; set; }

        public string Medicamentos { get; set; }

        public string DiagnosticoFinal { get; set; }

        public Cita Cita { get; set; }

    }
}
