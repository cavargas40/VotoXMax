using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Votacion_BO
{

    /// <summary>
    /// The vo usuario.
    /// </summary>
    public class VoUser
    {
        /// <summary>
        /// Gets or sets the id user.
        /// </summary>
        public int IdUser { get; set; }

        /// <summary>
        /// Gets or sets the Identficacion.
        /// </summary>
        public string Identficacion { get; set; }

        /// <summary>
        /// Gets or sets the id type document.
        /// </summary>
        public string TypeDocument { get; set; }

        /// <summary>
        /// Gets or sets the Nombres.
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Gets or sets the Apellidos.
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// Gets or sets the Imagen.
        /// </summary>
        public string Imagen { get; set; }

        /// <summary>
        /// Gets or sets the genero.
        /// </summary>
        public string Genero { get; set; }

        /// <summary>
        /// Gets or sets the fecha nacimiento.
        /// </summary>
        public DateTime? FechaNacimiento { get; set; }

        /// <summary>
        /// Gets or sets the numero.
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Gets or sets the id area.
        /// </summary>
        public int? IdArea { get; set; }

        /// <summary>
        /// Gets or sets the id company.
        /// </summary>
        public int IdCompany { get; set; }

        /// <summary>
        /// Gets or sets the id tipo usuario.
        /// </summary>
        public int? IdTipoUsuario { get; set; }

        /// <summary>
        /// Gets or sets the id rol.
        /// </summary>
        public int? IdRol { get; set; }

        /// <summary>
        /// Gets or sets the nombre usuario.
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Gets or sets the contrasenia.
        /// </summary>
        public string Contrasenia { get; set; }
    }
}
