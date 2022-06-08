using AutoMapper;
using PruebaDigitalWare.BL;
using PruebaDigitalWare.DAL.ModelData;
using PruebaDigitalWare.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.DAL.Productos
{
    public class ProductoDal : IGeneralMethodsDal<ProductoDto>
    {
        private pruebaDigitalWareContext _context;
        private IMapper _mapper;
        public ProductoDal(pruebaDigitalWareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ProductoDto> Consultar(ProductoDto input)
        {
            List<ProductoDto> listaProductos = new();
            var query = this._context.Productos.AsQueryable();
            if (!string.IsNullOrEmpty(input.Nombre))
            {
                query = query.Where(c => c.Nombre.ToUpper().Contains(input.Nombre.ToUpper()));
            }
            if (input.Precio != null)
            {
                query = query.Where(c => c.Precio == input.Precio);
            }
            if (input.Cantidad != null)
            {
                query = query.Where(c => c.Cantidad == input.Cantidad);
            }

            listaProductos = this._mapper.Map<List<Producto>, List<ProductoDto>>(query.ToList());
            return listaProductos;
        }

        public ProductoDto Crear(ProductoDto input)
        {
            var inputRegister = this._mapper.Map<Producto>(input);
            this._context.Productos.Add(inputRegister);
            this._context.SaveChanges();
            input.IdProducto = inputRegister.IdProducto;
            return input;
        }

        public ProductoDto Detalle(ProductoDto input)
        {
            ProductoDto cliente = new();
            var query = this._context.Productos.Find(input.IdProducto);
            if (query != null)
            {
                cliente = this._mapper.Map<Producto, ProductoDto>(query);
            }

            return cliente;
        }

        public ProductoDto Editar(ProductoDto input)
        {
            var query = this._context.Productos.Find(input.IdProducto);
            if (query != null)
            {
                this._mapper.Map<ProductoDto, Producto>(input, query);
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
