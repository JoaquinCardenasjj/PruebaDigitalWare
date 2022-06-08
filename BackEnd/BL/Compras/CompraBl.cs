using PruebaDigitalWare.DAL.Compras;
using PruebaDigitalWare.DTO;
using PruebaDigitalWare.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.BL.Compras
{
    public class CompraBl : IGeneralMethodsBl<CompraDto>, ICompraBl
    {
        public IGeneralMethodsDal<CompraDto> compraI;
        public IGeneralMethodsDal<ClienteDto> clienteI;
        public IGeneralMethodsDal<ProductoDto> productoI;
        public IGeneralMethodsBl<DetalleCompraDto> detalleCompraI;
        public CompraBl(IGeneralMethodsDal<CompraDto> _ICompra, IGeneralMethodsDal<ClienteDto> _ICliente,
             IGeneralMethodsDal<ProductoDto> _IProducto, IGeneralMethodsBl<DetalleCompraDto> _IDetalleCompra)
        {
            compraI = _ICompra;
            clienteI = _ICliente;
            productoI = _IProducto;
            detalleCompraI = _IDetalleCompra;
        }
        public ResponseRegisterResult<CompraDto> Consultar(CompraDto input)
        {
            ResponseRegisterResult<CompraDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.compraI.Consultar(input);
                response.ObjetoResultado.ForEach(d =>
                {
                    ClienteDto inputClienteDetalle = new ClienteDto
                    {
                        IdCliente = d.ClienteId
                    };
                    d.NombreCliente = this.clienteI.Detalle(inputClienteDetalle).NombreCompleto;
                });
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<CompraDto> Crear(CompraDto input)
        {
            ResponseRegister<CompraDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.compraI.Crear(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<CompraDto> Detalle(CompraDto input)
        {
            ResponseRegister<CompraDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.compraI.Detalle(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<CompraDto> Editar(CompraDto input)
        {
            ResponseRegister<CompraDto> response = new();
            try
            {
                response.Exitoso = true;
                response.ObjetoResultado = this.compraI.Editar(input);
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }

        public ResponseRegister<CompraGenerarFacturacionDto> GenerarFacturaciones(CompraGenerarFacturacionDto input)
        {
            ResponseRegister<CompraGenerarFacturacionDto> response = new();
            try
            {
                response.Exitoso = true;
                var totalCompra = this.CalculoListaDetalleCompraYValorTotal(input);

                CompraDto compraDto = new CompraDto
                {
                    ClienteId = input.ClienteId,
                    FechaCompra = input.FechaCompra,
                    Total = totalCompra
                };

                var responseCrearCompra = this.Crear(compraDto);
                response.Exitoso = this.RegistroDetalleCompra(input, responseCrearCompra.ObjetoResultado).Exitoso;
            }
            catch (Exception ex)
            {
                response.CodigoResultado = ex.Data.Count;
                response.Mensaje = ex.Message;
                response.Exitoso = false;
            }

            return response;
        }
        public decimal CalculoListaDetalleCompraYValorTotal(CompraGenerarFacturacionDto input)
        {
            decimal totalCompra = 0;
            input.ListaDetalleCompra.ForEach(d =>
            {
                var inputProducto = new ProductoDto
                {
                    IdProducto = d.ProductoId.Value
                };
                var productoDetalle = this.productoI.Detalle(inputProducto);
                if (productoDetalle != null)
                {
                    d.SubTotal = d.CantidadComprada * productoDetalle.Precio;
                    totalCompra += d.SubTotal.Value;
                    d.Iva = productoDetalle.Iva;
                }
            });

            return totalCompra;
        }

        public ResponseRegister<CompraDto> RegistroDetalleCompra(CompraGenerarFacturacionDto input, CompraDto responseCrearCompra)
        {
            ResponseRegister<CompraDto> response = new();
            input.ListaDetalleCompra.ForEach(d =>
            {
                var inputDetalleCompra = new DetalleCompraDto
                {
                    ProductoId = d.ProductoId.Value,
                    CompraId = responseCrearCompra.IdCompra,
                    CantidadComprada = d.CantidadComprada,
                    Iva = d.Iva,
                    SubTotal = d.SubTotal
                };
                var responseDetalleCompra = this.detalleCompraI.Crear(inputDetalleCompra);
                if (!responseDetalleCompra.Exitoso)
                {
                    response.Exitoso = false;
                }
            });

            return response;
        }
    }
}
