using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Cinegram.Models.Entity;

namespace Cinegram.Models.View
{
    public class ProfiloViewModel
    {
        public string LabelTitolo { get; set; }
        public string LabelEmail { get; set; }
        public string LabelPassword { get; set; }
        public string LabelConfermaPassword { get; set; }
        public string LabelNome { get; set; }

        public string Messaggio { get; set; }
        public bool IsSuccesso { get; set; }

        public string BtnAggiorna { get; set; }


        public Utente Utente { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Le password non coincidono")]
        public string ConfermaPassword { get; set; }

    }
}