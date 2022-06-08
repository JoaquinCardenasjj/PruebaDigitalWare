using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.Util
{
    public class ResponseRegisterResult<T>
    {
        public List<T> ObjetoResultado { get; set; }
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public int CodigoResultado { get; set; }
    }
}
