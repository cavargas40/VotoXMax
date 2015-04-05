<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MPVotacion.Master" AutoEventWireup="true"
    CodeBehind="EditUser.aspx.cs" Inherits="Votacion_WebSite.Administrator.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hgroup class="title">
    </hgroup>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <%--    <script type="text/javascript">
        $(function () {
            $("#MainContent_FirdsDate").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: '1920:2000',
                dateFormat: 'dd/mm/yy',
                defaultDate: '01/01/1985'
            });
        });
    </script>--%>
    <script type="text/javascript">
        $(function () {
            $("#MainContent_FirdsDate").datepicker({
                changeMonth: true,
                changeYear: true,
                onSelect: function (dateText) {
                    var date = $('#datepicker').val();
                    document.getElementById("tbDate").value = date;
                }
            });
        });

    </script>
    <p class="message-info">
        La contraseña requiere minimo 6 digitos de tamaño.
    </p>
    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <fieldset>
        <legend>Usuarios</legend>
        <ol>
            <li>
                <asp:Label ID="Label1" AssociatedControlID="NamePerson" runat="server">Nombres</asp:Label>
            </li>
            <li>
                <asp:TextBox runat="server" ID="NamePerson" MaxLength="50" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NamePerson"
                    CssClass="field-validation-error" ErrorMessage="<br>Los Nombres son requeridos."
                    Display="Dynamic" ValidationGroup="save" />
            </li>
            <li>
                <asp:Label ID="Label2" runat="server" AssociatedControlID="LastName">Apellidos</asp:Label>
            </li>
            <li>
                <asp:TextBox runat="server" ID="LastName" MaxLength="50" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastName"
                    CssClass="field-validation-error" ErrorMessage="<br>Los Apellidos son requeridos."
                    Display="Dynamic" ValidationGroup="save" />
            </li>
            <li>
                <asp:Label ID="Label3" AssociatedControlID="Identificacion" runat="server">Identificación</asp:Label>
            </li>
            <asp:UpdatePanel runat="server">
                <contenttemplate>
                 <li>
                <%--onkeypress="return !((event.keyCode < 48) || (event.keyCode > 57));"--%>
                <asp:TextBox runat="server" ID="Identificacion" 
                    MaxLength="12" OnTextChanged="Identificacion_TextChanged" AutoPostBack="true" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Identificacion"
                    CssClass="field-validation-error" ErrorMessage="<br>La identificacion es requerida."
                    Display="Dynamic" ValidationGroup="save" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Identificacion"
                    ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$" Display="Dynamic"
                    ValidationGroup="check/*"></asp:RegularExpressionValidator>
                <asp:Label ID="lbDocumentoUnique" runat="server" Font-Size="10pt" ForeColor="Red"
                    Text="Documento ya existe, pruebe con otro" Visible="False"></asp:Label>
            </li>
                </contenttemplate>
            </asp:UpdatePanel>
            <li>
                <asp:Label ID="Label8" AssociatedControlID="TypeDocument" runat="server">Tipo de documento</asp:Label>
            </li>
            <li>
                <asp:DropDownList runat="server" ID="TypeDocument" Width="170px" Height="27px">
                    <asp:ListItem Text="Cedula de Ciudadania" Value="C.C.">
                    </asp:ListItem>
                    <asp:ListItem Text="Tarjeta de Identidad" Value="T.I.">
                    </asp:ListItem>
                    <asp:ListItem Text="Cedula de Extrangeria" Value="C.E."></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Identificacion"
                    CssClass="field-validation-error" ErrorMessage="<br>Los Nombres son requeridos."
                    Display="Dynamic" ValidationGroup="save" />
            </li>
            <li>
                <asp:Label ID="Label11" runat="server" AssociatedControlID="Company">Empresa</asp:Label>
            </li>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <contenttemplate>
                    <li>
                        <asp:DropDownList runat="server" ID="Company" AutoPostBack="True" OnSelectedIndexChanged="Company_SelectedIndexChanged"
                            Height="23px" Width="171px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Company"
                            CssClass="field-validation-error" ErrorMessage="<br>La empresa es requerida."
                            Display="Dynamic" ValidationGroup="save" />
                    </li>
                    <li>
                        <asp:Label ID="Label22" runat="server" AssociatedControlID="Area">Area</asp:Label>
                    </li>
                    <li>
                        <asp:DropDownList runat="server" ID="Area" Width="165px" Height="24px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Area"
                            CssClass="field-validation-error" ErrorMessage="<br>El area es requerida." Display="Dynamic"
                            ValidationGroup="save" />
                        <asp:Label ID="lbArea" runat="server" Text="Se requiere adicionar Area..." Visible="false"></asp:Label>
                        <asp:Button ID="btAddArea" runat="server" Text="Agregar Area" Visible="false" OnClick="btAddArea_Click" />
                    </li>
                </contenttemplate>
            </asp:UpdatePanel>
            <li>
                <asp:Label ID="Label33" runat="server" AssociatedControlID="TipeUser">Tipo Usuario</asp:Label>
            </li>
            <li>
                <asp:DropDownList runat="server" ID="TipeUser" Width="100px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TipeUser"
                    CssClass="field-validation-error" ErrorMessage="<br>El tipo de usuario es requerido."
                    Display="Dynamic" ValidationGroup="save" />
            </li>
            <li>
                <asp:Label ID="Label4" runat="server" AssociatedControlID="Genero">Genero</asp:Label>
                <li>
                    <asp:DropDownList runat="server" ID="Genero">
                        <asp:ListItem Value="M" Text="Masculino" />
                        <asp:ListItem Value="F" Text="Femenino" />
                    </asp:DropDownList>
                    <li>
                        <asp:Label ID="Label5" runat="server" AssociatedControlID="MainContent_FirdsDate">Fecha nacimiento</asp:Label>
                        <asp:TextBox runat="server" ID="MainContent_FirdsDate" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="MainContent_FirdsDate"
                            CssClass="field-validation-error" ErrorMessage="<br>La fecha de nacimiento es requerida."
                            Display="Dynamic" ValidationGroup="save" />
                    </li>
                    <li>
                        <asp:Label ID="Label6" AssociatedControlID="ImageUrl" runat="server">Imagen</asp:Label>
                        <asp:FileUpload ID="ImageUrl" runat="server"></asp:FileUpload>
                    </li>
                    <li>
                        <asp:LinkButton Text="Subir" runat="server" ID="UploadImage" OnClick="UploadImage_Click"
                            CausesValidation="False" />
                        <br />
                        <asp:Label runat="server" ID="FailureTextImage" CssClass="field-validation-error"></asp:Label>
                        <br />
                        <asp:Image ID="ImageUser" runat="server" Width="100px" />
                        <br />
                    </li>
                    <li>
                        <asp:Label ID="Label7" runat="server" AssociatedControlID="UserName">Nombre usuario</asp:Label>
                    </li>
                    <asp:UpdatePanel runat="server">
                        <contenttemplate>
                      <li>
                        <asp:TextBox runat="server" ID="UserName" MaxLength="10" OnTextChanged="UserName_TextChanged" AutoPostBack="true"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="UserName"
                            CssClass="field-validation-error" ErrorMessage="<br>El nombre de usuario es requerido."
                            Display="Dynamic" ValidationGroup="save" />
                        <asp:Label ID="lbUserUnique" runat="server" Font-Size="10pt" ForeColor="Red" Text="Usuario ya existe, pruebe con otro"
                            Visible="False"></asp:Label>
                    </li>
                     </contenttemplate>
                    </asp:UpdatePanel>
                    <li>
                        <asp:Label ID="LbPass" runat="server" AssociatedControlID="Password">Contraseña</asp:Label>
                    </li>
                    <li>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" MaxLength="20" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Password"
                            CssClass="field-validation-error" ErrorMessage="<br>La contraseña es requerida."
                            Display="Dynamic" ValidationGroup="save" /><br />
                        <asp:Label runat="server" ID="LenghPass" CssClass="field-validation-error" />
                    </li>
                    <li>
                        <asp:Label ID="LbPass2" runat="server" AssociatedControlID="ConfirmPassword">Confirme su contraseña</asp:Label>
                    </li>
                    <li>
                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" MaxLength="20" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ConfirmPassword"
                            CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<br>La contraseña es requerida."
                            ValidationGroup="save" />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password"
                            ControlToValidate="ConfirmPassword" CssClass="field-validation-error" Display="Dynamic"
                            ErrorMessage="<br>La contraseña y su confirmacion no son iguales." ValidationGroup="save" />
                    </li>
        </ol>
        <asp:Label runat="server" ID="FailureText" CssClass="field-validation-error"></asp:Label><br />
        <asp:Button runat="server" Text="Registrarse" ID="RegisterUser" OnClick="RegisterUser_Click"
            ValidationGroup="save" />
        <asp:Button runat="server" ID="Volver" Text="Volver" OnClick="Volver_Click" CausesValidation="False" />
    </fieldset>
</asp:Content>
