using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinegram.Models.Entity
{
    public class Utente : BaseEntity
    {
        [Required]
        [MaxLength]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Bisogna accettare la privacy")]
        public bool IsPrivacy { get; set; }


    }
}