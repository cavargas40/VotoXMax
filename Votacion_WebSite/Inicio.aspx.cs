using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacion_BO;
using Votacion_DAL;

namespace Votacion_WebSite
{
    public partial class Inicio : System.Web.UI.Page
    {
        #region Global

        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            DataSet dsData;
            if (sigInUser(UserName.Text, Password.Text, out dsData))
            {
                Response.Redirect("~/Pages/Principal.aspx");
            }
        }
        #endregion

        #region Methods


        public bool sigInUser(string user, string password, out DataSet dsUser)
        {
            try
            {
                new UsuarioBO().sigIn(user, password, out dsUser);
                Session["dsUser"] = dsUser;


                var userQuery = new LogicUsuario().Login(
                                new VoUser
                                {
                                    NombreUsuario = this.UserName.Text,
                                    Contrasenia = this.Password.Text
                                });

                if (userQuery == null)
                {
                    this.FailureText.Text = "El usuario o contraseña estan errados. <br> Intentelo de nuevo.";
                }
                else
                {
                    this.Session["UserObject"] = userQuery;
                    this.FailureText.Text = string.Empty;
                }


                if (dsUser.Tables[0].Rows.Count < 1)
                {
                    return false;
                }
                else
                {
                    Session["company"] = dsUser.Tables[0].Rows[0]["ID_EMPRESA"].ToString();
                    return true;
                }






            }
            catch (Exception)
            {
                dsUser = new DataSet();
                return false;
            }
        }
        #endregion
    }
}