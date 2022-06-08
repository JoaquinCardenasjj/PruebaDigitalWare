using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaDigitalWare.BL;
using PruebaDigitalWare.BL.Clientes;
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
    public class DetalleCompraController : ControllerBase
    {
        private IGeneralMethodsBl<DetalleCompraDto> _generalMethods;
        public DetalleCompraController(IGeneralMethodsBl<DetalleCompraDto> generalMethods)
        {
            _generalMethods = generalMethods;
        }

        [HttpGet]
        [Route("consultar")]
        public IActionResult Consultar(int? ProductoId, int? CompraId)
        {
            DetalleCompraDto input = new DetalleCompraDto()
            {
                ProductoId = ProductoId,
                CompraId = CompraId
            };
            return Ok(this._generalMethods.Consultar(input));
        }
        [HttpPost]
        [Route("crear")]
        public IActionResult Crear(DetalleCompraDto input)
        {
            return Ok(this._generalMethods.Crear(input));
        }
        [HttpPut]
        [Route("editar")]
        public IActionResult Editar(DetalleCompraDto input)
        {
            return Ok(this._generalMethods.Editar(input));
        }
        [HttpGet]
        [Route("detalle")]
        public IActionResult Detalle(int IdDetalleCompra)
        {
            DetalleCompraDto input = new DetalleCompraDto()
            {
                IdDetalleCompra = IdDetalleCompra
            };
            return Ok(this._generalMethods.Detalle(input));
        }
    }
}
