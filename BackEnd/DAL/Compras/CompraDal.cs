using AutoMapper;
using PruebaDigitalWare.BL;
using PruebaDigitalWare.DAL.ModelData;
using PruebaDigitalWare.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.DAL.Compras
{
    public class CompraDal : IGeneralMethodsDal<CompraDto>
    {
        private pruebaDigitalWareContext _context;
        private IMapper _mapper;
        public CompraDal(pruebaDigitalWareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<CompraDto> Consultar(CompraDto input)
        {
            List<CompraDto> listaCompras = new();
            var query = this._context.Compras.AsQueryable();
            if (input.ClienteId != 0)
            {
                query = query.Where(c => c.ClienteId == input.ClienteId);
            }

            if (input.FechaCompra != DateTime.MinValue)
            {
                query = query.Where(c => c.FechaCompra == input.FechaCompra);
            }

            listaCompras = this._mapper.Map<List<Compra>, List<CompraDto>>(query.ToList());
            return listaCompras;
        }

        public CompraDto Crear(CompraDto input)
        {
            var inputRegister = this._mapper.Map<Compra>(input);
            this._context.Compras.Add(inputRegister);
            this._context.SaveChanges();
            input.IdCompra = inputRegister.IdCompra;
            return input;
        }

        public CompraDto Detalle(CompraDto input)
        {
            CompraDto cliente = new();
            var query = this._context.Compras.Find(input.IdCompra);
            if (query != null)
            {
                cliente = this._mapper.Map<Compra, CompraDto>(query);
            }

            return cliente;
        }

        public CompraDto Editar(CompraDto input)
        {
            var query = this._context.Compras.Find(input.IdCompra);
            if (query != null)
            {
                this._mapper.Map<CompraDto, Compra>(input, query);
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
