<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MPVotacion.Master" AutoEventWireup="true"
    CodeBehind="AdmUser.aspx.cs" Inherits="Votacion_WebSite.Administrator.AdmUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Button runat="server" ID="NewUser" Text="Nuevo +" OnClick="NewUser_Click" />
        <asp:GridView ID="GridUser" runat="server" AutoGenerateColumns="False" Width="600px"
            OnRowCommand="GridUser_RowCommand" OnRowDeleting="GridUser_RowDeleting" OnRowEditing="GridUser_RowEditing"
            PageSize="4" PageIndex="0" OnPageIndexChanging="GridUser_PageIndexChanging" AllowPaging="True">
            <Columns>
                <asp:TemplateField ShowHeader="False" ConvertEmptyStringToNull="False" HeaderStyle-Width="200px"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Image ID="ImageUser" runat="server" ImageAlign="Left" Width="100px" Height="120px"
                            ImageUrl='<%#Eval("Imagen") %>' />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="AllName" runat="server" Text='<%# Eval("Nombres") + " " + Eval("Apellidos") %>'
                            CausesValidation="False" CommandName="Edit" CommandArgument='<%#Eval("IdUser") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="Delete" runat="server" OnClientClick="return confirm('¿Va a eliminar el usuario?');"
                            CausesValidation="False" CommandName="Delete" Text="X" CommandArgument='<%#Eval("IdUser") %>'
                            ForeColor="red" Font-Overline="False" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BorderStyle="Dashed" />
        </asp:GridView>
    </div>
</asp:Content>
