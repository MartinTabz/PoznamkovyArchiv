using System.ComponentModel.DataAnnotations;

namespace PraktickaMaturita.Models
{
    public class Poznamka
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nadpis { get; set; } = String.Empty;

        public string Popis { get; set; } = String.Empty;

        [Required]
        public DateTime? Vlozeni { get; set; }

        [Required]
        virtual public Uzivatel? Autor { get; set; }
    }
}
