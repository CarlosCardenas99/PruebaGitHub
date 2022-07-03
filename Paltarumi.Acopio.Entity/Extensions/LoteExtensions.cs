using Paltarumi.Acopio.Common;

namespace Paltarumi.Acopio.Entity.Extensions
{
    public static class LoteExtensions
    {
        public static void Enable(this LoteBalanza loteBalanza)
            => loteBalanza.Activo = true;

        public static void UpdateCreation(this LoteBalanza loteBalanza)
            => loteBalanza.CreateDate = DateTimeOffset.Now;

        public static void UpdateCantidadSacos(this LoteBalanza loteBalanza)
            => loteBalanza.CantidadSacos = loteBalanza?.Tickets?.Count(x => x.IdUnidadMedida == Constants.Maestro.UnidadMedida.SACOS).ToString() ?? String.Empty;

        public static void UpdateFechaIngreso(this LoteBalanza loteBalanza)
            => loteBalanza.FechaIngreso = loteBalanza?.Tickets?.Min(x => x.FechaIngreso) ?? DateTimeOffset.Now;

        public static void UpdateFechaAcopio(this LoteBalanza loteBalanza)
            => loteBalanza.FechaAcopio = loteBalanza?.Tickets?.Max(x => x.FechaSalida) ?? DateTimeOffset.Now;

    }
}
