using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Archivo
    {
        public int IdArchivo { get; set; }
        public string Entidad { get; set; } = null!;
        public int Identificador { get; set; }
        public string DirectoryPath { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FileContentType { get; set; } = null!;
        public bool DirectorySync { get; set; }
        public string? DirectorySyncResult { get; set; }
        public bool FtpSync { get; set; }
        public string? FtpSyncResult { get; set; }
        public bool CloudSync { get; set; }
        public string? CloudSyncResult { get; set; }
        public string UserNameCreate { get; set; } = null!;
        public DateTimeOffset CreateDate { get; set; }
    }
}
