<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MPVotacion.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="Votacion_WebSite.Account.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hgroup class="title">
        <h1>
            <%: Title %>.</h1>
    </hgroup>
    <script type="text/javascript">
        $(function () {
            $("#MainContent_FirdsDate").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: '1920:2000',
                dateFormat: 'dd/mm/yy',
                defaultDate: '01/01/1985'
            });
        });
    </script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
    <p class="message-info">
        La contraseña requiere minimo 6 digitos de tamaño.
    </p>
    <p class="validation-summary-errors">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <fieldset>
        <legend>Registration Form</legend>
        <ol>
            <li>
                <asp:Label ID="Label1" AssociatedControlID="NamePerson" runat="server">Nombres</asp:Label>
                <asp:TextBox runat="server" ID="NamePerson" MaxLength="50" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NamePerson"
                    CssClass="field-validation-error" ErrorMessage="<br>Los Nombres son requeridos." />
            </li>
            <li>
                <asp:Label ID="Label2" runat="server" AssociatedControlID="LastName">Apellidos</asp:Label>
                <asp:TextBox runat="server" ID="LastName" MaxLength="50" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastName"
                    CssClass="field-validation-error" ErrorMessage="<br>Los Apellidos son requeridos." />
            </li>
            <li>
                <asp:Label ID="Label3" AssociatedControlID="Identificacion" runat="server">Identificación</asp:Label>
                <asp:TextBox runat="server" ID="Identificacion" onkeypress="return !((event.keyCode < 48) || (event.keyCode > 57));"
                    MaxLength="12" />
                <asp:DropDownList runat="server" ID="TypeDocument" Width="100px">
                    <asp:ListItem Value="C.C." Text="Cedula" />
                    <asp:ListItem Value="T.I." Text="Targeta Estrangeria" />
                </asp:DropDownList>
            </li>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Identificacion"
                CssClass="field-validation-error" ErrorMessage="<br>Los Nombres son requeridos." />
            </li>
            <li>
                <asp:Label ID="Label4" runat="server" AssociatedControlID="Company">Empresa</asp:Label>
                <asp:DropDownList runat="server" ID="Company" AutoPostBack="True" OnSelectedIndexChanged="Company_SelectedIndexChanged" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Company"
                    CssClass="field-validation-error" ErrorMessage="<br>La empresa es requerida." />
            </li>
            <li>
                <asp:Label ID="Label5" runat="server" AssociatedControlID="Area">Area</asp:Label>
                <asp:DropDownList runat="server" ID="Area" Width="100px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Area"
                    CssClass="field-validation-error" ErrorMessage="<br>El area es requerida." />
            </li>
            <li>
                <asp:Label ID="Label6" runat="server" AssociatedControlID="Genero">Genero</asp:Label>
                <asp:DropDownList runat="server" ID="Genero">
                    <asp:ListItem Value="M" Text="Masculino" />
                    <asp:ListItem Value="F" Text="Femenino" />
                </asp:DropDownList>
            </li>
            <li>
                <asp:Label ID="Label7" runat="server" AssociatedControlID="FirdsDate">Fecha nacimiento</asp:Label>
                <asp:TextBox runat="server" ID="FirdsDate" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="FirdsDate"
                    CssClass="field-validation-error" ErrorMessage="<br>La fecha de nacimiento es requerida." />
            </li>
            <li>
                <asp:Label ID="Label8" AssociatedControlID="ImageUrl" runat="server">Imagen</asp:Label>
                <asp:FileUpload ID="ImageUrl" runat="server"></asp:FileUpload>
                <asp:LinkButton Text="Subir" runat="server" ID="UploadImage" OnClick="UploadImage_Click"
                    CausesValidation="False" />
                <br />
                <asp:Label runat="server" ID="FailureTextImage" CssClass="field-validation-error"></asp:Label>
                <br />
                <asp:Image ID="ImageUser" runat="server" Width="100px" />
                <br />
            </li>
            <li>
                <asp:Label ID="Label9" runat="server" AssociatedControlID="UserName">Nombre usuario</asp:Label>
                <asp:TextBox runat="server" ID="UserName" MaxLength="10" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="UserName"
                    CssClass="field-validation-error" ErrorMessage="<br>El nombre de usuario es requerido." />
            </li>
            <li>
                <asp:Label ID="Label10" runat="server" AssociatedControlID="Password">Contraseña</asp:Label>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" MaxLength="20" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Password"
                    CssClass="field-validation-error" ErrorMessage="<br>La contraseña es requerida." /><br />
                <asp:Label runat="server" ID="LenghPass" CssClass="field-validation-error" />
            </li>
            <li>
                <asp:Label ID="Label11" runat="server" AssociatedControlID="ConfirmPassword">Confirme su contraseña</asp:Label>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" MaxLength="20" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<br>La contraseña es requerida." />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password"
                    ControlToValidate="ConfirmPassword" CssClass="field-validation-error" Display="Dynamic"
                    ErrorMessage="<br>La contraseña y su confirmacion no son iguales." />
            </li>
        </ol>
        <asp:Label runat="server" ID="FailureText" CssClass="field-validation-error"></asp:Label><br />
        <asp:Button runat="server" Text="Registrarse" ID="RegisterUser" OnClick="RegisterUser_Click" />
        <asp:Button runat="server" Text="Eliminar" ID="DeleteUser" OnClick="DeleteUser_Click"
            Visible="False" CausesValidation="False" />
    </fieldset>
</asp:Content>
