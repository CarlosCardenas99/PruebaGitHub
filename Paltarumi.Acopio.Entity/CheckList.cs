using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class CheckList
    {
        public int IdCheckList { get; set; }
        public int IdLote { get; set; }
        public bool Habilitado { get; set; }
        public string CodigoDocumentoVerificacion { get; set; } = null!;
        public int CodigoEstado { get; set; }
        public string Observacion { get; set; } = null!;
    }
}
