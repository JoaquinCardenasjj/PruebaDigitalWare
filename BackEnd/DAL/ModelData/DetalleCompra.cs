using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDigitalWare.DAL.ModelData
{
    public partial class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public int? ProductoId { get; set; }
        public int? CompraId { get; set; }
        public int? CantidadComprada { get; set; }
        public decimal? SubTotal { get; set; }
        public string Iva { get; set; }

        public virtual Compra Compra { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
