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

namespace Votacion_WebSite.Administrator
{
    public partial class EditUser : System.Web.UI.Page
    {
        /// <summary>
        /// The logic.
        /// </summary>
        readonly private LogicUsuario logic = new LogicUsuario();

        /// <summary>
        /// Gets or sets the get user.
        /// </summary>
        private VoUser UserL
        {
            get
            {
                var userL = (VoUser)this.Session["UserObjectEdit"];
                return userL;
            }

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
        /// The event.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (this.UserA != null && this.UserA.IdRol < 3)
                {
                    this.LoadControls();
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }
        }

        /// <summary>
        /// The load company.
        /// </summary>
        private void LoadCompany()
        {
            var companyList = this.logic.SelectCompany();
            //companyList.Add(new VoCompany { IdEmpresa = 0, NombreEmpresa = string.Empty });
            this.Company.DataSource = companyList.OrderBy(c => c.NombreEmpresa);
            this.Company.DataTextField = "NombreEmpresa";
            this.Company.DataValueField = "IdEmpresa";
            this.Company.DataBind();
        }

        /// <summary>
        /// The load type user.
        /// </summary>
        public void LoadTypeUser()
        {
            this.TipeUser.DataSource = this.logic.SelectTypeUser();
            this.TipeUser.DataTextField = "NameTypeUser";
            this.TipeUser.DataValueField = "IdTipeUser";
            this.TipeUser.DataBind();
        }

        /// <summary>
        /// The load area.
        /// </summary>
        private void LoadArea()
        {
            var areaList = this.logic.SelectAreaCompany(Convert.ToInt16(this.Company.SelectedValue));
            //areaList.Add(new VoArea { IdArea = 0, NombreArea = string.Empty });

            this.Area.DataSource = areaList.OrderBy(a => a.NombreArea);
            this.Area.DataTextField = "NombreArea";
            this.Area.DataValueField = "IdArea";
            this.Area.DataBind();

            if (areaList.Count == 0)
            {
                lbArea.Visible = true;
                btAddArea.Visible = true;
            }
            else
            {
                lbArea.Visible = false;
                btAddArea.Visible = false;
            }

        }

        /// <summary>
        /// The upload image_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event.
        /// </param>
        protected void UploadImage_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(this.Identificacion.Text))
            //{
            //    this.FailureTextImage.Text = "Antes ingrese su número de documento.";
            //    return;
            //}

            if (this.ImageUrl.HasFile)
            {
                this.SaveFile();
            }
            else
            {
                this.FailureTextImage.Text = "Seleccione su imagen.";
            }
        }

        /// <summary>
        /// The save file.
        /// </summary>
        private void SaveFile()
        {
            var extension = System.IO.Path.GetExtension(this.ImageUrl.FileName);
            if (extension != null)
            {
                var fileExtension = extension.ToLower();
                var allowedExtensions = new List<string> { ".gif", ".png", ".jpeg", ".jpg" };
                if (allowedExtensions.Contains(fileExtension))
                {
                    try
                    {
                        var finalPath = Server.MapPath("~") + "/IMG/Candidatos/" + ImageUrl.FileName;
                        //var finalPath = WebConfigurationManager.AppSettings.Get("RutaImagen")
                        //                + this.Identificacion.Text + fileExtension;
                        this.ImageUrl.SaveAs(finalPath);
                        this.ImageUser.ImageUrl = "~/IMG/Candidatos/" + ImageUrl.FileName;
                    }
                    catch
                    {
                        this.FailureTextImage.Text = "El archivo no se a cargado intentelo de nuevo.";
                    }
                }
            }
        }

        /// <summary>
        /// The company_ selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadArea();
        }

        /// <summary>
        /// The register user_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void RegisterUser_Click(object sender, EventArgs e)
        {
            if (this.ConfirmPassword.Text.Length < 6)
            {
                this.LenghPass.Text = "La contraseña debe tener 6 caracteres como minimo.";
            }

            if (string.IsNullOrEmpty(this.ImageUser.ImageUrl))
            {
                this.FailureTextImage.Text = "Seleccione su imagen.";
            }

            var user = this.CreateUser();
            int id;

            if (this.UserL == null)
            {
                id = this.logic.InsertUser(user);
            }
            else
            {
                this.logic.UpdateUser(user);
                id = user.IdUser;
            }

            if (id != 0)
            {
                this.UserL = user;
                this.FailureText.Text = string.Empty;
                this.Response.Redirect("../Administrator/AdmUser.aspx");
            }
            else
            {
                this.FailureText.Text = "Se ha presentado un error al guardar el usuario. <br> Intentelo de nuevo.";
            }
        }

        /// <summary>
        /// The create user.
        /// </summary>
        /// <returns>
        /// The <see cref="VoUser"/>.
        /// </returns>
        private VoUser CreateUser()
        {
            var user = this.UserL ?? new VoUser();
            user.Apellidos = this.LastName.Text;
            user.Contrasenia = this.Password.Text;
            user.FechaNacimiento = Convert.ToDateTime(Request["MainContent_FirdsDate"].ToString());
            user.Genero = this.Genero.SelectedValue;
            user.IdArea = Convert.ToInt16(this.Area.SelectedValue);
            user.IdTipoUsuario = Convert.ToInt16(this.TipeUser.SelectedValue);
            user.IdRol = TipeUser.SelectedValue == "1" ? 3 : TipeUser.SelectedValue == "2" ? 3 : TipeUser.SelectedValue == "3" ? 2 : int.Parse(TipeUser.SelectedValue);
            user.Identficacion = this.Identificacion.Text;
            user.TypeDocument = this.TypeDocument.SelectedValue;
            user.Imagen = this.ImageUser.ImageUrl;
            user.NombreUsuario = this.UserName.Text;
            user.Nombres = this.NamePerson.Text;
            user.Numero = Convert.ToInt16(0);
            return user;
        }

        /// <summary>
        /// The load controls.
        /// </summary>
        private void LoadControls()
        {
            this.LoadCompany();

            if (Request.QueryString["company"] != null)
            {

                Company.SelectedValue = Request.QueryString["company"];
                Company.Enabled = false;
            }


            this.LoadTypeUser();
            if (this.UserL != null)
            {
                this.LastName.Text = this.UserL.Apellidos;
                this.Password.Text = this.UserL.Contrasenia;
                this.MainContent_FirdsDate.Text = this.UserL.FechaNacimiento.ToString();
                this.Genero.SelectedValue = this.UserL.Genero;
                this.Company.SelectedValue = this.UserL.IdCompany.ToString(CultureInfo.InvariantCulture);
                this.Area.SelectedValue = this.UserL.IdArea.ToString();
                this.TipeUser.SelectedValue = this.UserL.IdTipoUsuario.ToString();
                this.Identificacion.Text = this.UserL.Identficacion;
                this.TypeDocument.SelectedValue = this.UserL.TypeDocument;
                this.ImageUser.ImageUrl = this.UserL.Imagen;
                this.UserName.Text = this.UserL.NombreUsuario;
                this.NamePerson.Text = this.UserL.Nombres;

            }

            this.LoadArea();
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
            this.Session["UserObjectEdit"] = null;
            this.Response.Redirect("~/Administrator/AdmUser.aspx");
        }

        protected void btAddArea_Click(object sender, EventArgs e)
        {
            if (Session["rol"] != null)
            {
                if (Session["rol"].ToString() == "2")
                {
                    Response.Redirect("~/Pages/areas.aspx?company=" + Session["company"]);
                    //Response.Redirect("addArea.aspx?company=" + ddlCompany.SelectedValue);
                }
                else
                {
                    Response.Redirect("~/Pages/Areas.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Pages/Areas.aspx");
            }
        }

        protected void Identificacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!documentUniqe(Identificacion.Text))
                {
                    lbDocumentoUnique.Visible = true;
                    RegisterUser.Visible = false;
                }
                else
                {
                    lbDocumentoUnique.Visible = false;
                    RegisterUser.Visible = true;
                }
            }
            catch (Exception)
            {

            }
        }

        protected void UserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                 if (!userNameUnique(UserName.Text))
            {
                lbUserUnique.Visible = true;
                RegisterUser.Visible = false;
            }
            else
            {
                lbUserUnique.Visible = false;
                RegisterUser.Visible = true;
            }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool userNameUnique(string userName)
        {
            try
            {
                DataSet dsData = new DataSet();
                new UsuarioBO().userNameUnique(userName, out dsData);

                if (dsData.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public bool documentUniqe(string document)
        {
            try
            {
                DataSet dsData = new DataSet();
                new UsuarioBO().documentUniqe(document, out dsData);

                if (dsData.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}