using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using PraktickaMaturita.Data;
using PraktickaMaturita.Models;

namespace PraktickaMaturita.Controllers
{
    public class PoznamkyController : Controller
    {
        private ArchivPoznamekData _databaze;

        public PoznamkyController(ArchivPoznamekData databaze)
        {
            _databaze = databaze;
        }

        [HttpGet]
        public IActionResult Pridat()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pridat(string nadpis, string popis)
        {
            if (nadpis == null || nadpis.Trim().Length == 0)
                return RedirectToAction("Pridat");

            Uzivatel? prihlasenyUzivatel = KdoJePrihlasen();

            Poznamka pridavanaPoznamka = new Poznamka()
            {
                DatumVlozeni = DateTime.Now,
                Nadpis = nadpis,
                Popis = popis,
                Autor = prihlasenyUzivatel,
            };

            _databaze.Add(pridavanaPoznamka);
            _databaze.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Vypsat()
        {
            Uzivatel? prihlasenyUzivatel = KdoJePrihlasen();

            if (prihlasenyUzivatel == null)
                return RedirectToAction("Prihlasit", "Uzivatel");

            List<Poznamka> vsechnyUkoly = _databaze.Poznamky
                .Where(u => u.Autor == prihlasenyUzivatel)
                .ToList();

            return View(vsechnyUkoly);
        }


        private Uzivatel? KdoJePrihlasen()
        {
            string? jmenoPrihlasenehoUzivatele = HttpContext.Session.GetString("Prihlaseny");

            if (jmenoPrihlasenehoUzivatele == null)
                return null;

            Uzivatel? prihlasenyUzivatel
                = _databaze.Uzivatele
                .Where(u => u.Jmeno == jmenoPrihlasenehoUzivatele)
                .FirstOrDefault();

            return prihlasenyUzivatel;
        }
    }
}
