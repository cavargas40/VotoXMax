<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MPVotacion.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Votacion_WebSite.Account.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <section id="passwordForm">

        <p>Usted esta logueado con el usuario: <strong><%:((VoUser)this.Session["ObjectUser"]).NombreUsuario %></strong>.</p>

        <fieldset>
            <legend>Cambio de contraseña</legend>
            <ol>
                <li>
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="OldPassword">Contraseña Actual</asp:Label>
                    <asp:TextBox runat="server" ID="OldPassword" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="OldPassword"
                        CssClass="field-validation-error" ErrorMessage="<br>La contraseña es requerida."
                        Display="Dynamic" ValidationGroup="SetPassword" />
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="password" CssClass="field-validation-error" SetFocusOnError="true" />
                </li>
                <li>
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="password">Nueva Contraseña</asp:Label>
                    <asp:TextBox runat="server" ID="password" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password"
                        CssClass="field-validation-error" ErrorMessage="<br>La contraseña es requerida."
                        Display="Dynamic" ValidationGroup="SetPassword" />
                    <asp:Label runat="server" ID="TextFailure" AssociatedControlID="password" CssClass="field-validation-error" SetFocusOnError="true" />
                </li>
                <li>
                    <asp:Label ID="Label4" runat="server" AssociatedControlID="confirmPassword">Confirmar Nueva Contraseña</asp:Label>
                    <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="confirmPassword"
                        CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<br>La confirmacion de la contraseña es requerida."
                        ValidationGroup="SetPassword" />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                        CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<br>Las contraseñas no son iguales."
                        ValidationGroup="SetPassword" />
                </li>
            </ol>
            <asp:Button ID="Button1" runat="server" Text="Cambiar" ValidationGroup="SetPassword" OnClick="setPassword_Click" />
        </fieldset>

    </section>
</asp:Content>
