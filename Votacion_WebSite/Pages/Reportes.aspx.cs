using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacion_BO;
using Votacion_DAL;

namespace Votacion_WebSite.Pages
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCampanas();
                LoadArea();
            }
        }

        public void cargarCampanas()
        {
            try
            {
                DataTable dtSesVot = new DataTable();
                DataRow r;
                dtSesVot.Columns.Add("ID_SESION");
                dtSesVot.Columns.Add("NOMBRE_SESION");
                dtSesVot.Columns.Add("FECHA_INICIO");
                dtSesVot.Columns.Add("FECHA_FIN");
                dtSesVot.Columns.Add("FECHA_INI_INSCRIPCION");
                dtSesVot.Columns.Add("FECHA_FIN_INSCRIPCION");
                dtSesVot.Columns.Add("USUARIO_CANDIDATO");
                dtSesVot.Columns.Add("NUMERO_VOTOS");
                List<SESION_VOTACION> lstsv = new VotacionBO().ConsultarVotaciones(Convert.ToInt32(((DataSet)Session["dsUser"]).Tables[0].Rows[0]["ID_EMPRESA"]));
                foreach (SESION_VOTACION item in lstsv)
                {
                    r = dtSesVot.NewRow();
                    r["ID_SESION"] = item.ID_SESION;
                    r["NOMBRE_SESION"] = item.NOMBRE_SESION;
                    r["FECHA_INICIO"] = item.FECHA_INICIO.Value.ToString("dd/MM/yyyy");
                    r["FECHA_FIN"] = item.FECHA_FIN.Value.ToString("dd/MM/yyyy");
                    r["FECHA_INI_INSCRIPCION"] = item.FECHA_INI_INSCRIPCION.Value.ToString("dd/MM/yyyy");
                    r["FECHA_FIN_INSCRIPCION"] = item.FECHA_FIN_INSCRIPCION.Value.ToString("dd/MM/yyyy");
                    r["USUARIO_CANDIDATO"] = new VotacionBO().ConsultarGanadorParcial(item.ID_SESION);
                    r["NUMERO_VOTOS"] = new VotacionBO().ConsultarNumeroVotosGanadorParcial(item.ID_SESION);
                    dtSesVot.Rows.Add(r);
                }
                ddlCampañas.DataSource = dtSesVot;
                ddlCampañas.DataTextField = "NOMBRE_SESION";
                ddlCampañas.DataValueField = "ID_SESION";
                ddlCampañas.DataBind();


                ddlCapanna2.DataSource = dtSesVot;
                ddlCapanna2.DataTextField = "NOMBRE_SESION";
                ddlCapanna2.DataValueField = "ID_SESION";
                ddlCapanna2.DataBind();
            }
            catch (Exception)
            {

            }
        }

        private void LoadArea()
        {
            try
            {
                List<AREA> area = new VotacionBO().consultarAreas(Convert.ToInt32(Session["company"].ToString()));

                ddlArea.DataSource = area;
                ddlArea.DataTextField = "NOMBRE_AREA";
                ddlArea.DataValueField = "ID_AREA";
                ddlArea.DataBind();
            }
            catch (Exception)
            {
                
            }
        }

        [System.Web.Services.WebMethod]
        public static List<string[]> GetDataAjax(string idCampana)
        {
            List<Reporte_Campana> test = new VotacionBO().ConsultarNumeroVotosPorcandidatoPorCampana(Convert.ToInt32(idCampana));

            List<string[]> list = new List<string[]>();
            string[] arr1 = new string[] { };

            foreach (var item in test)
            {
                arr1 = new string[] {  item.ID_USUARIO_CANDIDATO.ToString(),
                                       item.Nombre_Candidato,
                                       item.Numero_Votos.ToString()};
                list.Add(arr1);
            }


            return (list);
        }


        [System.Web.Services.WebMethod]
        public static List<string[]> GetDataAjaxArea(string idCampana, string idArea)
        {
            List<Reporte_Campana_Area> test = new VotacionBO().ConsultarNumeroVotosPorCampanaPorVotacion(Convert.ToInt32(idCampana), Convert.ToInt32(idArea));

            List<string[]> list = new List<string[]>();
            string[] arr1 = new string[] { };

            foreach (var item in test)
            {
                arr1 = new string[] {  item.ID_USUARIO_CANDIDATO.ToString(),
                                       item.Nombre_Candidato,
                                       item.Numero_Votos.ToString(),
                                       item.NOMBRE_AREA
                                     };
                list.Add(arr1);
            }


            return (list);
        }

        protected void ddlCapanna2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}