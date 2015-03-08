<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MPVotacion.Master" AutoEventWireup="true" CodeBehind="InscribirUsuario.aspx.cs" Inherits="Votacion_WebSite.Pages.InscribirUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div align="center">
        <table style="text-align:left;">
            <tr>
                <td>
                    <asp:Label runat="server" ID="LblUsuario" Text="Seleccionar Usuario:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlUsuario" Width="250px" 
                        AutoPostBack="True" onselectedindexchanged="ddlUsuario_SelectedIndexChanged"/>
                </td>
                <td><asp:CompareValidator ID="cvddlUsuario" runat="server" ControlToValidate="ddlUsuario" ErrorMessage="Debe seleccionar un Usuario" Operator="NotEqual" ValidationGroup="A" ValueToCompare="--SELECCIONE--" SetFocusOnError="True"/></td>
            </tr>
            <tr>
                <td colspan="3" align="center"><asp:Image ID="imgCandidato" runat="server" Height="140px" Width="140px"/></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblPathImage" Text="Seleccionar Imagen:" runat="server" /></td>
                <td style="text-align:left;"><asp:FileUpload id="fuImagen" runat="server"/>
                    <asp:Button ID="btnCargar" Text="Cargar" CssClass="btns" runat="server" onclick="btnCargar_Click" /></td>
                    <td><asp:Label ID="lblMsgImgReq" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblNumCand" Text="Número Candidato:" runat="server" /></td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtNumCand" runat="server" CssClass="txts" Width="160px" />
                            <asp:LinkButton Text="Aleatorio" runat="server" ID="linkBtnRandomNumber" onclick="linkBtnRandomNumber_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td><asp:RequiredFieldValidator ID="rfvtxtNumCand" runat="server" ValidationGroup="A" ControlToValidate="txtNumCand" ErrorMessage="Número Candidato Requerido" SetFocusOnError="True"/></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblSesion" Text="Evento a donde se quiere Postular:" runat="server" /></td>
                <td><asp:DropDownList ID="ddlSesion" runat="server" Width="320px" CssClass="txts" /></td>
                <td><asp:CompareValidator ID="cvddlSesion" runat="server" ControlToValidate="ddlSesion" ErrorMessage="Evento de votación Requerido" Operator="NotEqual" ValidationGroup="A" ValueToCompare="--SELECCIONE--" SetFocusOnError="True"/></td>
            </tr>
            <tr>
                <td colspan="3" align="center"><asp:Button ID="btnPostular" Text="Postular" ValidationGroup="A" CssClass="btns" runat="server" onclick="btnPostular_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
