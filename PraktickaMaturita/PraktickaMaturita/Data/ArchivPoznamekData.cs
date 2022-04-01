using Microsoft.EntityFrameworkCore;
using PraktickaMaturita.Models;

namespace PraktickaMaturita.Data
{
    public class ArchivPoznamekData : DbContext
    {
        public ArchivPoznamekData(DbContextOptions<ArchivPoznamekData> options) : base(options) { }

        public DbSet<Uzivatel> Uzivatele { get; set; }
        public DbSet<Poznamka> Poznamky { get; set; }
    }
}
