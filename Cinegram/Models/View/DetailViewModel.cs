using Cinegram.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinegram.Models.View
{
    public class DetailViewModel
    {
        public Film Film { get; set; }
        public string MessaggioErrore { get; set; }
    }
}