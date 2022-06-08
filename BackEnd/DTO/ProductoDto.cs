using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare.DTO
{
    public class ProductoDto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int? Cantidad { get; set; }
        public string Iva { get; set; }
    }
}
