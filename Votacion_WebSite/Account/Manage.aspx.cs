using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacion_BO;

namespace Votacion_WebSite.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        /// <summary>
        /// Gets or sets the get user.
        /// </summary>
        private VoUser UserL
        {
            get
            {
                var userL = (VoUser)this.Session["UserObject"];
                return userL;
            }
        }

        /// <summary>
        /// The logic.
        /// </summary>
        readonly private LogicUsuario logic = new LogicUsuario();

        /// <summary>
        /// The page_ load.
        /// </summary>
        protected void Page_Load()
        {
        }

        /// <summary>
        /// The set password_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void setPassword_Click(object sender, EventArgs e)
        {
            if (this.UserL.Contrasenia == this.OldPassword.Text)
            {
                this.TextFailure.Text =
                    this.logic.ChangePassword(this.UserL.IdUser, this.password.Text) ?
                    "Su contraseña se ha modificado" :
                    "Su contraseña no se ha modificado <br> Intentelo de nuevo.";
            }
        }
    }
}