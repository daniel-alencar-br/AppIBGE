using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppIBGE.Models
{
    public class NomesIBGE
    {
        public string nome { get; set; }
        public object sexo { get; set; }
        public string localidade { get; set; }
        public Re[] res { get; set; }
    }

    public class Re
    {
        public string periodo { get; set; }
        public int frequencia { get; set; }
    }    


}