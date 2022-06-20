using Paltarumi.Acopio.Common;

namespace Paltarumi.Acopio.Entity.Extensions
{
    public static class LoteExtensions
    {
        public static void Enable(this LoteBalanza loteBalanza)
            => loteBalanza.Activo = true;

        public static void UpdateCreation(this LoteBalanza loteBalanza)
            => loteBalanza.CreateDate = DateTime.Now;

        public static void UpdateVehiculos(this LoteBalanza loteBalanza, IEnumerable<Vehiculo> vehiculos)
            => loteBalanza.Vehiculos = string.Join(",", vehiculos.Select(x => x.Placa));

        public static void UpdateTransportistas(this LoteBalanza loteBalanza, IEnumerable<Transporte> transportistas)
            => loteBalanza.Transportistas = string.Join(",", transportistas.Select(x => x.RazonSocial));

        public static void UpdateConductores(this LoteBalanza loteBalanza, IEnumerable<Conductor> conductores)
            => loteBalanza.Conductores = string.Join(",", conductores.Select(x => x.Nombres));

        public static void UpdateCantidadSacos(this LoteBalanza loteBalanza)
            => loteBalanza.CantidadSacos = loteBalanza?.Tickets?.Count(x => x.IdUnidadMedida == Constants.Maestro.UnidadMedida.SACOS).ToString() ?? String.Empty;

        public static void UpdateFechaIngreso(this LoteBalanza loteBalanza)
            => loteBalanza.FechaIngreso = loteBalanza?.Tickets?.Min(x => x.FechaIngreso) ?? DateTime.Now;

        public static void UpdateHoraIngreso(this LoteBalanza loteBalanza)
            => loteBalanza.HoraIngreso = loteBalanza?.Tickets?.Min(x => x.FechaIngreso).ToString("HH:mm") ?? string.Empty;

        public static void UpdateFechaAcopio(this LoteBalanza loteBalanza)
            => loteBalanza.FechaAcopio = loteBalanza?.Tickets?.Max(x => x.FechaSalida) ?? DateTime.Now;

        public static void UpdateHoraAcopio(this LoteBalanza loteBalanza)
            => loteBalanza.HoraAcopio = loteBalanza?.Tickets?.Max(x => x.FechaSalida)?.ToString("HH:mm") ?? string.Empty;

        public static void UpdateTms(this LoteBalanza loteBalanza)
            => loteBalanza.Tms = loteBalanza?.Tickets?.Sum(x => x.PesoNeto) ?? 0;

        public static void UpdateTms100(this LoteBalanza loteBalanza)
            => loteBalanza.Tms100 = loteBalanza?.Tickets?.Sum(x => x.PesoNeto100) ?? 0;

        public static void UpdateTmsBase(this LoteBalanza loteBalanza)
            => loteBalanza.TmsBase = loteBalanza?.Tickets?.Sum(x => x.PesoNetoBase) ?? 0;

        public static void UpdateNumeroTickets(this LoteBalanza loteBalanza)
            => loteBalanza.NumeroTickets = string.Join(",", loteBalanza.Tickets.Select(x => x.Numero));
    }
}
