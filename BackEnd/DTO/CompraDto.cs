using PruebaDigitalWare.DAL.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.DTO
{
    public class CompraDto
    {
        public int IdCompra { get; set; }
        public DateTime FechaCompra { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente{ get; set; }
        public decimal? Total { get; set; }        
        
    }
}
