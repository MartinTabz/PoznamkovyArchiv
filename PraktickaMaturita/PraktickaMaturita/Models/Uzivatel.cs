using System.ComponentModel.DataAnnotations;

namespace PraktickaMaturita.Models
{
    public class Uzivatel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

        [Required]
        public string Email { get; set; } = String.Empty;

        [Required]
        public string Heslo { get; set; } = String.Empty;

        [Required]
        virtual public List<Poznamka>? Poznamky { get; set; }


    }
}
