using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaDigitalWare.BL;
using PruebaDigitalWare.BL.Clientes;
using PruebaDigitalWare.BL.Compras;
using PruebaDigitalWare.DTO;
using PruebaDigitalWare.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private IGeneralMethodsBl<CompraDto> _generalMethods;
        private ICompraBl _compraBl;
        public CompraController(IGeneralMethodsBl<CompraDto> generalMethods, ICompraBl compraBl)
        {
            _generalMethods = generalMethods;
            _compraBl = compraBl;
        }

        [HttpGet]
        [Route("consultar")]
        public IActionResult Consultar(int ClienteId, DateTime FechaCompra)
        {
            CompraDto input = new CompraDto()
            {
                FechaCompra = FechaCompra,
                ClienteId = ClienteId
            };
            return Ok(this._generalMethods.Consultar(input));
        }
        [HttpPost]
        [Route("crear")]
        public IActionResult Crear(CompraDto input)
        {
            return Ok(this._generalMethods.Crear(input));
        }
        [HttpPut]
        [Route("editar")]
        public IActionResult Editar(CompraDto input)
        {
            return Ok(this._generalMethods.Editar(input));
        }
        [HttpGet]
        [Route("detalle")]
        public IActionResult Detalle(int IdCompra)
        {
            CompraDto input = new CompraDto()
            {
                IdCompra = IdCompra
            };
            return Ok(this._generalMethods.Detalle(input));
        }
        [HttpPost]
        [Route("generarFacturacion")]
        public IActionResult GenerarFacturaciones(CompraGenerarFacturacionDto input)
        {

            return Ok(this._compraBl.GenerarFacturaciones(input));
        }
    }
}
