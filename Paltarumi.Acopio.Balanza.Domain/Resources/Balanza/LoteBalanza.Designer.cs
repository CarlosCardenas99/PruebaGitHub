﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Paltarumi.Acopio.Balanza.Domain.Resources.Balanza {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LoteBalanza {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LoteBalanza() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Paltarumi.Acopio.Balanza.Domain.Resources.Balanza.LoteBalanza", typeof(LoteBalanza).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Codigo de lote no encontrada.
        /// </summary>
        internal static string Codigo {
            get {
                return ResourceManager.GetString("Codigo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a IdLoteBalanza.
        /// </summary>
        internal static string IdLoteBalanza {
            get {
                return ResourceManager.GetString("IdLoteBalanza", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a La suma de peso tickets no concide con original.
        /// </summary>
        internal static string PesoTicketNoConcideConOriginal {
            get {
                return ResourceManager.GetString("PesoTicketNoConcideConOriginal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El tipo de vehículo no fue encontrado.
        /// </summary>
        internal static string TipoVehiculoNotFound {
            get {
                return ResourceManager.GetString("TipoVehiculoNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a La marca de vehículo no fue encontrada.
        /// </summary>
        internal static string VehiculoMarcaNotFound {
            get {
                return ResourceManager.GetString("VehiculoMarcaNotFound", resourceCulture);
            }
        }
    }
}
