using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Votacion_DAL;

namespace Votacion_BO
{

    /// <summary>
    /// The logic usuario.
    /// </summary>
    public class LogicUsuario
    {
        private readonly DBVotacionesPGDataContext dataClases = new DBVotacionesPGDataContext();

        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="userL">
        /// The user L.
        /// </param>
        /// <returns>
        /// The vo user null is not exist<see cref="VoUser"/>.
        /// </returns>
        public VoUser Login(VoUser userL)
        {
            var user = this.dataClases.SPR_LOGIN_USUARIO(userL.NombreUsuario, userL.Contrasenia).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            return new VoUser
            {
                Apellidos = user.APELLIDOS,
                FechaNacimiento = user.FECHA_NACIMIENTO,
                Genero = user.GENERO,
                IdArea = user.ID_AREA ?? 0,
                IdCompany = user.ID_EMPRESA,
                IdTipoUsuario = user.ID_TIPO_USUARIO ?? 0,
                Nombres = user.NOMBRES,
                IdUser = user.ID_USUARIO,
                Identficacion = user.IDENTFICACION,
                IdRol = user.ID_ROL,
                Imagen = user.IMAGEN,
                Numero = user.NUMERO,
                NombreUsuario = userL.NombreUsuario,
                Contrasenia = userL.Contrasenia
            };
        }

        /// <summary>
        /// The select company.
        /// </summary>
        /// <returns>
        /// The <see cref="VoUser"/>.
        /// </returns>
        public List<VoCompany> SelectCompany()
        {
            var result = this.dataClases.SPR_CONSULTA_EMPRESAS();
            return result.Select(e => new VoCompany { IdEmpresa = e.ID_EMPRESA, NombreEmpresa = e.NOMBRE_EMPRESA }).ToList();
        }

        /// <summary>
        /// The select company.
        /// </summary>
        /// <param name="idEmpresa">
        /// The id company.
        /// </param>
        /// <returns>
        /// The List Vo Areas<see cref="VoUser"/>.
        /// </returns>
        public List<VoArea> SelectAreaCompany(int idEmpresa)
        {
            var result = this.dataClases.SPR_CONSULTA_AREAS_EMPRESA(idEmpresa);
            return result.Select(e => new VoArea { IdArea = e.ID_AREA, NombreArea = e.NOMBRE_AREA }).ToList();
        }

        /// <summary>
        /// The insert user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public int InsertUser(VoUser user)
        {
            return this.dataClases.SPR_INSERT_USUARIO(
                user.Identficacion,
                user.TypeDocument,
                user.Nombres,
                user.Apellidos,
                user.Imagen,
                user.Genero,
                user.FechaNacimiento,
                user.Numero,
                user.IdArea,
                user.IdTipoUsuario,
                user.IdRol,
                user.NombreUsuario,
                user.Contrasenia);
        }

        /// <summary>
        /// The update user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int UpdateUser(VoUser user)
        {
            return this.dataClases.SPR_UPDATE_USUARIO(
                user.IdUser,
                user.Identficacion,
                user.TypeDocument,
                user.Nombres,
                user.Apellidos,
                user.Imagen,
                user.Genero,
                user.FechaNacimiento,
                user.Numero,
                user.IdArea,
                user.IdTipoUsuario,
                user.IdRol,
                user.NombreUsuario,
                user.Contrasenia);
        }

        /// <summary>
        /// The delete user.
        /// </summary>
        /// <param name="idUser">
        /// The id user.
        /// </param>
        public void DeleteUser(int idUser)
        {
            this.dataClases.SPR_DELETE_USUARIO(idUser);
        }

        /// <summary>
        /// The change password.
        /// </summary>
        /// <param name="idUser">
        /// The id user.
        /// </param>
        /// <param name="newPassword">
        /// The new password.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ChangePassword(int idUser, string newPassword)
        {
            try
            {
                this.dataClases.SPR_UPDATE_USUARIO_CONTRASENA(idUser, newPassword);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// The select all users.
        /// </summary>
        /// <returns>
        /// The vo users<see>
        ///               <cref>List</cref>
        ///             </see> .
        /// </returns>
        public List<VoUser> SelectAllUsers()
        {
            var result = this.dataClases.SPR_SELECT_USERS_ADM().ToList();
            return
                result.Select(
                    r =>
                    new VoUser
                    {
                        FechaNacimiento = r.FECHA_NACIMIENTO,
                        Contrasenia = r.CONTRASENIA,
                        Apellidos = r.APELLIDOS,
                        Genero = r.GENERO,
                        IdArea = r.ID_AREA,
                        IdTipoUsuario = r.ID_TIPO_USUARIO,
                        IdUser = r.ID_USUARIO,
                        Identficacion = r.IDENTFICACION,
                        Imagen = r.IMAGEN ?? string.Empty,
                        NombreUsuario = r.NOMBRE_USUARIO,
                        Nombres = r.NOMBRES,
                        Numero = r.NUMERO,
                        IdCompany = r.ID_EMPRESA,
                        IdRol = r.ID_ROL,
                        TypeDocument = r.TIPO_IDENTIFICACION
                    }).ToList();
        }

        /// <summary>
        /// The select type user.
        /// </summary>
        /// <returns>
        /// The List Vo type user<see cref="VoUser"/>.
        /// </returns>
        public List<VoTipoUsuario> SelectTypeUser()
        {
            var result = this.dataClases.SPR_SELECT_TIPO_USUARIO();
            return result.Select(e => new VoTipoUsuario { IdTipeUser = e.ID_TIPO_USUARIO, NameTypeUser = e.NOMBRE_TIPO_USUARIO }).ToList();
        }
    }
}
