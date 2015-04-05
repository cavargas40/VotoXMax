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
    public partial class Areas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCompanies();

                if (Request.QueryString["company"] != null)
                {

                    DataSet dsData = new DataSet();
                    new EmpresasBO().loadCompanyByIdArea(int.Parse(Request.QueryString["company"].ToString()), out dsData);

                    if (dsData.Tables[0].Rows.Count > 0)
                    {
                        ddlCompany.SelectedValue = dsData.Tables[0].Rows[0][0].ToString();
                        ddlCompany2.SelectedValue = dsData.Tables[0].Rows[0][0].ToString();
                        loadAreas(int.Parse(ddlCompany.SelectedValue));
                    }
                    ddlCompany.Enabled = false;
                    ddlCompany2.Enabled = false;
                }
                else
                {
                    loadAreas(int.Parse(ddlCompany.SelectedValue));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadAreas(int.Parse(ddlCompany.SelectedValue));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btAddArea_Click(object sender, EventArgs e)
        {
            if (Session["rol"] != null)
            {
                if (Session["rol"].ToString() == "2")
                {
                    Response.Redirect("addArea.aspx?company=" + Session["company"]);
                }
                else
                {
                    Response.Redirect("addArea.aspx");
                }
            }
            else
            {
                Response.Redirect("addArea.aspx");
            }
        }
        protected void gvArea_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvArea.EditIndex = -1;
            loadAreas(int.Parse(ddlCompany.SelectedValue));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvArea_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lb_AREA = new Label();
            try
            {
                lblError.Visible = false;
                lblError.Text = String.Empty;
                Label lbID_AREA = gvArea.Rows[e.RowIndex].FindControl("lbID_AREA") as Label;
                lb_AREA = gvArea.Rows[e.RowIndex].FindControl("lbNOMBRE_AREA") as Label;
                deleteArea(int.Parse(lbID_AREA.Text));
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("dbo.AREA_SESION"))
                {
                    lblError.Visible = true;
                    lblError.Text = "No se puede eliminar " + lb_AREA.Text + " porque está programada para una votación, Por favor verifique que no esté seleccionada y que no esté en este momento realizando votaciones en la opción Votación del menú principal";
                }
                else if (ex.Message.Contains("dbo.USUARIO"))
                {
                    lblError.Visible = true;
                    lblError.Text = "No se puede eliminar " + lb_AREA.Text + " porque hay usuarios registrado en el área, Por favor verifique que no haya usuarios";
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvArea_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvArea_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvArea_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label lbID_AREA = gvArea.Rows[e.RowIndex].FindControl("lbID_AREA") as Label;
                TextBox tbNOMBRE_AREA = gvArea.Rows[e.RowIndex].FindControl("tbNOMBRE_AREA") as TextBox;
                updateArea(int.Parse(lbID_AREA.Text), tbNOMBRE_AREA.Text);
                gvArea.EditIndex = -1;
                loadAreas(int.Parse(ddlCompany.SelectedValue));
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btAddArea_Click1(object sender, EventArgs e)
        {
            dvaddArea.Visible = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btAddAreaF_Click(object sender, EventArgs e)
        {
            addArea(tbNameArea.Text, int.Parse(ddlCompany2.SelectedValue));
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="companyId"></param>
        public void addArea(string name, int companyId)
        {
            try
            {
                new AreasBO().addArea(name, companyId);
                dvaddArea.Visible = false;
                tbNameArea.Text = "";
                loadAreas(int.Parse(ddlCompany.SelectedValue));
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool loadCompanies()
        {
            try
            {
                DataSet dsCompany = new DataSet();
                new EmpresasBO().loadCompanies(out dsCompany);

                ddlCompany.DataSource = dsCompany;
                ddlCompany.DataTextField = "NOMBRE_EMPRESA";
                ddlCompany.DataValueField = "ID_EMPRESA";
                ddlCompany.DataBind();

                ddlCompany2.DataSource = dsCompany;
                ddlCompany2.DataTextField = "NOMBRE_EMPRESA";
                ddlCompany2.DataValueField = "ID_EMPRESA";
                ddlCompany2.DataBind();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCompany"></param>
        /// <returns></returns>
        public bool loadAreas(int idCompany)
        {
            try
            {
                DataSet dsData = new DataSet();
                new AreasBO().loadArea(idCompany, out dsData);

                gvArea.DataSource = dsData;
                gvArea.DataBind();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idArea"></param>
        /// <returns></returns>
        public bool deleteArea(int idArea)
        {
            try
            {
                new AreasBO().deleteArea(idArea);
                loadAreas(int.Parse(ddlCompany.SelectedValue));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idArea"></param>
        /// <param name="newNameArea"></param>
        public void updateArea(int idArea, string newNameArea)
        {
            try
            {
                new AreasBO().updateArea(idArea, newNameArea);
                loadAreas(int.Parse(ddlCompany.SelectedValue));
            }
            catch (Exception)
            {

            }
        }
    }
}