using AutoMapper;
using PruebaDigitalWare.BL;
using PruebaDigitalWare.DAL.ModelData;
using PruebaDigitalWare.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.DAL.Clientes
{
    public class ClienteDal : IGeneralMethodsDal<ClienteDto>
    {
        private pruebaDigitalWareContext _context;
        private IMapper _mapper;
        public ClienteDal(pruebaDigitalWareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ClienteDto> Consultar(ClienteDto input)
        {
            List<ClienteDto> listaClientes = new();
            var query = this._context.Clientes.AsQueryable();
            if (!string.IsNullOrEmpty(input.Identificacion))
            {
                query = query.Where(c => c.Identificacion.ToUpper().Contains(input.Identificacion.ToUpper()));
            }
            if (!string.IsNullOrEmpty(input.NombreCompleto))
            {
                query = query.Where(c => c.NombreCompleto.ToUpper().Contains(input.NombreCompleto.ToUpper()));
            }

            listaClientes = this._mapper.Map<List<Cliente>, List<ClienteDto>>(query.ToList());
            return listaClientes;
        }

        public ClienteDto Crear(ClienteDto input)
        {
            var inputRegister = this._mapper.Map<Cliente>(input);
            this._context.Clientes.Add(inputRegister);
            this._context.SaveChanges();
            input.IdCliente = inputRegister.IdCliente;
            return input;
        }

        public ClienteDto Detalle(ClienteDto input)
        {
            ClienteDto cliente = new();
            var query = this._context.Clientes.Find(input.IdCliente);
            if (query != null)
            {
                cliente = this._mapper.Map<Cliente, ClienteDto>(query);
            }

            return cliente;
        }

        public ClienteDto Editar(ClienteDto input)
        {
            var query = this._context.Clientes.Find(input.IdCliente);
            if (query != null)
            {
                this._mapper.Map<ClienteDto, Cliente>(input, query);
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
