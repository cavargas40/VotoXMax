using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Votacion_BO;
using Votacion_DAL;
using System.IO;

namespace Votacion_WebSite.Pages
{
    public partial class Postular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarSesiones();
                CargarUsuario();
            }
        }

        protected void cargarSesiones()
        {
            try
            {
                ddlSesion.DataSource = new VotacionBO().SesionesVotaciones(Convert.ToInt32(((DataSet)Session["dsUser"]).Tables[0].Rows[0]["ID_USUARIO"]), Convert.ToInt32(((DataSet)Session["dsUser"]).Tables[0].Rows[0]["ID_EMPRESA"]));
                ddlSesion.DataValueField = "ID_SESION";
                ddlSesion.DataTextField = "NOMBRE_SESION";
                ddlSesion.DataBind();
                ddlSesion.Items.Insert(0, new ListItem("--SELECCIONE--", "--SELECCIONE--"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarUsuario()
        {
            try
            {
                // USUARIO userLogin = (USUARIO)Session["UserLogin"];
                string imagen = ((DataSet)Session["dsUser"]).Tables[0].Rows[0]["IMAGEN"].ToString();
                imgCandidato.ImageUrl = imagen == "" ? "~/IMG/Candidatos/UsuarioNoFoto.jpg" : imagen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnPostular_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgCandidato.ImageUrl != "~/IMG/Candidatos/UsuarioNoFoto.jpg")
                {
                    USUARIO cand = new USUARIO();
                    cand.ID_USUARIO = Convert.ToInt32(((DataSet)Session["dsUser"]).Tables[0].Rows[0]["ID_USUARIO"]);
                    cand.IMAGEN = imgCandidato.ImageUrl.Replace("~/temp/", "~/IMG/Candidatos/");
                    cand.NUMERO = int.Parse(txtNumCand.Text);
                    SESION_CANDIDATO sc = new SESION_CANDIDATO();
                    sc.ID_CANDIDATO = Convert.ToInt32(((DataSet)Session["dsUser"]).Tables[0].Rows[0]["ID_USUARIO"]);
                    sc.ID_SESION = int.Parse(ddlSesion.SelectedValue);

                    File.Move(Server.MapPath(imgCandidato.ImageUrl), Server.MapPath(cand.IMAGEN));

                    if (new VotacionBO().InscribirCandidato(cand))
                        if (new VotacionBO().RegistroCandidato(sc))
                            Response.Redirect("~/Pages/Votar.aspx");
                }
                else
                {
                    lblMsgImgReq.Text = "Imagen Requerida";
                }
            }
            catch (Exception ex)
            {
                lblMsgImgReq.Text = ex.Message;
                lblMsgImgReq.ForeColor = System.Drawing.Color.Red;
                //throw ex;
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            if (fuImagen.HasFile)
            {
                string serverPathCand = "~/temp/";
                fuImagen.SaveAs(Server.MapPath(serverPathCand + fuImagen.FileName));
                imgCandidato.ImageUrl = serverPathCand + fuImagen.FileName;
                Session.Add("FileName", fuImagen.FileName);
            }
        }

        protected void linkBtnRandomNumber_Click(object sender, EventArgs e)
        {
            Random rdn = new Random();
            txtNumCand.Text = rdn.Next(999).ToString();
        }
    }
}