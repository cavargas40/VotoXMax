<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MPVotacion.Master" AutoEventWireup="true" CodeBehind="AdmCompanys.aspx.cs" Inherits="Votacion_WebSite.Administrator.AdmCompanys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="SelectCompany" runat="server">
        <div align="center">
            <asp:Button runat="server" ID="NewCompany" Text="Nueva +" OnClick="NewCompany_Click" />
            <asp:GridView ID="GridCompany"
                runat="server"
                AutoGenerateColumns="False"
                AllowPaging="True"
                Width="600px"
                PageSize="4"
                CellPadding="4"
                PageIndex="0"
                HorizontalAlign="Center"
                OnRowEditing="GridCompany_RowEditing"
                OnRowDeleting="GridCompany_RowDeleting"
                OnRowCommand="GridCompany_RowCommand"
                UseAccessibleHeader="False" 
                OnPageIndexChanging="GridCompany_PageIndexChanging">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="AllName" runat="server" Text='<%# Eval("NombreEmpresa") %>' CommandName="Edit" CommandArgument='<%#Eval("IdEmpresa") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="Delete" runat="server" OnClientClick="return confirm('¿Va a eliminar la empresa?');"
                                CommandName="Delete" Text="X" CommandArgument='<%#Eval("IdEmpresa") %>' ForeColor="red" Font-Overline="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
    <asp:Panel ID="DataCompany" runat="server" Visible="False">
        <fieldset>
            <legend>Registration Form</legend>
            <ol>
                <li>
                    <asp:Label ID="Label1" AssociatedControlID="NameCompany" runat="server">Nombre</asp:Label>
                </li>
                <li>
                    <asp:TextBox ID="NameCompany" runat="server" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="NameCompany" CssClass="field-validation-error" 
                        ErrorMessage="&lt;br&gt;El nombre de la empresa es requerido." />
                </li>
                <li>
                    <asp:Label ID="Label2" AssociatedControlID="Nit" runat="server">NIT</asp:Label>
                </li>
                <li>
                    <asp:TextBox runat="server" ID="Nit" MaxLength="12" 
                        onkeypress="return !((event.keyCode &lt; 48) || (event.keyCode &gt; 57));" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Nit"
                        CssClass="field-validation-error" 
                        ErrorMessage="&lt;br&gt;El Nit de la empresa es requerido." />
                </li>
                <li>
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="Address">Dirección</asp:Label>
                </li>
                <li>
                    <asp:TextBox ID="Address" runat="server" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="Address" CssClass="field-validation-error" 
                        ErrorMessage="&lt;br&gt;La Dirección de la empresa es requerida." />
                </li>
                <li>
                    <asp:Label ID="Label4" runat="server" AssociatedControlID="Telephone">Telefono</asp:Label>
                </li>
                <li>
                    <asp:TextBox runat="server" ID="Telephone" MaxLength="10" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Telephone"
                        CssClass="field-validation-error" 
                        ErrorMessage="&lt;br&gt;El Telefono de la empresa es requerido." />
                </li>
                <li>
                    <asp:Label ID="Label5" runat="server" AssociatedControlID="Mail">Correo</asp:Label>
                </li>
                <li>
                    <asp:TextBox ID="Mail" runat="server" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="Mail" CssClass="field-validation-error" 
                        ErrorMessage="&lt;br&gt;El correo de usuario es requerido." />
                </li>
            </ol>
            <asp:Label runat="server" ID="FailureText" CssClass="field-validation-error"></asp:Label><br />
            <asp:Button runat="server" Text="Registrar" ID="RegisterCompany" OnClick="RegisterCompany_Click" />
            <asp:Button runat="server" ID="Volver" Text="Volver" OnClick="Volver_Click" CausesValidation="False" />
        </fieldset>
    </asp:Panel>
</asp:Content>
