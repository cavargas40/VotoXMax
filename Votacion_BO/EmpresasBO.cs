using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Votacion_DAL;
using System.Data;

namespace Votacion_BO
{
    public class EmpresasBO
    {
        DBVotacionesPGDataContext contextoVotacion;
        public EmpresasBO()
        {
            contextoVotacion = new DBVotacionesPGDataContext();
        }

        public void loadCompanies(out DataSet dsData)
        {
            try
            {
                contextoVotacion = new DBVotacionesPGDataContext();
                var query = from com in contextoVotacion.EMPRESA
                            select com;
                dsData = cUtilities.ToDataSet(query.ToList());
            }
            catch (Exception)
            {
                dsData = new DataSet();
            }
        }


        public bool loadCompanyByIdArea(int idArea, out DataSet dsArea)
        {
            try
            {
                contextoVotacion = new DBVotacionesPGDataContext();
                var query = from cp in contextoVotacion.EMPRESA
                            join ar in contextoVotacion.AREA on cp.ID_EMPRESA equals ar.ID_EMPRESA
                            where ar.ID_AREA == idArea
                            select new
                            {
                                ID_EMPRESA = cp.ID_EMPRESA,
                                NOMBRE_EMPRESA = cp.NOMBRE_EMPRESA
                            };

                dsArea = cUtilities.ToDataSet(query.ToList());
                return true;
            }
            catch (Exception)
            {
                dsArea = new DataSet();
                return false;
            }
        }


    }
}
