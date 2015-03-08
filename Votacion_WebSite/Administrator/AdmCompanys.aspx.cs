using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacion_BO;

namespace Votacion_WebSite.Administrator
{
    /// <summary>
    /// The adm companys.
    /// </summary>
    public partial class AdmCompanys : Page
    {
        /// <summary>
        /// The logic.
        /// </summary>
        readonly private LogicCompany logic = new LogicCompany();

        /// <summary>
        /// Gets or sets the list users.
        /// </summary>
        public List<VoCompany> ListCompanys
        {
            get
            {
                this.Session["ListCompany"] = this.logic.SelectAllComapanys();
                return (List<VoCompany>)this.Session["ListCompany"];
            }

            set
            {
                this.Session["ListUsers"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the company l.
        /// </summary>
        private VoCompany CompanyL
        {
            get
            {
                return (VoCompany)(this.Session["CompanyObjectEdit"] ?? new VoCompany());
            }

            set
            {
                this.Session["CompanyObjectEdit"] = value;
            }
        }

        /// <summary>
        /// Gets user Admin.
        /// </summary>
        private VoUser UserA
        {
            get
            {
                return (VoUser)this.Session["UserObject"];
            }
        }

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (this.UserA != null && this.UserA.IdRol < 3)
                {
                    this.LoadCompanysGrid(0);
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }

        /// <summary>
        /// The load users grid.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        private void LoadCompanysGrid(int page)
        {
            this.GridCompany.DataSource = this.ListCompanys;
            this.GridCompany.PageIndex = page;
            this.GridCompany.DataBind();
            this.SelectCompany.Visible = true;
            this.DataCompany.Visible = false;
        }

        /// <summary>
        /// The new company_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void NewCompany_Click(object sender, EventArgs e)
        {
            this.CompanyL = null;
            this.GetCompany();
        }

        /// <summary>
        /// The register company_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void RegisterCompany_Click(object sender, EventArgs e)
        {
            this.SetCompany();
        }

        /// <summary>
        /// The set company.
        /// </summary>
        private void SetCompany()
        {
            var company = this.CompanyL;
            company.NombreEmpresa = this.NameCompany.Text;
            company.NitEmpresa = this.Nit.Text;
            company.DireccionEmpresa = this.Address.Text;
            company.TelefonoEmpresa = this.Telephone.Text;
            company.CorreoEmpresa = this.Mail.Text;

            if (company.IdEmpresa == 0)
            {
                this.logic.InsertCompany(company);
            }
            else
            {
                this.logic.UpdateCompany(company);
            }

            this.LoadCompanysGrid(this.GridCompany.PageIndex);
        }

        /// <summary>
        /// The get company.
        /// </summary>
        private void GetCompany()
        {
            var company = this.CompanyL;
            this.Mail.Text = company.CorreoEmpresa;
            this.NameCompany.Text = company.NombreEmpresa;
            this.Nit.Text = company.NitEmpresa;
            this.Address.Text = company.DireccionEmpresa;
            this.Telephone.Text = company.TelefonoEmpresa;
            this.SelectCompany.Visible = false;
            this.DataCompany.Visible = true;
        }

        /// <summary>
        /// The volver_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Volver_Click(object sender, EventArgs e)
        {
            this.LoadCompanysGrid(this.GridCompany.PageIndex);
        }

        /// <summary>
        /// The grid company_ row command.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void GridCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Delete":
                    this.logic.DeleteCompany(index);
                    this.LoadCompanysGrid(this.GridCompany.PageIndex);
                    break;
                case "Edit":
                    this.CompanyL = this.ListCompanys.FirstOrDefault(u => u.IdEmpresa == index);
                    this.GetCompany();
                    break;
            }
        }

        /// <summary>
        /// The grid company_ row deleting.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void GridCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        /// <summary>
        /// The grid company_ row editing.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void GridCompany_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void GridCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.LoadCompanysGrid(e.NewPageIndex);
        }
    }
}