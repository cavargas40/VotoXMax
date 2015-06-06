using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using Votacion_BO;
using Votacion_DAL;

namespace Votacion_WebSite.Pages
{
    public partial class Votaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSesionVotacion();
                CargarAreas();
            }
        }

        private void CargarAreas()
        {
            try
            {
                cblstAreas.DataSource = new VotacionBO().AreaPorEmpresa(Convert.ToInt32(((DataSet)Session["dsUser"]).Tables[0].Rows[0]["ID_EMPRESA"]));
                cblstAreas.DataTextField = "NOMBRE_AREA";
                cblstAreas.DataValueField = "ID_AREA";
                cblstAreas.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarSesionVotacion()
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
                gdvVotaciones.DataSource = dtSesVot;
                gdvVotaciones.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                int idnewSes = new VotacionBO().InsertarVotacion(new SESION_VOTACION()
                {
                    ID_EMPRESA = Convert.ToInt32(((DataSet)Session["dsUser"]).Tables[0].Rows[0]["ID_EMPRESA"]),
                    NOMBRE_SESION = txtCampania.Text,
                    ESTADO = true,
                    FECHA_INICIO = Convert.ToDateTime(Request["txtFechaIni"].ToString()),
                    FECHA_FIN = Convert.ToDateTime(Request["txtFechaFin"].ToString()),
                    FECHA_INI_INSCRIPCION = Convert.ToDateTime(Request["txtFechaInsIni"].ToString()),
                    FECHA_FIN_INSCRIPCION = Convert.ToDateTime(Request["txtFechaInsFin"].ToString())
                });
                {
                    foreach (ListItem i in cblstAreas.Items)
                    {
                        if (i.Selected)
                        {
                            new VotacionBO().InsertarAreaSesion(new AREA_SESION() { ID_AREA = int.Parse(i.Value), ID_SESION = idnewSes });
                        }
                    }
                    if (((Button)sender).ID == "btnGuardarSalir")
                    {
                        Response.Redirect("~/Pages/Principal.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "JScript1", "ShowDiv('data');", true);
                        CargarSesionVotacion();
                        gdvVotaciones.SelectedIndexChanged += new EventHandler(gdvVotaciones_SelectedIndexChanged);
                    }
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (new VotacionBO().ModificarVotaciones(new SESION_VOTACION()
                {
                    ID_SESION = Convert.ToInt32(gdvVotaciones.SelectedValue),
                    ID_EMPRESA = Convert.ToInt32(((DataSet)Session["dsUser"]).Tables[0].Rows[0]["ID_EMPRESA"]),
                    NOMBRE_SESION = txtCampania.Text,
                    ESTADO = true,
                    FECHA_INICIO = Convert.ToDateTime(txtFechaIni.Text),
                    FECHA_FIN = Convert.ToDateTime(txtFechaFin.Text),
                    FECHA_INI_INSCRIPCION = Convert.ToDateTime(txtFechaInsIni.Text),
                    FECHA_FIN_INSCRIPCION = Convert.ToDateTime(txtFechaInsFin.Text)
                }))
                {
                    foreach (ListItem i in cblstAreas.Items)
                    {
                        new VotacionBO().EliminarAreaVotaciones(new AREA_SESION() { ID_AREA = int.Parse(i.Value), ID_SESION = Convert.ToInt32(gdvVotaciones.SelectedValue) });
                        if (i.Selected)
                        {
                            new VotacionBO().InsertarAreaSesion(new AREA_SESION() { ID_AREA = int.Parse(i.Value), ID_SESION = Convert.ToInt32(gdvVotaciones.SelectedValue) });
                        }
                    }
                    if (((Button)sender).ID == "btnActaulizarSalir")
                    {
                        Response.Redirect("~/Pages/Principal.aspx");
                    }
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCampania.Text = string.Empty;
            txtFechaIni.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            txtFechaInsIni.Text = string.Empty;
            txtFechaInsFin.Text = string.Empty;
            btnActualizar.Visible = false;
            btnActaulizarSalir.Visible = false;
            btnNuevo.Visible = false;
            btnGuardar.Visible = true;
            btnEliminar.Visible = false;
            btnGuardarSalir.Visible = true;
            gdvVotaciones.SelectedIndex = -1;
            cblstAreas.ClearSelection();
            //panCampos.GroupingText = "Agregando Votación...";
        }

        protected void gdvVotaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int idSeleccion = Convert.ToInt32(gdvVotaciones.SelectedRow.Cells[0].Text);
            cblstAreas.ClearSelection();
            int idSeleccion = Convert.ToInt32(gdvVotaciones.SelectedValue);
            List<AREA_SESION> lstarse = new VotacionBO().AreaSesion(idSeleccion);
            foreach (AREA_SESION arse in lstarse)
            {
                int pos = cblstAreas.Items.IndexOf(((ListItem)cblstAreas.Items.FindByValue(arse.ID_AREA.ToString())));
                cblstAreas.Items[pos].Selected = true;
            }
            SESION_VOTACION sv = new VotacionBO().ConsultarVotacionesPorId(idSeleccion);
            txtCampania.Text = sv.NOMBRE_SESION;
            txtFechaIni.Text = sv.FECHA_INICIO.Value.ToString("dd/MM/yyyy");
            txtFechaFin.Text = sv.FECHA_FIN.Value.ToString("dd/MM/yyyy");
            txtFechaInsIni.Text = sv.FECHA_INI_INSCRIPCION.Value.ToString("dd/MM/yyyy");
            txtFechaInsFin.Text = sv.FECHA_FIN_INSCRIPCION.Value.ToString("dd/MM/yyyy");
            btnActualizar.Visible = true;
            btnActaulizarSalir.Visible = true;
            btnEliminar.Visible = true;
            btnNuevo.Visible = true;
            btnGuardar.Visible = false;
            btnGuardarSalir.Visible = false;
            panCampos.GroupingText = "Editando Votación...";
            if (DateTime.Now > sv.FECHA_INICIO.Value && DateTime.Now < sv.FECHA_FIN)
            {
                txtCampania.Enabled = false;
                txtFechaFin.Enabled = false;
                txtFechaIni.Enabled = false;
                txtFechaInsFin.Enabled = false;
                txtFechaInsIni.Enabled = false;
                btnActualizar.Enabled = false;
                btnActaulizarSalir.Enabled = false;
                btnEliminar.Enabled = false;
                panCampos.GroupingText = "No es posible editarlo ya que los usuarios estan realizando votos...";
                panCampos.BorderColor = Color.Red;
            }
            else if (DateTime.Now > sv.FECHA_INI_INSCRIPCION.Value && DateTime.Now < sv.FECHA_FIN_INSCRIPCION)
            {
                txtCampania.Enabled = false;
                txtFechaFin.Enabled = false;
                txtFechaIni.Enabled = false;
                txtFechaInsFin.Enabled = false;
                txtFechaInsIni.Enabled = false;
                btnActualizar.Enabled = false;
                btnActaulizarSalir.Enabled = false;
                btnEliminar.Enabled = false;
                panCampos.GroupingText = "No es posible editarlo ya que los usuarios se estan inscribiendo...";
                panCampos.BorderColor = Color.Red;
            }
        }

        protected bool Validar()
        {
            try
            {
                bool bien = false;

                //if (DateTime.Parse(Request["txtFechaInsIni"].ToString()).Date >= DateTime.Now.Date)
                //{
                //    if (DateTime.Parse(Request["txtFechaInsIni"].ToString()) <= DateTime.Parse(Request["txtFechaInsFin"].ToString()))
                //    {
                //        if (DateTime.Parse(Request["txtFechaIni"].ToString()) <= DateTime.Parse(Request["txtFechaFin"].ToString()))
                //        {
                //            if (DateTime.Parse(Request["txtFechaInsFin"].ToString()) < DateTime.Parse(Request["txtFechaIni"].ToString()))
                //            {
                                //int cnt = 0;
                                //foreach (ListItem item in cblstAreas.Items)
                                //{
                                //    if (item.Selected)
                                //        cnt++;
                                //}
                                //if (cnt > 0)
                                //{
                                    bien = true;
                                //}
                                //else
                                //{
                                //    lblErrorChekList.Text = "Debe seleccionar al menos una o más areas";
                                //}
                //            }
                //            else
                //            {
                //                lblErrorFechaIns.Text = "La fecha Final de Inscripción debe ser menor a la Fecha inicial de Votación";
                //            }
                //        }
                //        else
                //        {
                //            lblErrorFecha.Text = "La fecha Inicial de Votación debe ser menor a la Fecha final de Votación";
                //        }
                //    }
                //    else
                //    {
                //        lblErrorFechaIns.Text = "La fecha Inicial de Inscripción debe ser menor a la Fecha final de Inscripción";
                //    }
                //}
                //else
                //{
                //    lblErrorFechaIns.Text = "La fecha Inicial de Inscripción no debe ser menor al  dia de hoy";
                //}

                return bien;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarEliminar())
                {
                    new VotacionBO().EliminarVotaciones(Convert.ToInt32(gdvVotaciones.SelectedValue));
                    new VotacionBO().EliminarAreaVotacionesPorIdSesion(Convert.ToInt32(gdvVotaciones.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected bool ValidarEliminar()
        {
            try
            {
                bool bien = false;

                if (DateTime.Parse(txtFechaInsIni.Text) > DateTime.Now)
                {
                    if (DateTime.Parse(txtFechaInsIni.Text) <= DateTime.Parse(txtFechaInsFin.Text))
                    {
                        if (DateTime.Parse(txtFechaIni.Text) <= DateTime.Parse(txtFechaFin.Text))
                        {
                            if (DateTime.Parse(txtFechaInsFin.Text) < DateTime.Parse(txtFechaIni.Text))
                            {

                                bien = true;
                            }
                            else
                            {
                                lblErrorFechaIns.Text = "La fecha Final de Inscripción debe ser menor a la Fecha inicial de Votación";
                            }
                        }
                        else
                        {
                            lblErrorFecha.Text = "La fecha Inicial de Votación debe ser menor a la Fecha final de Votación";
                        }
                    }
                    else
                    {
                        lblErrorFechaIns.Text = "La fecha Inicial de Inscripción debe ser menor a la Fecha final de Inscripción";
                    }
                }
                else
                {
                    lblErrorFechaIns.Text = "La fecha Inicial de Inscripción debe ser mayor a la Fecha actual";
                }

                return bien;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}