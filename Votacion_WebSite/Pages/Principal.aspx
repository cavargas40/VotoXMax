<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MPVotacion.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Votacion_WebSite.Pages.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>¿Qué Deseas Hacer?</h1>
    <div runat="server" id="dvSuperAdmin" visible="false">
        Super Admin<br />
        <asp:ImageButton ID="btSuperAdmin" runat="server" ImageUrl="~/IMG/ImgMaster/Empresa.png" Width="200px" Height="200px" OnClick="btSuperAdmin_Click" />
        <asp:ImageButton ID="btUsers" runat="server" ImageUrl="~/IMG/ImgMaster/Usuario.png" Width="200px" Height="200px" OnClick="btUsers_Click" />
        <asp:ImageButton ID="btAreasSuperAdmin" runat="server" ImageUrl="~/IMG/ImgMaster/Areas.png" Width="200px" Height="200px" OnClick="btArea_Click" />
    </div>
    <div runat="server" id="dvCompanies" visible="false">
        Admin<br />
        <asp:ImageButton ID="btAdminUsersCompany" runat="server" ImageUrl="~/IMG/ImgMaster/Usuario.png" Width="200px" Height="200px" OnClick="btAdminUsersCompany_Click" />
        <asp:ImageButton ID="btVote" runat="server" ImageUrl="~/IMG/ImgMaster/Votaciones.png" Width="200px" Height="200px" OnClick="btVote_Click" />
        <asp:ImageButton ID="btAreas" runat="server" ImageUrl="~/IMG/ImgMaster/Areas.png" Width="200px" Height="200px" OnClick="btArea_Click" />
        <asp:ImageButton ID="btnCand" runat="server" 
            ImageUrl="~/IMG/ImgMaster/Candidatos.png" Width="200px" Height="200px" 
            onclick="btnCand_Click" />
            <asp:ImageButton runat="server" ImageUrl="~/IMG/ImgMaster/grafica.png" 
            Width="200px" Height="200px" ID="BtnReporte" onclick="BtnReporte_Click"/>
            <asp:ImageButton runat="server" ImageUrl="~/IMG/ImgMaster/pie_chart.png" 
            Width="200px" Height="200px" ID="ResultadoButton" 
            onclick="ResultadoButton_Click"/>
    </div>
   <div runat="server" id="dvUsers" visible="false">
        User<br />
        <%--<div id="divRigth" style="position: relative; width: 50%; top: 0; right: 0; float: right;">--%>
            <asp:ImageButton ID="imgBtnInscribir" ImageUrl="~/IMG/ImgMaster/Boton-Psotulacion.png" Width="200px" Height="200px" runat="server" onclick="imgBtnInscribir_Click" />
        <%--</div>--%>
        <%--<div id="divLeft" style="position: relative; width: 50%; top: 0; left: 0; float: left;">--%>
            <asp:ImageButton ID="imgBtnVotar" ImageUrl="~/IMG/ImgMaster/Boton-Votar.png" Width="200px" Height="200px" runat="server" onclick="imgBtnVotar_Click" />
        <%--</div>--%>
    </div>
</asp:Content>
