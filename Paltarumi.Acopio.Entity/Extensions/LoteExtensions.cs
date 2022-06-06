using Paltarumi.Acopio.Common;

namespace Paltarumi.Acopio.Entity.Extensions
{
    public static class LoteExtensions
    {
        public static void Enable(this Lote lote)
            => lote.Activo = true;

        public static void UpdateCreation(this Lote lote)
            => lote.CreateDate = DateTime.Now;

        public static void UpdateVehiculos(this Lote lote, IEnumerable<Vehiculo> vehiculos)
            => lote.Vehiculos = string.Join(",", vehiculos.Select(x => x.Placa));

        public static void UpdateTransportistas(this Lote lote, IEnumerable<Transporte> transportistas)
            => lote.Transportistas = string.Join(",", transportistas.Select(x => x.RazonSocial));

        public static void UpdateConductores(this Lote lote, IEnumerable<Conductor> conductores)
            => lote.Conductores = string.Join(",", conductores.Select(x => x.RazonSocial));

        public static void UpdateCantidadSacos(this Lote lote)
            => lote.CantidadSacos = lote?.Tickets?.Count(x => x.IdUnidadMedida == Constants.Maestro.UnidadMedida.SACOS).ToString() ?? String.Empty;

        public static void UpdateFechaIngreso(this Lote lote)
            => lote.FechaIngreso = lote?.Tickets?.Min(x => x.FechaIngreso) ?? DateTime.Now;

        public static void UpdateHoraIngreso(this Lote lote)
            => lote.HoraIngreso = lote?.Tickets?.Min(x => x.FechaIngreso).ToString("HH:mm") ?? string.Empty;

        public static void UpdateFechaAcopio(this Lote lote)
            => lote.FechaAcopio = lote?.Tickets?.Min(x => x.FechaSalida) ?? DateTime.Now;

        public static void UpdateHoraAcopio(this Lote lote)
            => lote.HoraAcopio = lote?.Tickets?.Min(x => x.FechaSalida)?.ToString("HH:mm") ?? string.Empty;

        public static void UpdateTms(this Lote lote)
            => lote.Tms = lote?.Tickets?.Sum(x => x.PesoNeto) ?? 0;

        public static void UpdateTms100(this Lote lote)
            => lote.Tms100 = lote?.Tickets?.Sum(x => x.PesoNeto100) ?? 0;

        public static void UpdateTmsBase(this Lote lote)
            => lote.TmsBase = lote?.Tickets?.Sum(x => x.PesoNetoBase) ?? 0;

        public static void UpdateNumeroTickets(this Lote lote)
            => lote.NumeroTickets = string.Join(",", lote.Tickets.Select(x => x.Numero));
    }
}
