using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinegram.Models.Entity
{
    public class Film : BaseEntity
    {
        public string Nome { get; set; }
        public string Regista { get; set; }

    }
}