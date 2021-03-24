using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinegram.Helpers;
using Cinegram.Models.Entity;
using Cinegram.Models.View;

namespace Cinegram.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Signup()
        {
            var model = new SignupViewModel();
            SetSignUpViewModelLabels(model);
            return View(model);
        }

        private void SetSignUpViewModelLabels(SignupViewModel model)
        {
            ViewBag.Title = model.LabelTitolo = "Registrazione";
            model.LabelConfermaPassword = "Conferma password";
            model.LabelEmail = "Indirizzo mail";
            model.LabelNome = "Nickname";
            model.LabelPassword = "Password";
            model.BtnRegistrazione = "Registrati";
            model.LabelPrivacy = "Accetta la <a href=\"\"> privacy</a>";
        }

        [HttpPost]
        public ActionResult Signup(SignupViewModel model)
        {
            ModelState.Remove("Utente.password");
            SetSignUpViewModelLabels(model);
            if (ModelState.IsValid)
            {
                if (DatabaseHelper.ExistsUtenteByEmail(model.Utente.Email))
                {
                    model.Messaggio = "Questa email è già presente nel database. Recupera password o cambia email";
                    model.IsSuccesso = false;
                    return View(model);
                }
                model.Utente.Password = string.Empty;
                var id = DatabaseHelper.InsertUtente(model.Utente);
                if (id > 0)
                {
                    model.Utente.Password = CryptoHelper.HashSHA256(id + model.Password);
                    bool result = DatabaseHelper.UpdatePassword(id, model.Utente.Password);
                    if (result)
                    {

                    }
                }
            }
            else
            {
                model.Messaggio = "Completa correttamente tutti i campi";
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        model.Messaggio += $"{error.ErrorMessage} ";
                    }
                }
                model.IsSuccesso = false;
            }


            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            SetLoginViewModelLabels(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            SetLoginViewModelLabels(model);
            if (!ModelState.IsValid)
                return View(model);
            var utente = DatabaseHelper.GetUtenteByEmail(model.Email);
            if (utente == null || CryptoHelper.HashSHA256(utente.Id + model.Password) != utente.Password)
            {
                model.MessaggioErrore = "Email e password non coincidono";
                return View(model);
            }
            Session["UtenteLoggato"] = utente;
            return RedirectToAction("Index", "AreaRiservata");
        }


        private void SetLoginViewModelLabels(LoginViewModel model)
        {
            ViewBag.Title = model.LabelTitoloLogin = "Login";
            model.LabelEmail = "Indirizzo mail";
            model.LabelPassword = "Password";
            model.LabelButtonInvia = "Entra";
        }

    }
}