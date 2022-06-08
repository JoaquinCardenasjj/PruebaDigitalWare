using PruebaDigitalWare.DAL.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.DTO
{
    public class DetalleCompraDto
    {
        public int IdDetalleCompra { get; set; }
        public int? ProductoId { get; set; }
        public int? CompraId { get; set; }
        public int? CantidadComprada { get; set; }
        public decimal? SubTotal { get; set; }
        public string Iva { get; set; }        
    }
}
