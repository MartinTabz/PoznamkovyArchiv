using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PraktickaMaturita.Models;
using PraktickaMaturita.Data;
using System.Linq;

namespace PraktickaMaturita.Controllers
{
    public class PoznamkyController : Controller
    {
        private ArchivPoznamekData _databaze;

        public PoznamkyController(ArchivPoznamekData databaze)
        {
            _databaze = databaze;
        }
    }
}
