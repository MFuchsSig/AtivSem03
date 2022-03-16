using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtivSem03.Models
{
    public class Setor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Rg { get; set; }
        public string Sexo
        {
            get; set;
        }
    }
}