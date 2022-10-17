using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class CuentaProveedor
    {
        public int IdCuentaProveedor { get; set; }
        public int IdProveedor { get; set; }
        public decimal Facturado { get; set; }
        public decimal FacturadoPagado { get; set; }
        public decimal NoFacturado { get; set; }
        public decimal Proyectado { get; set; }
        public bool Activo { get; set; }
    }
}
