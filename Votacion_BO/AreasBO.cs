using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Votacion_DAL;
using System.Data;
namespace Votacion_BO
{
    public class AreasBO
    {
        DBVotacionesPGDataContext contextoVotacion;
        public AreasBO()
        {
            contextoVotacion = new DBVotacionesPGDataContext();
        }

        public bool loadArea(int idCompany, out DataSet dsData)
        {
            try
            {
                contextoVotacion = new DBVotacionesPGDataContext();
                var query = from cp in contextoVotacion.AREA
                            where cp.ID_EMPRESA == idCompany
                            select new
                            {
                                ID_AREA = cp.ID_AREA,
                                NOMBRE_AREA = cp.NOMBRE_AREA,
                                ID_EMPRESA = cp.ID_EMPRESA
                            };

                dsData = cUtilities.ToDataSet(query.ToList());
                return true;
            }
            catch (Exception)
            {
                dsData = new DataSet();
                return false;
            }
        }

        public bool addArea(string nameArea, int idCompany)
        {
            try
            {
                contextoVotacion = new DBVotacionesPGDataContext();

                AREA area = new AREA()
                {
                    NOMBRE_AREA = nameArea,
                    ID_EMPRESA = idCompany
                };
                contextoVotacion.AREA.InsertOnSubmit(area);
                contextoVotacion.SubmitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteArea(int idArea)
        {
            try
            {

                contextoVotacion = new DBVotacionesPGDataContext();

                AREA area = contextoVotacion.AREA.Where(c => c.ID_AREA == idArea).Single();
                contextoVotacion.AREA.DeleteOnSubmit(area);
                contextoVotacion.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool updateArea(int id, string name)
        {
            try
            {
                contextoVotacion = new DBVotacionesPGDataContext();
                var query = from comp in contextoVotacion.AREA
                            where comp.ID_AREA == id
                            select comp;

                foreach (AREA ord in query)
                {
                    ord.NOMBRE_AREA = name;
                }
                contextoVotacion.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
