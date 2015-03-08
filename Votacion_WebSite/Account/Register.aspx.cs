using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Votacion_BO;
using System.Web.Configuration;
using System.Globalization;

namespace Votacion_WebSite.Account
{
    public partial class Register : System.Web.UI.Page
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
                var userL = (VoUser)this.Session["UserObject"];
                return userL;
            }

            set
            {
                this.Session["UserObject"] = value;
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
                this.LoadCompany();

                if (this.UserL != null)
                {
                    this.LoadControls();
                }
            }
        }

        /// <summary>
        /// The load company.
        /// </summary>
        private void LoadCompany()
        {
            var companyList = this.logic.SelectCompany();
            companyList.Add(new VoCompany { IdEmpresa = 0, NombreEmpresa = string.Empty });
            this.Company.DataSource = companyList.OrderBy(c => c.NombreEmpresa);
            this.Company.DataTextField = "NombreEmpresa";
            this.Company.DataValueField = "IdEmpresa";
            this.Company.DataBind();
        }

        /// <summary>
        /// The load area.
        /// </summary>
        private void LoadArea()
        {
            var areaList = this.logic.SelectAreaCompany(Convert.ToInt16(this.Company.SelectedValue));
            areaList.Add(new VoArea { IdArea = 0, NombreArea = string.Empty });
            this.Area.DataSource = areaList.OrderBy(a => a.NombreArea);
            this.Area.DataTextField = "NombreArea";
            this.Area.DataValueField = "IdArea";
            this.Area.DataBind();
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
            if (string.IsNullOrEmpty(this.Identificacion.Text))
            {
                this.FailureTextImage.Text = "Antes ingrese su número de documento.";
                return;
            }

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
                        var finalPath = WebConfigurationManager.AppSettings.Get("RutaImagen")
                                        + this.Identificacion.Text + fileExtension;
                        this.ImageUrl.SaveAs(finalPath);
                        this.ImageUser.ImageUrl = WebConfigurationManager.AppSettings.Get("UrlImagen") +
                                                  this.Identificacion.Text +
                                                  fileExtension;
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
                Response.Redirect("../default.aspx");
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
            user.FechaNacimiento = Convert.ToDateTime(this.FirdsDate.Text);
            user.Genero = this.Genero.SelectedValue;
            user.IdArea = Convert.ToInt16(this.Area.SelectedValue);
            user.IdTipoUsuario = 2;
            user.IdRol = 3;
            user.Identficacion = this.Identificacion.Text;
            user.TypeDocument = this.TypeDocument.SelectedValue;
            user.Imagen = this.ImageUser.ImageUrl;
            user.NombreUsuario = this.UserName.Text;
            user.Nombres = this.NamePerson.Text;
            user.Numero = Convert.ToInt16(1);
            this.UserL = user;
            return user;
        }

        /// <summary>
        /// The load controls.
        /// </summary>
        private void LoadControls()
        {
            this.LastName.Text = this.UserL.Apellidos;
            this.Password.Text = this.UserL.Contrasenia;
            this.TypeDocument.SelectedValue = this.UserL.TypeDocument;
            this.FirdsDate.Text = this.UserL.FechaNacimiento.ToString();
            this.Genero.SelectedValue = this.UserL.Genero;
            this.Company.SelectedValue = this.UserL.IdCompany.ToString(CultureInfo.InvariantCulture);
            this.LoadArea();
            this.Area.SelectedValue = this.UserL.IdArea.ToString();
            this.Identificacion.Text = this.UserL.Identficacion;
            this.ImageUser.ImageUrl = this.UserL.Imagen;
            this.UserName.Text = this.UserL.NombreUsuario;
            this.NamePerson.Text = this.UserL.Nombres;
            this.DeleteUser.Visible = this.UserL != null;
            this.RegisterUser.Text = this.UserL != null ? "Modificar" : "Registrar";
        }

        /// <summary>
        /// The delete user_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DeleteUser_Click(object sender, EventArgs e)
        {
            this.logic.DeleteUser(this.UserL.IdUser);
            this.Session.Clear();
            Response.Redirect("~/Default.aspx");
        }
    }
}