using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Votacion_DAL;

namespace Votacion_BO
{
    public class VotacionBO
    {
        DBVotacionesPGDataContext contextoVotacion;
        public VotacionBO()
        {
            contextoVotacion = new DBVotacionesPGDataContext();
        }

        public DataTable ListarCandidatosPorSesion(int pIdSession)
        {
            try
            {
                DataTable dtCandidatos = new DataTable();
                DataRow fila;
                dtCandidatos.Columns.Add("IdUsuario");
                dtCandidatos.Columns.Add("Nombres");
                dtCandidatos.Columns.Add("Apellidos");
                dtCandidatos.Columns.Add("Genero");
                dtCandidatos.Columns.Add("Numero");
                dtCandidatos.Columns.Add("PathImagen");
                dtCandidatos.Columns.Add("FechaNacimiento");

                var lstCandidatos = from cand in contextoVotacion.USUARIO
                                    join sess in contextoVotacion.SESION_CANDIDATO
                                    on cand.ID_USUARIO equals sess.ID_CANDIDATO
                                    where cand.ID_TIPO_USUARIO == 1 && sess.ID_SESION == pIdSession
                                    select new { cand.ID_USUARIO, cand.NOMBRES, cand.APELLIDOS, cand.GENERO, cand.NUMERO, cand.IMAGEN, cand.FECHA_NACIMIENTO };

                foreach (var item in lstCandidatos)
                {
                    fila = dtCandidatos.NewRow();
                    fila["IdUsuario"] = item.ID_USUARIO;
                    fila["Nombres"] = "Nombres: " + item.NOMBRES;
                    fila["Apellidos"] = "Apellidos: " + item.APELLIDOS;
                    fila["Genero"] = "Género: " + item.GENERO;
                    fila["Numero"] = "Nro. " + item.NUMERO;
                    fila["PathImagen"] = item.IMAGEN;
                    //fila["FechaNacimiento"] = "Fecha de Nacimiento: " + item.FECHA_NACIMIENTO == null ? DateTime.Now.ToString("dd/MM/yyyy") : item.FECHA_NACIMIENTO.Value.ToString("dd/MM/yyyy");
                    fila["FechaNacimiento"] = "Fecha de Nacimiento: " + DateTime.Now.ToString("dd/MM/yyyy");
                    dtCandidatos.Rows.Add(fila);
                }
                fila = dtCandidatos.NewRow();
                fila["IdUsuario"] = "0";
                fila["Nombres"] = "&nbsp;";
                fila["Apellidos"] = "&nbsp;";
                fila["Genero"] = "&nbsp;";
                fila["Numero"] = "Blanco";
                fila["PathImagen"] = "~/IMG/Candidatos/Blanco.jpg";
                fila["FechaNacimiento"] = "&nbsp;";
                dtCandidatos.Rows.Add(fila);
                return dtCandidatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InscribirCandidato(USUARIO pCand)
        {
            try
            {
                var cand = contextoVotacion.USUARIO.Single(c => c.ID_USUARIO.Equals(pCand.ID_USUARIO));
                cand.IMAGEN = pCand.IMAGEN;
                cand.ID_TIPO_USUARIO = 1;
                cand.NUMERO = pCand.NUMERO;
                contextoVotacion.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SESION_VOTACION> SesionesVotaciones(int pIdCandidato, int pIdEmpresa)
        {

            List<USUARIO> sc = (from sv in contextoVotacion.USUARIO
                                where sv.ID_USUARIO == pIdCandidato
                                select sv).ToList();

            var query = (from ars in contextoVotacion.AREA_SESION
                         join us in contextoVotacion.USUARIO
                         on ars.ID_AREA equals us.ID_AREA
                         join sv in contextoVotacion.SESION_VOTACION
                         on ars.ID_SESION equals sv.ID_SESION
                         where ars.ID_AREA == (sc.Count > 0 ? sc[0].ID_AREA : 0) &&
                         DateTime.Now.Date >= sv.FECHA_INI_INSCRIPCION.Value.Date &&
                         DateTime.Now.Date <= sv.FECHA_FIN_INSCRIPCION.Value.Date &&
                         sv.ID_EMPRESA == pIdEmpresa
                         select sv).Distinct();

            //var slv = from v in contextoVotacion.SESION_VOTACION
            //          where DateTime.Now >= v.FECHA_INI_INSCRIPCION.Value && DateTime.Now <= v.FECHA_FIN_INSCRIPCION.Value && v.ID_EMPRESA == pIdEmpresa
            //          select v;
            List<SESION_VOTACION> newLstSession = new List<SESION_VOTACION>();
            foreach (var i in query)
            {
                int cnt = contextoVotacion.SESION_CANDIDATO.Where(c => c.ID_CANDIDATO.Equals(pIdCandidato) && c.ID_SESION.Equals(i.ID_SESION)).ToList().Count;
                if (cnt == 0)
                {
                    newLstSession.Add(i);
                }
            }
            return newLstSession;
        }

        public List<SESION_VOTACION> SesionesVotacionesVotar(int pidUsuario, int pIdEmpresa)
        {
            var sessVot = from v in contextoVotacion.SESION_VOTACION
                          where DateTime.Now >= v.FECHA_INICIO.Value && DateTime.Now <= v.FECHA_FIN.Value && v.ID_EMPRESA == pIdEmpresa
                          select v;
            List<SESION_VOTACION> newLstSession = new List<SESION_VOTACION>();
            foreach (var i in sessVot)
            {
                int cnt = contextoVotacion.SESION_USUARIO.Where(c => c.ID_USUARIO.Equals(pidUsuario) && c.ID_SESION.Equals(i.ID_SESION)).ToList().Count;
                if (cnt == 0)
                {
                    newLstSession.Add(i);
                }
            }
            return newLstSession;
        }

        public bool RegistroCandidato(SESION_CANDIDATO pSessCand)
        {
            try
            {
                contextoVotacion.SESION_CANDIDATO.InsertOnSubmit(pSessCand);
                contextoVotacion.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RegistrarVoto(SESION_USUARIO pSessUser)
        {
            try
            {
                contextoVotacion.SESION_USUARIO.InsertOnSubmit(pSessUser);
                contextoVotacion.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertarVotacion(SESION_VOTACION pSessVot)
        {
            try
            {
                contextoVotacion.SESION_VOTACION.InsertOnSubmit(pSessVot);
                contextoVotacion.SubmitChanges();
                return contextoVotacion.SESION_VOTACION.Max(x => x.ID_SESION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ModificarVotaciones(SESION_VOTACION pSessVot)
        {
            try
            {
                SESION_VOTACION sv = pSessVot;
                contextoVotacion.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarVotaciones(int pIdSessVot)
        {
            try
            {
                SESION_VOTACION SesVoDel = (from u in contextoVotacion.SESION_VOTACION
                                            where u.ID_SESION == pIdSessVot
                                            select u).Single();

                contextoVotacion.SESION_VOTACION.DeleteOnSubmit(SesVoDel);
                contextoVotacion.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SESION_VOTACION> ConsultarVotaciones(int pIdEmpresa)
        {
            try
            {
                return (from v in contextoVotacion.SESION_VOTACION
                        where v.ID_EMPRESA == pIdEmpresa
                        select v).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Reporte_Campana> ConsultarNumeroVotosPorcandidatoPorCampana(int iIdCampana)
        {
            try
            {
                var query = contextoVotacion.ExecuteQuery<Reporte_Campana>
                    (@" SELECT DISTINCT  sud.[ID_USUARIO_CANDIDATO]
			                  ,( SELECT 
			                      COUNT(ssu.ID_USUARIO_CANDIDATO)
					               FROM [VotacionesPG].[dbo].[SESION_USUARIO] ssu 
					              WHERE  ssu.[ID_SESION] = " + "'" + iIdCampana + "'" + @"
					                AND ssu.ID_USUARIO_CANDIDATO = sud.ID_USUARIO_CANDIDATO) 
					                 AS 'Numero_Votos' 
				              ,( SELECT [NOMBRES] + ' '+ [APELLIDOS] 
					               FROM [VotacionesPG].[dbo].[USUARIO]
					              WHERE ID_USUARIO =  sud.[ID_USUARIO_CANDIDATO]) 
					                 AS 'Nombre_Candidato'	 
                                   FROM [VotacionesPG].[dbo].[SESION_USUARIO] sud
                                  WHERE sud.[ID_SESION] = " + "'" + iIdCampana + "'").ToList();


                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ConsultarGanadorParcial(int iIdSesion)
        {
            try
            {
                var sqlQuery = contextoVotacion.SESION_USUARIO
                           .Where(a => a.ID_SESION == iIdSesion)
                           .GroupBy(a => a.ID_USUARIO_CANDIDATO)
                           .Select(g => new { ID_USUARIO_CANDIDATO = g.Key, NumeroVotos = g.Count() })
                           .OrderByDescending(x => x.NumeroVotos).ToList();

                var query = sqlQuery.Count <= 0 ? 0 : sqlQuery.Max(c => c.NumeroVotos);

                var query2 = sqlQuery.Where(c => c.NumeroVotos == query);
                string ganador = "";
                if (query2.Count() > 1)
                {
                    ganador = "Empate entre:  ";
                    foreach (var item in query2)
                    {
                        List<USUARIO> sqlQuery2 = (from cg in contextoVotacion.USUARIO
                                                   where cg.ID_USUARIO ==
                                                   (sqlQuery != null && sqlQuery.Count > 0 ?
                                                   Convert.ToInt32(item.ID_USUARIO_CANDIDATO)
                                                   : 0)
                                                   select cg).ToList();
                        ganador = ganador + " , " + sqlQuery2[0].NOMBRES + "  " + sqlQuery2[0].APELLIDOS + "  ";
                    }
                    return ganador;
                }
                else
                {
                    List<USUARIO> sqlQuery3 = (from cg in contextoVotacion.USUARIO
                                               where cg.ID_USUARIO ==
                                               (sqlQuery != null && sqlQuery.Count > 0 ?
                                               Convert.ToInt32(sqlQuery[0].ID_USUARIO_CANDIDATO)
                                               : 0)
                                               select cg).ToList();

                    return sqlQuery3.Count > 0 ? sqlQuery3[0].NOMBRES + "  " + sqlQuery3[0].APELLIDOS : "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ConsultarNumeroVotosGanadorParcial(int iIdSesion)
        {
            try
            {
                var sqlQuery = contextoVotacion.SESION_USUARIO
                           .Where(a => a.ID_SESION == iIdSesion)
                           .GroupBy(a => a.ID_USUARIO_CANDIDATO)
                           .Select(g => new { ID_USUARIO_CANDIDATO = g.Key, NumeroVotos = g.Count() })
                           .OrderByDescending(x => x.NumeroVotos).ToList();

                var query = sqlQuery.Count <= 0 ? 0 : sqlQuery.Max(c => c.NumeroVotos);

                return query.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SESION_VOTACION ConsultarVotacionesPorId(int pKey)
        {
            try
            {
                return (from sv in contextoVotacion.SESION_VOTACION
                        where sv.ID_SESION == pKey
                        select sv).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AREA> AreaPorEmpresa(int pIdEmpres)
        {
            try
            {
                return (from a in contextoVotacion.AREA
                        where a.ID_EMPRESA == pIdEmpres
                        select a).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AREA_SESION> AreaSesion(int pIdSesion)
        {
            try
            {
                return (from arse in contextoVotacion.AREA_SESION
                        where arse.ID_SESION == pIdSesion
                        select arse).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarAreaSesion(AREA_SESION pAreaSesion)
        {
            try
            {
                AREA_SESION sa = pAreaSesion;
                contextoVotacion.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarAreaSesion(AREA_SESION pAreaSesion)
        {
            try
            {
                contextoVotacion.AREA_SESION.InsertOnSubmit(pAreaSesion);
                contextoVotacion.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarAreaVotaciones(AREA_SESION pAreaSes)
        {
            try
            {
                AREA_SESION deleteAS = contextoVotacion.AREA_SESION.SingleOrDefault(c => c.ID_AREA == pAreaSes.ID_AREA && c.ID_SESION == pAreaSes.ID_SESION);
                if (deleteAS != null)
                {
                    contextoVotacion.AREA_SESION.DeleteOnSubmit(deleteAS);
                    contextoVotacion.SubmitChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarAreaVotacionesPorIdSesion(int pIdAreaSesio)
        {
            try
            {
                var a = from j in contextoVotacion.AREA_SESION
                        where j.ID_SESION == pIdAreaSesio
                        select j;

                foreach (var item in a)
                {
                    contextoVotacion.AREA_SESION.DeleteOnSubmit(item);
                }
                contextoVotacion.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public class Reporte_Campana
    {
        public int ID_USUARIO_CANDIDATO { get; set; }
        public int Numero_Votos { get; set; }
        public string Nombre_Candidato { get; set; }
    }

}
