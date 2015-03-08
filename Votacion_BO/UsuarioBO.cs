using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Votacion_DAL;
using System.Data;

namespace Votacion_BO
{
    public class UsuarioBO
    {
        DBVotacionesPGDataContext contextoVotacion;
        public UsuarioBO()
        {
            contextoVotacion = new DBVotacionesPGDataContext();
        }
        //public USUARIO SigIn(string pUser, string pPass)
        //{
        //    try
        //    {
        //        return (from us in contextoVotacion.USUARIO
        //                where us.NOMBRE_USUARIO == pUser && us.CONTRASENIA == pPass
        //                select us).Single();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public bool sigIn(string user, string password, out DataSet dsUser)
        {
            try
            {
                contextoVotacion = new DBVotacionesPGDataContext();
                var query = from us in contextoVotacion.USUARIO
                            where us.NOMBRE_USUARIO == user && us.CONTRASENIA == password
                            select new
                            {
                                ID_USUARIO = us.ID_USUARIO,
                                TIPO_IDENTIFICACION = us.TIPO_IDENTIFICACION,
                                IDENTFICACION = us.IDENTFICACION,
                                NOMBRES = us.NOMBRES,
                                APELLIDOS = us.APELLIDOS,
                                IMAGEN = us.IMAGEN,
                                GENERO = us.GENERO,
                                FECHA_NACIMIENTO = us.FECHA_NACIMIENTO,
                                NUMERO = us.NUMERO,
                                ID_EMPRESA = us.AREA == null ? 0 : us.AREA.ID_EMPRESA,
                                ID_AREA = us.ID_AREA == null ? 0 : us.ID_AREA,
                                ID_TIPO_USUARIO = us.ID_TIPO_USUARIO,
                                NOMBRE_USUARIO = us.NOMBRE_USUARIO,
                                CONTRASENA = us.CONTRASENIA
                            };

                dsUser = cUtilities.ToDataSet(query.ToList());

                if (dsUser.Tables[0].Rows.Count < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                dsUser = new DataSet();
                return false;
            }
        }

        public bool ListUserCompany(int companyId, out DataSet dsUsers)
        {
            try
            {
                contextoVotacion = new DBVotacionesPGDataContext();

                var users = (from u in contextoVotacion.USUARIO
                             join a in contextoVotacion.AREA on u.ID_AREA equals a.ID_AREA
                             join e in contextoVotacion.EMPRESA on a.ID_EMPRESA equals e.ID_EMPRESA
                             where e.ID_EMPRESA == companyId
                             select u);

                dsUsers = cUtilities.ToDataSet(users.ToList());
                return true;
            }
            catch (Exception)
            {
                dsUsers = new DataSet();
                return false;
            }
        }

        public bool UserDetails(int userId,out DataSet dsUser)
        {
            try
            {
                contextoVotacion = new DBVotacionesPGDataContext();

                var users = (from u in contextoVotacion.USUARIO
                             where u.ID_USUARIO == userId
                             select u);

                dsUser = cUtilities.ToDataSet(users.ToList());
                return true;
            }
            catch (Exception)
            {
                dsUser = new DataSet();
                return false;
            }
        }

        public bool verifyingUser(DataSet dsUser, out DataSet dsRolUser)
        {
            try
            {
                contextoVotacion = new DBVotacionesPGDataContext();


                var query = from rolu in contextoVotacion.ROL_USUARIO
                            where rolu.ID_USUARIO == Convert.ToInt32(dsUser.Tables[0].Rows[0][0].ToString())
                            select rolu;

                dsRolUser = cUtilities.ToDataSet(query.ToList());

                dsRolUser.Tables[0].Columns.Remove(dsRolUser.Tables[0].Columns[3]);
                dsRolUser.Tables[0].Columns.Remove(dsRolUser.Tables[0].Columns[3]);
                return true;
            }
            catch (Exception)
            {
                dsRolUser = new DataSet();
                return false;
            }
        }

        /// <summary>
        /// Metodo que permite verificar que el nombre de usuario no se repita
        /// </summary>
        /// <param name="userName">nombre de usuario</param>
        /// <param name="dsData">DataSet que retorna el usuario</param>
        /// <returns>Retorna true si no ocurrio ningua exepcion y false si ocurrio algo inesperado</returns>
        public bool userNameUnique(string userName, out DataSet dsData)
        {
            try
            {
                contextoVotacion = new DBVotacionesPGDataContext();
                var query = from us in contextoVotacion.USUARIO
                            where us.NOMBRE_USUARIO == userName
                            select new
                            {
                                ID_USUARIO = us.ID_USUARIO,
                                TIPO_IDENTIFICACION = us.TIPO_IDENTIFICACION,
                                IDENTFICACION = us.IDENTFICACION,
                                NOMBRES = us.NOMBRES,
                                APELLIDOS = us.APELLIDOS,
                                IMAGEN = us.IMAGEN,
                                GENERO = us.GENERO,
                                FECHA_NACIMIENTO = us.FECHA_NACIMIENTO,
                                NUMERO = us.NUMERO,
                                ID_AREA = us.ID_AREA,
                                ID_TIPO_USUARIO = us.ID_TIPO_USUARIO,
                                NOMBRE_USUARIO = us.NOMBRE_USUARIO,
                                CONTRASENA = us.CONTRASENIA
                            };
                dsData = cUtilities.ToDataSet(query.ToList());

                if (dsData.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                dsData = new DataSet();
                return false;
            }
        }
        /// <summary>
        /// Metodo que permite verificar que el documento no se repita
        /// </summary>
        /// <param name="document">numero de documento</param>
        /// <param name="dsData">Retorna un DataSet con el usuario</param>
        /// <returns>Retorna true si no ocurrio ningua exepcion y false si ocurrio algo inesperado</returns>
        public bool documentUniqe(string document, out DataSet dsData)
        {
            try
            {
                contextoVotacion = new DBVotacionesPGDataContext();

                //var query = from cp in db.USUARIOs
                //            where cp.IDENTFICACION == document
                //            select cp;

                var query = from cp in contextoVotacion.USUARIO
                            where cp.IDENTFICACION == document
                            select new
                            {
                                ID_USUARIO = cp.ID_USUARIO,
                                TIPO_IDENTIFICACION = cp.TIPO_IDENTIFICACION,
                                IDENTFICACION = cp.IDENTFICACION,
                                NOMBRES = cp.NOMBRES,
                                APELLIDOS = cp.APELLIDOS,
                                IMAGEN = cp.IMAGEN,
                                GENERO = cp.GENERO,
                                FECHA_NACIMIENTO = cp.FECHA_NACIMIENTO,
                                NUMERO = cp.NUMERO,
                                ID_AREA = cp.ID_AREA,
                                ID_TIPO_USUARIO = cp.ID_TIPO_USUARIO,
                                NOMBRE_USUARIO = cp.NOMBRE_USUARIO,
                                CONTRASENA = cp.CONTRASENIA
                            };

                dsData = cUtilities.ToDataSet(query.ToList());

                if (dsData.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                dsData = new DataSet();
                return false;
            }
        }

    }
}
