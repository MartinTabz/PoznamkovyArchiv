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

        public DateTime DatumVlozeni { get; set; } = DateTime.Now;

        [Required]
        virtual public Uzivatel? Autor { get; set; }
    }
}
