using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDigitalWare.DAL.ModelData
{
    public partial class Cliente
    {
        public Cliente()
        {
            Compras = new HashSet<Compra>();
        }

        public int IdCliente { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
