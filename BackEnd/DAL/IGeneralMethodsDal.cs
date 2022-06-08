using AutoMapper;
using PruebaDigitalWare.DAL.ModelData;
using PruebaDigitalWare.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.BL
{
    public interface IGeneralMethodsDal<T>
    {      
        public T Crear(T input);
        public T Editar(T input);
        public T Detalle(T input);
        public List<T> Consultar(T input);
    }
}
