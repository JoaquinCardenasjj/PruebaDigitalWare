using PruebaDigitalWare.DAL.Productos;
using PruebaDigitalWare.DTO;
using PruebaDigitalWare.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.BL.Productos
{
    public class ProductoBl : IGeneralMethodsBl<ProductoDto>
    {
        public IGeneralMethodsDal<ProductoDto> productoI;
        public ProductoBl(IGeneralMethodsDal<ProductoDto> _IProducto)
        {
            productoI = _IProducto;
        }
        public ResponseRegisterResult<ProductoDto> Consultar(ProductoDto input)
        {
            ResponseRegisterResult<ProductoDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.productoI.Consultar(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<ProductoDto> Crear(ProductoDto input)
        {
            ResponseRegister<ProductoDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.productoI.Crear(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<ProductoDto> Detalle(ProductoDto input)
        {
            ResponseRegister<ProductoDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.productoI.Detalle(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<ProductoDto> Editar(ProductoDto input)
        {
            ResponseRegister<ProductoDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.productoI.Editar(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }
    }
}
