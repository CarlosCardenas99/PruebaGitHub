using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdVehiculo { get; set; }
        public int IdTipoVehiculo { get; set; }
        public int IdVehiculoMarca { get; set; }
        public string Placa { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual Maestro IdTipoVehiculoNavigation { get; set; } = null!;
        public virtual Maestro IdVehiculoMarcaNavigation { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
