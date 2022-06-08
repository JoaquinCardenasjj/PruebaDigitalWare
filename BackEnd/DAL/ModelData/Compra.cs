using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDigitalWare.DAL.ModelData
{
    public partial class Compra
    {
        public Compra()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
        }

        public int IdCompra { get; set; }
        public DateTime FechaCompra { get; set; }
        public int ClienteId { get; set; }
        public decimal? Total { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}
