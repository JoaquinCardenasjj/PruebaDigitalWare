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
    public class ProductoController : ControllerBase
    {
        private IGeneralMethodsBl<ProductoDto> _generalMethods;
        public ProductoController(IGeneralMethodsBl<ProductoDto> generalMethods)
        {
            _generalMethods = generalMethods;
        }

        [HttpGet]
        [Route("consultar")]
        public IActionResult Consultar(string Nombre, decimal? Precio, int? Cantidad)
        {
            ProductoDto input = new ProductoDto()
            {
                Nombre = Nombre,
                Precio = Precio,
                Cantidad = Cantidad
            };
            return Ok(this._generalMethods.Consultar(input));
        }
        [HttpPost]
        [Route("crear")]
        public IActionResult Crear(ProductoDto input)
        {
            return Ok(this._generalMethods.Crear(input));
        }
        [HttpPut]
        [Route("editar")]
        public IActionResult Editar(ProductoDto input)
        {
            return Ok(this._generalMethods.Editar(input));
        }
        [HttpGet]
        [Route("detalle")]
        public IActionResult Detalle(int IdProducto)
        {
            ProductoDto input = new ProductoDto()
            {
                IdProducto = IdProducto
            };
            return Ok(this._generalMethods.Detalle(input));
        }
    }
}
