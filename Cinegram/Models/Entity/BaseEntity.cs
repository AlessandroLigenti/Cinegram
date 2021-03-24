using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinegram.Models.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Creazione { get; set; }
        public DateTime? Modifica { get; set; }
    }
}