<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/VotoXMax.Master" AutoEventWireup="true" CodeBehind="RegistrarEmpresas.aspx.cs" Inherits="Votacion_WebSite.RegistrarEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" id="testjs">
        $(function () {
            $("#txtFechaNacimientoAdmin").datepicker({
                changeMonth: true,
                changeYear: true,
                //onSelect: function (dateText) {
                //    var date = $('#datepicker').val();
                //    document.getElementById("tbDate").value = date;
                //},
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <div>
        <h1>Registrar Empresa</h1>
    </div>
    <div>
        <table>
            <tr>
                <td colspan="2"> <h3><b> <asp:Label Text="Datos de la empresa" runat="server" ForeColor="White"/></b></h3></td>
            </tr>
            <tr>
                <td><asp:Label Text="Nombre Empresa" runat="server" ForeColor="White" /></td>
                <td><asp:TextBox ID="txtNombreEmpresa" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label Text="Nit Empresa" runat="server" ForeColor="White" /></td>
                <td><asp:TextBox ID="txtNitEmpresa" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label Text="Dirección Empresa" runat="server" ForeColor="White" /></td>
                <td><asp:TextBox ID="txtDireccionEmpresa" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label Text="Teléfono Empresa" runat="server" ForeColor="White" /></td>
                <td><asp:TextBox ID="txtTelefonoEmpresa" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label Text="Email Empresa" runat="server" ForeColor="White" /></td>
                <td><asp:TextBox ID="txtMailEmpresa" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2"><h3><b><asp:Label Text="Datos de la persona encargado (Administrador)" runat="server" ForeColor="White" /></b></h3></td>
            </tr>
            <tr>
                <td><asp:Label Text="Nombre Encargado" runat="server" ForeColor="White" /></td>
                <td><asp:TextBox ID="txtNombreAdm" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label Text="Apellido Encargado" runat="server" ForeColor="White" /></td>
                <td><asp:TextBox ID="txtApellidoAdm" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label Text="Tipo Documento Encargado" runat="server" ForeColor="White" /></td>
                <td><asp:TextBox ID="txtTipoDocAdm" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label Text="Numero Documento Encargado" runat="server" ForeColor="White" /></td>
                <td><asp:TextBox ID="txtNumDocAdm" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label Text="Fecha Nacimiento Encargado" runat="server" ForeColor="White" /></td>
                <td><asp:TextBox ID="txtFechaNacimientoAdmin" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label Text="Genero del Encargado" runat="server" ForeColor="White" /></td>
                <td><asp:dropdownlist runat="server" id="ddlGeneroAdm">
                        <asp:ListItem Value="M" Text="Masculino" />
                        <asp:ListItem Value="F" Text="Femenino" />
                    </asp:dropdownlist></td>
            </tr>
            <tr>
                <td><asp:Label Text="Nombre Usuario" runat="server" ForeColor="White" /></td>
                <td><asp:TextBox ID="txtNickUser" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label Text="Contraseña" runat="server" ForeColor="White" /></td>
                <td><asp:TextBox ID="txtPass" TextMode="Password" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnRegistrarEmpresa" Text="Registrarme" runat="server" OnClick="btnRegistrarEmpresa_Click" /></td>
            </tr>
        </table>
    </div>

</asp:Content>
