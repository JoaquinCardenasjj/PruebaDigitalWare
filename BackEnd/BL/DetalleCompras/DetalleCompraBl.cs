
using PruebaDigitalWare.DTO;
using PruebaDigitalWare.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.BL.DetalleCompras
{
    public class DetalleCompraBl : IGeneralMethodsBl<DetalleCompraDto>
    {
        public IGeneralMethodsDal<DetalleCompraDto> detalleCompraI;
        public DetalleCompraBl(IGeneralMethodsDal<DetalleCompraDto> _IDetalleCompra)
        {
            detalleCompraI = _IDetalleCompra;
        }
        public ResponseRegisterResult<DetalleCompraDto> Consultar(DetalleCompraDto input)
        {
            ResponseRegisterResult<DetalleCompraDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.detalleCompraI.Consultar(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<DetalleCompraDto> Crear(DetalleCompraDto input)
        {
            ResponseRegister<DetalleCompraDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.detalleCompraI.Crear(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<DetalleCompraDto> Detalle(DetalleCompraDto input)
        {
            ResponseRegister<DetalleCompraDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.detalleCompraI.Detalle(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<DetalleCompraDto> Editar(DetalleCompraDto input)
        {
            ResponseRegister<DetalleCompraDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.detalleCompraI.Editar(input);
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
