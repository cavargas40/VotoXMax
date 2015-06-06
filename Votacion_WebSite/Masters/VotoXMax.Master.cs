using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Votacion_WebSite.Masters
{
    public partial class VotoXMax : System.Web.UI.MasterPage
    {
        protected void ScriptManagerAsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
            string exceptionMessge = e.Exception.InnerException != null ? e.Exception.InnerException.Message : e.Exception.Message;
            string userMessage = string.Empty;

            if (string.IsNullOrEmpty(userMessage))
            {
                userMessage = "Ha ocurrido un error mientras se realizaba la petición al servidor.";
            }

            scriptManager.AsyncPostBackErrorMessage = userMessage;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["dsUser"] == null)
                {
                    lbExit.Visible = false;
                    lbUser.Text = "";
                }
                else
                {
                    DataSet dsData = (DataSet)Session["dsUser"];
                    if (dsData != null && dsData.Tables[0].Rows.Count > 0)
                    {
                        lbUser.Text = "Bienvenido:  " + dsData.Tables[0].Rows[0][3].ToString();
                    }

                    lbExit.Visible = true;
                }
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
    }
}