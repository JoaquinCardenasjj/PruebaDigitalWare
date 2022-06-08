using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDigitalWare.DAL.ModelData
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int? Cantidad { get; set; }
        public string Iva { get; set; }

        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}
