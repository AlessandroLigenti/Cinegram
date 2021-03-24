using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinegram.Models.Entity;
using Cinegram.Models.View;

namespace Cinegram.Controllers
{
    public class AreaRiservataController : Controller
    {
        // GET: AreaRiservata
        [HttpGet]
        public ActionResult Index()
        {
            var utente = (Utente)Session["UtenteLoggato"];
            if (utente == null)
                return RedirectToAction("Login", "Account");
            var model = new ProfiloViewModel();
            SetProfiloViewModelLabels(model);
            model.Utente = utente;
            return View();
        }

        private void SetProfiloViewModelLabels(ProfiloViewModel model)
        {
            ViewBag.Title = model.LabelTitolo = "Profilo";
            model.LabelConfermaPassword = "Conferma password";
            model.LabelEmail = "Indirizzo mail";
            model.LabelNome = "Nickname";
            model.LabelPassword = "Password";
            model.BtnAggiorna = "Aggiorna";
        }


    }
}