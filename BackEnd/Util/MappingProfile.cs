using AutoMapper;
using PruebaDigitalWare.DAL.ModelData;
using PruebaDigitalWare.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.Util
{
    public class MappingProfile : Profile
    {
        public MappingProfile ()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Compra, CompraDto>().ReverseMap();
            CreateMap<DetalleCompra, DetalleCompraDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
        }
    }
}
