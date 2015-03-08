using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacion_BO;
using System.Data;

namespace Votacion_WebSite.Pages
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["dsUser"] == null)
                {
                    Response.Redirect("sigIn.aspx");
                }
                else
                {
                    verifyingUser();
                }
            }
        }

        protected void imgBtnInscribir_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Postular.aspx");
        }

        protected void imgBtnVotar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Votar.aspx");
        }

        public bool verifyingUser()
        {
            try
            {
                DataSet dsUser = (DataSet)Session["dsUser"];
                DataSet dsRolUser;
                new UsuarioBO().verifyingUser(dsUser, out dsRolUser);

                if (dsRolUser.Tables[0].Rows[0][1].ToString() == "1")
                {
                    dvSuperAdmin.Visible = true;
                    dvCompanies.Visible = false;
                    dvUsers.Visible = false;
                    Session["rol"] = "1";
                }
                if (dsRolUser.Tables[0].Rows[0][1].ToString() == "2")
                {
                    dvSuperAdmin.Visible = false;
                    dvCompanies.Visible = true;
                    dvUsers.Visible = false;
                    Session["rol"] = "2";
                }
                if (dsRolUser.Tables[0].Rows[0][1].ToString() == "3")
                {
                    dvSuperAdmin.Visible = false;
                    dvCompanies.Visible = false;
                    dvUsers.Visible = true;
                    Session["rol"] = "3";
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected void btArea_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["rol"] != null)
            {
                if (Session["rol"].ToString() == "2")
                {
                    Response.Redirect("areas.aspx?company=" + Session["company"]);
                    //Response.Redirect("addArea.aspx?company=" + ddlCompany.SelectedValue);
                }
                else
                {
                    Response.Redirect("Areas.aspx");
                }
            }
            else
            {
                Response.Redirect("Areas.aspx");
            }
        }

        protected void btSuperAdmin_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administrator/AdmCompanys.aspx");
        }

        protected void btUsers_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administrator/AdmUser.aspx");
        }

        protected void btAdminUsersCompany_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Administrator/AdmUser.aspx");
        }

        protected void btVote_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Votaciones.aspx");
        }

        protected void btnCand_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/InscribirUsuario.aspx");
        }

        protected void BtnReporte_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Reports/Historigrama.aspx?idEmpresa=" + Session["company"]);
        }

        protected void ResultadoButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Reports/Resultado.aspx?idEmpresa=" + Session["company"]);
        }
    }
}