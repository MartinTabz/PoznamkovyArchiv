using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using PraktickaMaturita.Data;
using PraktickaMaturita.Models;

namespace PraktickaMaturita.Controllers
{
    public class UzivatelController : Controller
    {
        private ArchivPoznamekData _databaze;

        public UzivatelController(ArchivPoznamekData databaze)
        {
            _databaze = databaze;
        }

        [HttpGet]
        public IActionResult Registrovat()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrovat(string jmeno, string heslo, string hesloKontrola, string email)
        {
            if (jmeno != null)
                jmeno = jmeno.Trim().ToLower();
            if (heslo != null)
                heslo = heslo.Trim();

            if (jmeno.Length == 0)
                return RedirectToAction("Registrovat");
            if (heslo.Length == 0)
                return RedirectToAction("Registrovat");
            if (heslo != hesloKontrola)
                return RedirectToAction("Registrovat");

            Uzivatel? existujiciUzivatel = _databaze.Uzivatele
                .Where(u => u.Jmeno == jmeno)
                .FirstOrDefault();

            if (existujiciUzivatel != null)
                return RedirectToAction("Registrovat");

            Uzivatel novyUzivatel = new Uzivatel()
            {
                Jmeno = jmeno,
                Heslo = heslo,
                Email = email,
            };

            _databaze.Add(novyUzivatel);
            _databaze.SaveChanges();

            return RedirectToAction("Prihlasit");
        }

        [HttpGet]
        public IActionResult Prihlasit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Prihlasit(string jmeno, string heslo)
        {
            if (jmeno == null || jmeno.Trim().Length == 0)
                return RedirectToAction("Prihlasit");
            if (heslo == null || heslo.Trim().Length == 0)
                return RedirectToAction("Prihlasit");

            Uzivatel? prihlasovanyUzivatel = _databaze.Uzivatele
                .Where(u => u.Jmeno == jmeno)
                .FirstOrDefault();

            if (prihlasovanyUzivatel == null)
                return RedirectToAction("Prihlasit");
            if (prihlasovanyUzivatel.Heslo != heslo)
                return RedirectToAction("Prihlasit");

            HttpContext.Session.SetString("Prihlaseny", prihlasovanyUzivatel.Jmeno);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Odhlasit()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Smazat()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Smazat()
        {
            Uzivatel? prihlasenyUzivatel = KdoJePrihlasen();

            if (prihlasenyUzivatel == null)
                return RedirectToAction("Prihlasit", "Uzivatel");

            Uzivatel? mazanyUzivatel = _databaze.Uzivatele
                .Where(u = u.Id == id)
                .FirstOrDefault();

            if (mazanyUzivatel != null && mazanyUzivatel.Autor == prihlasenyUzivatel)
            {
                _databaze.Uzivatele.Remove(mazanyUzivatel);
                _databaze.SaveChanges();
            }

            
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
