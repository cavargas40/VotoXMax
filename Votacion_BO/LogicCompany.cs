using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Votacion_DAL;

namespace Votacion_BO
{
    public class LogicCompany
    {
        /// <summary>
        /// The data clases.
        /// </summary>
        private readonly DBVotacionesPGDataContext dataClases = new DBVotacionesPGDataContext();

        /// <summary>
        /// The insert company.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int InsertCompany(VoCompany company)
        {
            return this.dataClases.SPR_INSERT_COMPANY_ID(
                 company.NombreEmpresa,
                 company.NitEmpresa,
                 company.DireccionEmpresa,
                 company.TelefonoEmpresa,
                 company.CorreoEmpresa);
        }

        /// <summary>
        /// The update company.
        /// </summary>
        /// <param name="company">
        /// The company.
        /// </param>
        public void UpdateCompany(VoCompany company)
        {
            this.dataClases.SPR_UPDATE_COMPANY_ID(
                 company.IdEmpresa,
                 company.NombreEmpresa,
                 company.NitEmpresa,
                 company.DireccionEmpresa,
                 company.TelefonoEmpresa,
                 company.CorreoEmpresa);
        }

        /// <summary>
        /// The delete company.
        /// </summary>
        /// <param name="idCompany">
        /// The id Company.
        /// </param>
        public void DeleteCompany(int idCompany)
        {
            this.dataClases.SPR_DELETE_COMPANY_ADM(idCompany);
        }

        /// <summary>
        /// The select all comapanys.
        /// </summary>
        /// <returns>
        /// The <see>
        ///       <cref>List</cref>
        ///     </see> .
        /// </returns>
        public List<VoCompany> SelectAllComapanys()
        {
            var result = this.dataClases.SPR_SELECT_COMPANYS_ADM().ToList();
            return
                result.Select(
                    c =>
                    new VoCompany()
                    {
                        IdEmpresa = c.ID_EMPRESA,
                        NombreEmpresa = c.NOMBRE_EMPRESA,
                        NitEmpresa = c.NIT_EMPRESA,
                        CorreoEmpresa = c.CORREO_EMPRESA,
                        DireccionEmpresa = c.DIRECCION_EMPRESA,
                        TelefonoEmpresa = c.TELEFONO_EMPRESA
                    }).ToList();
        }

        public void RegistroNuevaEmpresaAdmin(VoCompany pEmpresa, VoUser pUsuarioAdmin)
        {
            dataClases.RegistroNuevaEmpresaAdministracion(pEmpresa.NombreEmpresa, pEmpresa.NitEmpresa, pEmpresa.DireccionEmpresa, pEmpresa.TelefonoEmpresa, pEmpresa.CorreoEmpresa, pUsuarioAdmin.Nombres, pUsuarioAdmin.Apellidos, pUsuarioAdmin.TypeDocument, pUsuarioAdmin.Identficacion, pUsuarioAdmin.Genero, pUsuarioAdmin.FechaNacimiento, pUsuarioAdmin.Numero, pUsuarioAdmin.IdRol, pUsuarioAdmin.IdTipoUsuario, pUsuarioAdmin.NombreUsuario, pUsuarioAdmin.Contrasenia);
        }
    }
}
