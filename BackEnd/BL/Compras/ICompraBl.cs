using PruebaDigitalWare.DAL.Compras;
using PruebaDigitalWare.DTO;
using PruebaDigitalWare.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.BL.Compras
{
    public interface ICompraBl
    {
        public ResponseRegister<CompraGenerarFacturacionDto> GenerarFacturaciones(CompraGenerarFacturacionDto input);

    }
}
