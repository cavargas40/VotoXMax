//===============================================
//Autor: Hernan Dario Betancur Cardenas
//Todos los derechos reservados
//Fecha:23/11/2013
//===============================================

using System.Collections.Generic;
using System.Linq;
using Votacion_DAL;

namespace Votacion_BO
{
    public class ReportesBO
    {


        private readonly DBVotacionesPGDataContext _contextoReporte;
        //private readonly IReportes _view;

        //public ReportesBO(IReportes view)
        //{
        //    _view = view;
        //    _contextoReporte = new DBVotacionesPGDataContext();
        //}

        public void ObtenerSesiones(int idEmpresa)
        {
            var sesion = (from s in _contextoReporte.SESION_VOTACION
                          join e in _contextoReporte.EMPRESA on s.ID_EMPRESA equals e.ID_EMPRESA
                          where e.ID_EMPRESA == idEmpresa
                          select s).ToList();
            //_view.Sesiones = sesion;
        }

        public void ObtenerCandidatos(int idSesion, int idEmpresa)
        {
            var candidato = (from u in _contextoReporte.USUARIO
                             join su in _contextoReporte.SESION_CANDIDATO on u.ID_USUARIO equals su.ID_CANDIDATO
                             join s in _contextoReporte.SESION_VOTACION on su.ID_SESION equals  s.ID_SESION
                             where s.ID_SESION == idSesion &&
                             s.ID_EMPRESA == idEmpresa
                          select new Candidato
                                     {
                                         UsuarioId = u.ID_USUARIO,
                                         NombreCompleto = u.NOMBRES + " " + u.APELLIDOS
                                     }).ToList();
            //_view.Candidatos = candidato;
        }

    }

    public class Candidato
    {
        public int UsuarioId { get; set; }
        public string NombreCompleto { get; set; }
    }
}
