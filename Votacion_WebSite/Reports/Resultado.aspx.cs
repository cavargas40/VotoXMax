//===============================================
//Autor: Hernan Dario Betancur Cardenas
//Todos los derechos reservados
//Fecha:23/11/2013
//Proyecto: Votaciones Electronicas
//===============================================
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Votacion_BO;
using Votacion_DAL;

namespace Votacion_WebSite.Reports
{
    public partial class Resultado : Page
    {
        private ReportesBO _presentador;

        protected override void OnInit(EventArgs e)
        {
            //_presentador = new ReportesBO(this);
            base.OnInit(e);
        }

        protected void lbExit_Click(object sender, EventArgs e)
        {
            try
            {
                Session.RemoveAll();
                Response.Redirect("~/Inicio.aspx");
            }
            catch (Exception)
            {

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int empresaId = Convert.ToInt32(Request["idEmpresa"]);
                _presentador.ObtenerSesiones(empresaId);
            }
        }

        protected void ConsultarButtonClick(object sender, EventArgs e)
        {
            var reportPath = "/VotacionesPG/ReporteVotacion";
            ResultadoReportViewer.Visible = true;
            ResultadoReportViewer.ServerReport.ReportServerUrl =
                new Uri(ConfigurationManager.AppSettings["MyReportViewerUrl"]);
            ResultadoReportViewer.ProcessingMode = ProcessingMode.Remote;
            ResultadoReportViewer.ServerReport.ReportPath = reportPath;
            ResultadoReportViewer.ShowParameterPrompts = false;

            ReportParameter sesionId = new ReportParameter("SesionId", SessionDropDownList.SelectedValue);

            List<ReportParameter> parametros = new List<ReportParameter>();
            parametros.Add(sesionId);

            //IReportServerCredentials irsc =
            //    new CustomReportCredentials(ConfigurationManager.AppSettings["MyReportViewerUser"],
            //                                ConfigurationManager.AppSettings["MyReportViewerPassword"],
            //                                ConfigurationManager.AppSettings["MyReportViewerDomain"]);

            //ResultadoReportViewer.ServerReport.ReportServerCredentials = irsc;
            ResultadoReportViewer.ServerReport.SetParameters(parametros);
            ResultadoReportViewer.Visible = true;
            ResultadoReportViewer.ServerReport.Refresh();
        }

        public List<SESION_VOTACION> Sesiones
        {
            set 
            { 
                SessionDropDownList.DataSource = value;
                SessionDropDownList.DataValueField = "ID_SESION";
                SessionDropDownList.DataTextField = "NOMBRE_SESION";
                SessionDropDownList.DataBind();
                SessionDropDownList.Items.Insert(0, new ListItem("[Seleccione]", "0"));
            }
        }

        public List<Candidato> Candidatos { set; private get; }
    }
}