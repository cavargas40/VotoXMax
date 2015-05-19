<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Votacion_WebSite.Administrator.EditUser" %>

<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
<link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<script type="text/javascript" id="testjs">
    $(function () {
        $("#MainContent_FirdsDate").datepicker({
            changeMonth: true,
            changeYear: true,
            onSelect: function (dateText) {
                var date = $('#datepicker').val();
                document.getElementById("tbDate").value = date;
            },
            dateFormat: 'dd/mm/yy'
        });
    });

</script>
<form runat="server">
    <asp:toolkitscriptmanager id="scriptManager" runat="server" enablescriptglobalization="true"
        enablescriptlocalization="true" enablepartialrendering="true" scriptmode="Release">
            </asp:toolkitscriptmanager>
    <h2>Registrar Usuarios</h2>
    <span>la contraseña requiere minimo 6 digitos de tamaño</span>
    <div class="form-horizontal" role="form">
        <div class="form-group">
            <label class="control-label col-sm-2" for="NamePerson">Nombres:</label>
            <div class="col-sm-10">
                <%--<input type="text" class="form-control" id="NameCompany" placeholder="Ingrese Nombre"  maxlength="50" required title="El nombre de la empresa es requerido.">--%>
                <asp:textbox id="NamePerson" class="form-control" placeholder="Ingrese Nombre" runat="server" maxlength="50" runat="server" required title="El nombre de la persona es requerido." />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="LastName">Apellidos:</label>
            <div class="col-sm-10">
                <%--<input type="text" class="form-control" id="NameCompany" placeholder="Ingrese Nombre"  maxlength="50" required title="El nombre de la empresa es requerido.">--%>
                <asp:textbox id="LastName" class="form-control" placeholder="Ingrese Nombre" runat="server" maxlength="50" runat="server" required title="los apellidos de la persona son requeridos." />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="Identificacion">Identificación:</label>
            <div class="col-sm-10">
                <%--<input type="text" class="form-control" id="NameCompany" placeholder="Ingrese Nombre"  maxlength="50" required title="El nombre de la empresa es requerido.">--%>
                <asp:updatepanel runat="server">
                <contenttemplate>                 
                <%--onkeypress="return !((event.keyCode < 48) || (event.keyCode > 57));"--%>
<%--                <asp:textbox id="Identificacion" class="form-control" placeholder="Ingrese Nombre" runat="server" maxlength="50" runat="server" required title="los apellidos de la persona son requeridos." />--%>
                <asp:TextBox runat="server" ID="Identificacion" MaxLength="12"  class="form-control" placeholder="Ingrese identificacion" runat="server" required title="los apellidos de la persona son requeridos." OnTextChanged="Identificacion_TextChanged" AutoPostBack="true" />
                <asp:Label ID="lbDocumentoUnique" runat="server" Font-Size="10pt" ForeColor="Red"
                    Text="Documento ya existe, pruebe con otro" Visible="False"></asp:Label>
                </contenttemplate>
            </asp:updatepanel>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="TypeDocument">Tipo documento:</label>
            <div class="col-sm-10">
                <%--<input type="text" class="form-control" id="NameCompany" placeholder="Ingrese Nombre"  maxlength="50" required title="El nombre de la empresa es requerido.">--%>
                <asp:dropdownlist runat="server" id="TypeDocument" width="170px" height="27px">
                    <asp:ListItem Text="Cedula de Ciudadania" Value="C.C.">
                    </asp:ListItem>
                    <asp:ListItem Text="Tarjeta de Identidad" Value="T.I.">
                    </asp:ListItem>
                    <asp:ListItem Text="Cedula de Extrangeria" Value="C.E.">
                    </asp:ListItem>
                </asp:dropdownlist>
            </div>
        </div>
        <div class="form-group">
            <asp:updatepanel id="UpdatePanel1" runat="server">
                <contenttemplate>                    
            <label class="control-label col-sm-2" for="LastName">Empresa:</label>
            <div class="col-sm-4">                
                <asp:DropDownList runat="server" ID="Company" AutoPostBack="True" OnSelectedIndexChanged="Company_SelectedIndexChanged"
                            Height="23px" Width="171px" />
               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Company"
                            CssClass="field-validation-error" ErrorMessage="<br>La empresa es requerida."
                            Display="Dynamic" ValidationGroup="save" />
            </div>
            <label class="control-label col-sm-2" for="LastName">Area:</label>
            <div class="col-sm-4">
                <asp:dropdownlist runat="server" id="Area" width="165px" height="24px" />
                <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" controltovalidate="Area"
                    cssclass="field-validation-error" errormessage="<br>El area es requerida." display="Dynamic"
                    validationgroup="save" />
                <asp:label id="lbArea" runat="server" text="Se requiere adicionar Area..." visible="false"></asp:label>
                <asp:button id="btAddArea" runat="server" text="Agregar Area" visible="false" onclick="btAddArea_Click" />

                </contenttemplate>
            </asp:updatepanel>
            </div>
        </div>        
        <div class="form-group">
            <label class="control-label col-sm-2" for="TipeUser">Tipo Usuario</label>
            <div class="col-sm-10">
                <asp:dropdownlist runat="server" id="TipeUser" width="100px" />
            </div>
        </div>

        <div class="form-group">
            <label class="control-label col-sm-2" for="Genero">Genero</label>
            <div class="col-sm-10">
                <asp:dropdownlist runat="server" id="Genero">
                        <asp:ListItem Value="M" Text="Masculino" />
                        <asp:ListItem Value="F" Text="Femenino" />
                    </asp:dropdownlist>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="MainContent_FirdsDate">Fecha Nacimiento</label>
            <div class="col-sm-10">
                <asp:textbox id="MainContent_FirdsDate" class="form-control" placeholder="Ingrese Fecha Nacimiento (dd/mm/yyyy)" runat="server" maxlength="50" runat="server" required title="la fecha de nacimiento es requerida." ReadOnly="true" style=" cursor: pointer"/>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="ImageUrl">Imagen</label>
            <div class="col-sm-10">
                <asp:fileupload id="ImageUrl" runat="server"></asp:fileupload>
                <asp:linkbutton text="Subir" runat="server" id="UploadImage" onclick="UploadImage_Click"
                    causesvalidation="False" />
                <br />
                <asp:label runat="server" id="FailureTextImage" cssclass="field-validation-error"></asp:label>
                <br />
                <asp:image id="ImageUser" runat="server" width="100px" />
                <br />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="UserName">Nombre usuario</label>
            <div class="col-sm-10">
                <asp:updatepanel runat="server">
                    <contenttemplate>                    
                        <asp:TextBox runat="server" ID="UserName" MaxLength="10" OnTextChanged="UserName_TextChanged" AutoPostBack="true" class="form-control" placeholder="Ingrese nombre usuario" required title="el nombre de usuario es requerido" />
                        <asp:Label ID="lbUserUnique" runat="server" Font-Size="10pt" ForeColor="Red" Text="Usuario ya existe, pruebe con otro"
                            Visible="False"></asp:Label>                    
                    </contenttemplate>
                </asp:updatepanel>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="">Contraseña</label>
            <div class="col-sm-10">
                <asp:textbox runat="server" id="Password" textmode="Password" maxlength="20" />
                <asp:label runat="server" id="LenghPass" cssclass="field-validation-error" />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="">Confirme su Contraseña</label>
            <div class="col-sm-10">
                <asp:textbox runat="server" id="ConfirmPassword" textmode="Password" maxlength="20" />
                <asp:comparevalidator id="CompareValidator1" runat="server" controltocompare="Password"
                    controltovalidate="ConfirmPassword" cssclass="field-validation-error" display="Dynamic"
                    errormessage="<br>La contraseña y su confirmacion no son iguales." validationgroup="save" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-12 text-center">
                <asp:button runat="server" text="Registrarse" id="RegisterUser" onclick="RegisterUser_Click"
                    validationgroup="save" />
                <asp:linkbutton runat="server" id="Volver" text="Volver" onclick="Volver_Click"></asp:linkbutton>
                <asp:label runat="server" id="FailureText" cssclass="field-validation-error"></asp:label>
            </div>
        </div>
    </div>
</form>
