using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Votacion_BO;
using Votacion_DAL;

namespace Votacion_WebSite.Reports
{
    public partial class Historigrama : Page
    {
        private ReportesBO _presentador;

        protected override void OnInit(EventArgs e)
        {
            //_presentador = new ReportesBO(this);
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    int empresaId = Convert.ToInt32(Request["idEmpresa"]);
                    _presentador.ObtenerSesiones(empresaId);
            }
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
        protected void ConsultarButtonClick(object sender, EventArgs e)
        {
            var reportPath = "/VotacionesPG/Historigrama";
            HistorigramaReportViewer.Visible = true;
            HistorigramaReportViewer.ServerReport.ReportServerUrl =
                new Uri(ConfigurationManager.AppSettings["MyReportViewerUrl"]);
            HistorigramaReportViewer.ProcessingMode = ProcessingMode.Remote;
            HistorigramaReportViewer.ServerReport.ReportPath = reportPath;
            HistorigramaReportViewer.ShowParameterPrompts = false;

            ReportParameter candidatoId = new ReportParameter("CandidatoId", CandidatoDropdownList.SelectedValue);
            ReportParameter sesionId = new ReportParameter("SesionId", SesionDropDownList.SelectedValue);

            List<ReportParameter> parametros = new List<ReportParameter>();
            parametros.Add(candidatoId);
            parametros.Add(sesionId);

            //IReportServerCredentials irsc =
            //    new CustomReportCredentials(ConfigurationManager.AppSettings["MyReportViewerUser"],
            //                                ConfigurationManager.AppSettings["MyReportViewerPassword"],
            //                                ConfigurationManager.AppSettings["MyReportViewerDomain"]);

            //HistorigramaReportViewer.ServerReport.ReportServerCredentials = irsc;
            HistorigramaReportViewer.ServerReport.SetParameters(parametros);
            HistorigramaReportViewer.Visible = true;
            HistorigramaReportViewer.ServerReport.Refresh();
        }

        public List<SESION_VOTACION> Sesiones
        {
            set
            {
                SesionDropDownList.DataSource = value;
                SesionDropDownList.DataValueField = "ID_SESION";
                SesionDropDownList.DataTextField = "NOMBRE_SESION";
                SesionDropDownList.DataBind();
                SesionDropDownList.Items.Insert(0, new ListItem("--Seleccione--", "0"));
            }
        }
        public List<Candidato> Candidatos
        {
            set
            {
                CandidatoDropdownList.DataSource = value;
                CandidatoDropdownList.DataValueField = "UsuarioId";
                CandidatoDropdownList.DataTextField = "NombreCompleto";
                CandidatoDropdownList.DataBind();
                CandidatoDropdownList.Items.Insert(0, new ListItem("--Seleccione--", "0"));
            }
        }

        protected void SesionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CandidatoDropdownList.Enabled = true;
            _presentador.ObtenerCandidatos(Convert.ToInt32(SesionDropDownList.SelectedValue), Convert.ToInt32(Request["idEmpresa"]));
        }

        protected void CandidatoDropdownListSelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarButton.Enabled = true;
        }
    }
}