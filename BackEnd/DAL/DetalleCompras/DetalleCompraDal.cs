using AutoMapper;
using PruebaDigitalWare.BL;
using PruebaDigitalWare.DAL.ModelData;
using PruebaDigitalWare.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.DAL.DetalleCompras
{
    public class DetalleCompraDal : IGeneralMethodsDal<DetalleCompraDto>
    {
        private pruebaDigitalWareContext _context;
        private IMapper _mapper;
        public DetalleCompraDal(pruebaDigitalWareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<DetalleCompraDto> Consultar(DetalleCompraDto input)
        {
            List<DetalleCompraDto> listaCompras = new();
            var query = this._context.DetalleCompras.AsQueryable();
            if (input.ProductoId != 0)
            {
                query = query.Where(c => c.ProductoId == input.ProductoId);
            }
            if (input.CompraId != 0)
            {
                query = query.Where(c => c.CompraId == input.CompraId);
            }
            
            listaCompras = this._mapper.Map<List<DetalleCompra>, List<DetalleCompraDto>>(query.ToList());
            return listaCompras;
        }

        public DetalleCompraDto Crear(DetalleCompraDto input)
        {
            var inputRegister = this._mapper.Map<DetalleCompra>(input);
            this._context.DetalleCompras.Add(inputRegister);
            this._context.SaveChanges();
            input.IdDetalleCompra = inputRegister.IdDetalleCompra;
            return input;
        }

        public DetalleCompraDto Detalle(DetalleCompraDto input)
        {
            DetalleCompraDto cliente = new();
            var query = this._context.DetalleCompras.Find(input.IdDetalleCompra);
            if (query != null)
            {
                cliente = this._mapper.Map<DetalleCompra, DetalleCompraDto>(query);
            }

            return cliente;
        }

        public DetalleCompraDto Editar(DetalleCompraDto input)
        {
            var query = this._context.DetalleCompras.Find(input.IdDetalleCompra);
            if (query != null)
            {
                this._mapper.Map<DetalleCompraDto, DetalleCompra>(input, query);
                this._context.SaveChanges();
            }
            else
            {
                return null;
            }

            return input;
        }
    }
}
