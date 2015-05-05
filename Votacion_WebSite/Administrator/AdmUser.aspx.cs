using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacion_BO;

namespace Votacion_WebSite.Administrator
{
    public partial class AdmUser : System.Web.UI.Page
    {
        /// <summary>
        /// The logic.
        /// </summary>
        readonly private LogicUsuario logic = new LogicUsuario();

        /// <summary>
        /// Gets or sets the list users.
        /// </summary>
        public List<VoUser> ListUsers
        {
            get
            {
                if (this.Session["ListUsers"] == null)
                {
                    this.Session["ListUsers"] = this.logic.SelectAllUsers();
                }

                return (List<VoUser>)this.Session["ListUsers"];
            }

            set
            {
                this.Session["ListUsers"] = value;
            }
        }

        /// <summary>
        /// Sets user.
        /// </summary>
        private VoUser UserL
        {
            set
            {
                this.Session["UserObjectEdit"] = value;
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
                    this.ListUsers = null;                    
                    this.LoadUsersGrid(0);
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
        private void LoadUsersGrid(int page)
        {
            var lista = (this.UserA.IdRol ?? 2) == 1 ? this.ListUsers : this.ListUsers.Where(u => u.IdCompany == this.UserA.IdCompany).ToList();
            this.GridUser.DataSource = lista;
            this.GridUser.PageIndex = page;
            this.GridUser.DataBind();
        }

        /// <summary>
        /// The grid user_ row command.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void GridUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Delete":
                    this.logic.DeleteUser(index);
                    this.ListUsers = null;
                    this.LoadUsersGrid(this.GridUser.PageIndex);
                    break;
                case "Edit":
                    this.UserL = this.ListUsers.FirstOrDefault(u => u.IdUser == index);
                    if (Session["rol"] != null)
                    {
                        if (Session["rol"].ToString() == "2")
                        {
                            this.Response.Redirect("~/Administrator/EditUser.aspx?company=" + Session["Company"]);
                        }
                        else
                        {
                            this.Response.Redirect("~/Administrator/EditUser.aspx");
                        }
                    }
                    else
                    {
                        this.Response.Redirect("~/Administrator/EditUser.aspx");
                    }
                    break;
            }
        }

        /// <summary>
        /// The new user_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void NewUser_Click(object sender, EventArgs e)
        {
            this.UserL = null;


            if (Session["rol"] != null)
            {
                if (Session["rol"].ToString() == "2")
                {
                    this.Response.Redirect("~/Administrator/EditUser.aspx?company=" + Session["Company"]);
                }
                else
                {
                    this.Response.Redirect("~/Administrator/EditUser.aspx");
                }
            }
            else
            {
                this.Response.Redirect("~/Administrator/EditUser.aspx");
            }


        }

        /// <summary>
        /// The grid user_ row deleting.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void GridUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        /// <summary>
        /// The grid user_ row editing.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void GridUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void GridUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.LoadUsersGrid(e.NewPageIndex);
        }
    }
}