using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class TransporteVehiculo
    {
        public int IdTransporteVehiculo { get; set; }
        public int IdTransporte { get; set; }
        public int IdVehiculo { get; set; }
        public bool Activo { get; set; }

        public virtual Transporte IdTransporteNavigation { get; set; } = null!;
        public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
    }
}
