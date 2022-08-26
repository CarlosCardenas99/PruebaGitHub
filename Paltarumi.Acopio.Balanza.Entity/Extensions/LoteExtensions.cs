using Paltarumi.Acopio.Balanza.Common;

namespace Paltarumi.Acopio.Balanza.Entity.Extensions
{
    public static class LoteExtensions
    {
        public static void Enable(this LoteBalanza loteBalanza)
            => loteBalanza.Activo = true;

        public static void UpdateCreation(this LoteBalanza loteBalanza)
            => loteBalanza.CreateDate = DateTimeOffset.Now;

        public static void UpdateCantidadSacos(this LoteBalanza loteBalanza)
            => loteBalanza.CantidadSacos = loteBalanza?.Tickets?.Sum(x => x.CantidadUnidadMedida) ?? 0;

        public static void UpdateFechaIngreso(this LoteBalanza loteBalanza)
            => loteBalanza.FechaIngreso = loteBalanza?.Tickets?.Any() == false ? DateTimeOffset.Now : loteBalanza?.Tickets?.Min(x => x.FechaIngreso) ?? DateTimeOffset.Now;

        public static void UpdateFechaAcopio(this LoteBalanza loteBalanza)
            => loteBalanza.FechaAcopio = loteBalanza?.Tickets?.Any() == false ? null : loteBalanza?.Tickets?.Max(x => x.FechaSalida) ?? null;

        //TMH
        public static void UpdateTmh(this LoteBalanza loteBalanza)
           => loteBalanza.Tmh = loteBalanza?.Tickets?.Sum(x => x.PesoNeto) + loteBalanza?.Tickets?.Sum(x => x.PesoNetoCarreta) ?? 0;

        public static void UpdateTmh100(this LoteBalanza loteBalanza)
            => loteBalanza.Tmh100 = loteBalanza?.Tickets?.Sum(x => x.PesoNeto100) + loteBalanza?.Tickets?.Sum(x => x.PesoNetoCarreta100) ?? 0;

        public static void UpdateTmhBase(this LoteBalanza loteBalanza)
            => loteBalanza.TmhBase = loteBalanza?.Tickets?.Sum(x => x.PesoNetoBase) + loteBalanza?.Tickets?.Sum(x => x.PesoNetoCarretaBase) ?? 0;
    }
}
