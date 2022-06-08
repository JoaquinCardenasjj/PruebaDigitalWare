using PruebaDigitalWare.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.BL
{
   public interface IGeneralMethodsBl<T>
    {
        public ResponseRegister<T> Crear(T input);
        public ResponseRegister<T> Editar(T input);
        public ResponseRegister<T> Detalle(T input);
        public ResponseRegisterResult<T> Consultar(T input);
    }
}
