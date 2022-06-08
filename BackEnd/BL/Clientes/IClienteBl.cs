using PruebaDigitalWare.DAL.Clientes;
using PruebaDigitalWare.DTO;
using PruebaDigitalWare.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.BL.Clientes
{
    public interface IClienteBl
    {
        public ResponseRegister<CompraGenerarFacturacionDto> GenerarFacturaciones(CompraGenerarFacturacionDto input);
        
    }
}
