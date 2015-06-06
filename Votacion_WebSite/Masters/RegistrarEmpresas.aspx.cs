using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacion_BO;
using System.Web.Configuration;
using System.Globalization;
using System.Data;

namespace Votacion_WebSite
{
    public partial class RegistrarEmpresas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarEmpresa_Click(object sender, EventArgs e)
        {
            VoUser user = new VoUser();
            user.Nombres = txtNombreAdm.Text;
            user.Apellidos = txtApellidoAdm.Text;
            user.TypeDocument = txtTipoDocAdm.Text;
            user.Identficacion = txtNumDocAdm.Text;
            user.Numero = 0;
            user.IdRol = 2;
            user.IdTipoUsuario = 3;
            user.Genero = ddlGeneroAdm.SelectedValue;
            user.NombreUsuario = txtNickUser.Text;
            user.Contrasenia = txtPass.Text;
            user.FechaNacimiento = DateTime.Parse(txtFechaNacimientoAdmin.Text);
           

            VoCompany empresa = new VoCompany();
            empresa.NitEmpresa = txtNitEmpresa.Text;
            empresa.NombreEmpresa = txtNombreEmpresa.Text;
            empresa.TelefonoEmpresa = txtTelefonoEmpresa.Text;
            empresa.DireccionEmpresa = txtDireccionEmpresa.Text;
            empresa.CorreoEmpresa = txtMailEmpresa.Text;
            new LogicCompany().RegistroNuevaEmpresaAdmin(empresa, user);
            Response.Redirect("~/Inicio.aspx?empresa=ok");
        }
    }
}