using Cinegram.Helpers;
using Cinegram.Models.Entity;
using Cinegram.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinegram.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            List<Film> film = DatabaseHelper.GetAllFilm();
            foreach (var p in film)
            {

            }
            var model = new IndexViewModel
            {
                Film = film
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var film = DatabaseHelper.GetFilmById(id);
            var model = new DetailViewModel
            {
                Film = film
            };
            if (film == null)
            {
                model.MessaggioErrore = "Prodotto non esistente";
                ViewBag.Title = "Errore";
            }
            else
            {
                ViewBag.Title = film.Nome;
            }
            return View(model);
        }
    }
}