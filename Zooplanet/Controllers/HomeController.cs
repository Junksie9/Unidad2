using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zooplanet.Models;

namespace Zooplanet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        [Route("Segun-Su-Clase")]
        public IActionResult Clases()
        {
            
            animalesContext context = new animalesContext();
            var clas = context.Clases.Include(x => x.Especies).OrderBy(x => x.Nombre);
            if (clas == null)
            {
                return RedirectToAction("Index");
            }
            return View(clas);
        }

        [Route("Segun-Su-Habitat")]
        public IActionResult Habitat()
        {

            animalesContext context = new animalesContext();
            var habi = context.Especies.Include(x => x.IdClaseNavigation).OrderBy(x => x.Habitat);


            if (habi == null)
            {
                return RedirectToAction("Index");
            }
            return View(habi);
        }
    }
}
