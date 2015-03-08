<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Resultado.aspx.cs" Inherits="Votacion_WebSite.Reports.Resultado" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Votación Electrónica</title>
        <meta name="keywords" content="Votación Electronica, PoliSoft" />
        <meta name="description" content="Votación Electronica" />
        <link href="../CSS/MasterStyle.css" type="text/css" rel="stylesheet" />
        <link rel="stylesheet" href="../CSS/slimbox2.css" type="text/css" media="screen" />
        <script type="text/javascript" src="../JS/JScriptVHD.js"> </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div style="margin-left: 80%">
                <asp:Label ID="lbUser" runat="server" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbExit" runat="server" OnClick="lbExit_Click" 
                                Visible="false" ForeColor="Blue">Salir</asp:LinkButton>
            </div>
            <div id="templatemo_header_wrapper">
                <div id="templatemo_header">
                    <div id="site_title">
                        <a href="#">
                            <asp:Image ID="Image1" ImageUrl="~/IMG/ImgMaster/UrnaVirtual.png" Height="200px" Width="200px"
                                       runat="server" /></a></div>
                    <p id="intro_text">
                        El sistema de voto electrónico, tiene como objetivo facilitar al elector el ejercicio del voto, eliminando las barreras iniciales que puedan tener algunos votantes ante las nuevas tecnologías.</p>
                    <a class="intro_bg_by" href="http://es.hdstockphoto.com" title="fotos from es.hdstockphoto.com"
                       target="_blank"></a>
                </div>
            </div>
            <div id="templatemo_main_wrapper">
                <div id="templatemo_main">
                    <div align="center">
                        <table>
                            <tr>
                                <td>Sesión:</td>
                                <td><asp:DropDownList runat="server" ID="SessionDropDownList" Width="120px" CssClass="txts"/></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button runat="server" ID="ConsultarButton" Text="Consultar" CssClass="btns"
                                                onclick="ConsultarButtonClick"/>
                                </td>
                            </tr>
                        </table>
                        <rsweb:ReportViewer ID="ResultadoReportViewer" runat="server" Width="95%" Height="350px"/>
                    </div>
                </div>
            </div>
            <div id="templatemo_footer_wrapper">
                <div id="templatemo_footer">
                    <p>
                        Copyright © 2048 PoliSoft | Designed by <a href="http://www.templatemo.com" rel="nofollow"
                                                                   target="_parent">Free CSS Templates</a></p>
                </div>
            </div>
        </form>
    </body>
</html>