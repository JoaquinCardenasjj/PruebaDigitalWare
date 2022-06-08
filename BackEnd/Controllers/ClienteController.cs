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
    public class ClienteController : ControllerBase
    {
        private IGeneralMethodsBl<ClienteDto> _generalMethods;
        public ClienteController(IGeneralMethodsBl<ClienteDto> generalMethods)
        {
            _generalMethods = generalMethods;
        }

        [HttpGet]
        [Route("consultar")]
        public IActionResult Consultar(string NombreCompleto, string Identificacion)
        {
            ClienteDto input = new ClienteDto()
            {
                NombreCompleto = NombreCompleto,
                Identificacion = Identificacion
            };
            return Ok(this._generalMethods.Consultar(input));
        }
        [HttpPost]
        [Route("crear")]
        public IActionResult Crear(ClienteDto input)
        {
            return Ok(this._generalMethods.Crear(input));
        }
        [HttpPut]
        [Route("editar")]
        public IActionResult Editar(ClienteDto input)
        {
            return Ok(this._generalMethods.Editar(input));
        }
        [HttpGet]
        [Route("detalle")]
        public IActionResult Detalle(int IdCliente)
        {
            ClienteDto input = new ClienteDto()
            {
                IdCliente = IdCliente
            };
            return Ok(this._generalMethods.Detalle(input));
        }
    }
}
