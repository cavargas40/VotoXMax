using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Votacion_BO;
using Votacion_DAL;

namespace Votacion_WebSite.Pages
{
    public partial class Votar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSesiones();
            }
        }
        protected void CargarSesiones()
        {
            try
            {
                ddlsessionaVotar.DataSource = new VotacionBO().SesionesVotacionesVotar(Convert.ToInt32(((DataSet)Session["dsUser"]).Tables[0].Rows[0]["ID_USUARIO"]), Convert.ToInt32(((DataSet)Session["dsUser"]).Tables[0].Rows[0]["ID_EMPRESA"]));
                ddlsessionaVotar.DataValueField = "ID_SESION";
                ddlsessionaVotar.DataTextField = "NOMBRE_SESION";
                ddlsessionaVotar.DataBind();
                ddlsessionaVotar.Items.Insert(0, new ListItem("--SELECCIONE--", "--SELECCIONE--"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void CargarCandidatos()
        {
            try
            {
                lstvCandidatos.DataSource = new VotacionBO().ListarCandidatosPorSesion(int.Parse(ddlsessionaVotar.SelectedValue));
                lstvCandidatos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void lstvCandidatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstvCandidatos.SelectedIndex >= 0)
                    lblError.Text = lstvCandidatos.SelectedValue.ToString();

                if (lstvCandidatos.SelectedIndex >= 0)
                    Session["SelectedKey"] = lstvCandidatos.SelectedValue;
                else
                    Session["SelectedKey"] = null;
                CargarCandidatos();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void lstvCandidatos_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i < lstvCandidatos.Items.Count; i++)
            {
                // Ignore values that cannot be cast as integer.
                try
                {
                    if ((int)lstvCandidatos.DataKeys[i].Value == (int)Session["SelectedKey"])
                        lstvCandidatos.SelectedIndex = i;
                }
                catch { }
            }
        }
        protected void lstvCandidatos_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            //lblError.Text = e.NewSelectedIndex.ToString();
        }
        protected void lstvCandidatos_PagePropertiesChanged(object sender, EventArgs e)
        {
            lstvCandidatos.SelectedIndex = -1;
            CargarCandidatos();
        }
        protected void btnVotar_Click(object sender, EventArgs e)
        {
            try
            {
                Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
                if (Captcha1.UserValidated)
                {
                    SESION_USUARIO suser = new SESION_USUARIO();
                    suser.ID_SESION = int.Parse(ddlsessionaVotar.SelectedValue);
                    suser.ID_USUARIO = Convert.ToInt32(((DataSet)Session["dsUser"]).Tables[0].Rows[0]["ID_USUARIO"]);
                    suser.TIPO_VOTO = "Normal";
                    suser.FECHA_VOTO = DateTime.Now;
                    suser.ID_USUARIO_CANDIDATO = (int)Session["SelectedKey"];
                    new VotacionBO().RegistrarVoto(suser);
                    Response.Redirect("~/Pages/Principal.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
                if (Captcha1.UserValidated)
                {
                    SESION_USUARIO suser = new SESION_USUARIO();
                    suser.ID_SESION = int.Parse(ddlsessionaVotar.SelectedValue);
                    suser.ID_USUARIO = Convert.ToInt32(((DataSet)Session["dsUser"]).Tables[0].Rows[0]["ID_USUARIO"]);
                    suser.TIPO_VOTO = "Cancelado";
                    suser.FECHA_VOTO = DateTime.Now;
                    suser.ID_USUARIO_CANDIDATO = null;
                    new VotacionBO().RegistrarVoto(suser);
                    Response.Redirect("~/Pages/Principal.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlsessionaVotar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsessionaVotar.SelectedIndex != 0)
            {
                CargarCandidatos();
                btnVotar.Visible = true;
                btnCancelar.Visible = true;
                Captcha1.Visible = true;
                txtCaptcha.Visible = true;
            }
        }
    }
}