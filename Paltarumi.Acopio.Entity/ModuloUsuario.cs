﻿using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Entity
{
    public partial class ModuloUsuario
    {
        public int IdModuloUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdModulo { get; set; }
        public int IdEmpresa { get; set; }
    }
}
