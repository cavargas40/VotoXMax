using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacion_BO;
using Votacion_DAL;

namespace Votacion_WebSite.Pages
{
    public partial class InscribirUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
                imgCandidato.ImageUrl = "~/IMG/Candidatos/UsuarioNoFoto.jpg";
                //cargarSesiones();
                //CargarUsuario();
            }
        }

        protected void CargarUsuarios()
        {
            int empresaId = Convert.ToInt32(Session["company"]);
            DataSet dsData;
            UsuarioBO users = new UsuarioBO();
            users.ListUserCompany(empresaId, out dsData);
            ddlUsuario.DataSource = dsData;
            ddlUsuario.DataValueField = "ID_USUARIO";
            ddlUsuario.DataTextField = "NOMBRES";
            ddlUsuario.DataBind();
            //ddlUsuario.Items.Insert(0, new ListItem("--SELECCIONE--", "--SELECCIONE--"));
        }

        protected void cargarSesiones(int usuarioId, int empresaId)
        {
            try
            {
                
                ddlSesion.DataSource = new VotacionBO().SesionesVotaciones(usuarioId, empresaId);
                ddlSesion.DataValueField = "ID_SESION";
                ddlSesion.DataTextField = "NOMBRE_SESION";
                ddlSesion.DataBind();
                //ddlSesion.Items.Insert(0, new ListItem("--SELECCIONE--", "--SELECCIONE--"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarUsuario(int usuarioId)
        {
            try
            {
                DataSet usuarioInfo;
                UsuarioBO users = new UsuarioBO();
                users.UserDetails(usuarioId,out usuarioInfo);
                string imagen = usuarioInfo.Tables[0].Rows[0]["IMAGEN"].ToString();
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
                    cand.ID_USUARIO = Convert.ToInt32(ddlUsuario.SelectedValue);
                    cand.IMAGEN = imgCandidato.ImageUrl.Replace("~/temp/", "~/IMG/Candidatos/");
                    cand.NUMERO = int.Parse(txtNumCand.Text);
                    SESION_CANDIDATO sc = new SESION_CANDIDATO();
                    sc.ID_CANDIDATO = Convert.ToInt32(ddlUsuario.SelectedValue);
                    sc.ID_SESION = int.Parse(ddlSesion.SelectedValue);

                    File.Move(Server.MapPath(imgCandidato.ImageUrl), Server.MapPath(cand.IMAGEN));

                    if (new VotacionBO().InscribirCandidato(cand))
                        if (new VotacionBO().RegistroCandidato(sc))
                            Response.Redirect("~/Pages/InscribirUsuario.aspx");
                }
                else
                {
                    lblMsgImgReq.Text = "Imagen Requerida";
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

            cargarSesiones(Convert.ToInt32(ddlUsuario.SelectedValue), Convert.ToInt32(Session["company"]));
            CargarUsuario(Convert.ToInt32(ddlUsuario.SelectedValue));
        }
    }
}