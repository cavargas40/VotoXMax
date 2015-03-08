using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Votacion_BO
{
    /// <summary>
    /// The vo empresa.
    /// </summary>
    public class VoCompany
    {
        /// <summary>
        /// Gets or sets the id_empresa.
        /// </summary>
        public int IdEmpresa { get; set; }

        /// <summary>
        /// Gets or sets the nombre_empresa.
        /// </summary>
        public string NombreEmpresa { get; set; }

        /// <summary>
        /// Gets or sets the nit_empresa.
        /// </summary>
        public string NitEmpresa { get; set; }

        /// <summary>
        /// Gets or sets the direccion_empresa.
        /// </summary>
        public string DireccionEmpresa { get; set; }

        /// <summary>
        /// Gets or sets the telefono_empresa.
        /// </summary>
        public string TelefonoEmpresa { get; set; }

        /// <summary>
        /// Gets or sets the correo_empresa.
        /// </summary>
        public string CorreoEmpresa { get; set; }
    }
}
