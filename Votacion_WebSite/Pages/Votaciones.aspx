<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Votaciones.aspx.cs" Inherits="Votacion_WebSite.Pages.Votaciones" %>

<html>
<head runat="server">
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script type="text/javascript" id="testjs">
        $(function () {
            $("#txtFechaInsIni, #txtFechaInsFin, #txtFechaIni, #txtFechaFin").datepicker({
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
    <style>
        input[readonly] {
           ;
        }
    </style>
</head>
<body>
    <form runat="server">
        <asp:ToolkitScriptManager ID="scriptManager" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true" ScriptMode="Release">
        </asp:ToolkitScriptManager>
        <div align="center">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="panCampos" runat="server">
                        <h2>Agregar Votación</h2>
                        <div class="form-horizontal" role="form">
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="txtCampania">Nombre de la Campaña</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtCampania" runat="server" class="form-control" placeholder="Ingrese nombre de la campaña" required title="Nombre de Votación requerida" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="">Fecha Inscripcion Inicial</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtFechaInsIni" runat="server" class="form-control" placeholder="Seleccione Fecha Inicial de la Campaña" required title="La fecha de inscripcion inicial es requerida." ReadOnly="true" style=" cursor: pointer" />
                                </div>
                                <label class="control-label col-sm-2" for="">Fecha Inscripcion Final</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtFechaInsFin" runat="server" class="form-control" placeholder="Seleccione Fecha Final de la Campaña" required title="La fecha de inscripcion inicial es requerida." ReadOnly="true" style=" cursor: pointer" />
                                </div>
                                <asp:Label ID="lblErrorFechaIns" runat="server" />
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="">Fecha Inicial</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtFechaIni" runat="server" class="form-control" placeholder="Seleccione Fecha de la Campaña" required title="La fecha de inicial es requerida." ReadOnly="true" style=" cursor: pointer" />
                                </div>
                                <label class="control-label col-sm-2" for="">Fecha Final</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtFechaFin" runat="server" class="form-control" placeholder="Seleccione Fecha de la Campaña" required title="La fecha de inicial es requerida." ReadOnly="true" style=" cursor: pointer" />
                                </div>
                                <asp:Label ID="lblErrorFecha" runat="server" />
                            </div>
                            <div class="form-group">
                                <span>Grupo areas de trabajo de la empresa que permiten acceder a la votación</span>
                                
                                <asp:CheckBoxList ID="cblstAreas" RepeatColumns="3" runat="server">
                                </asp:CheckBoxList>
                                
                                <asp:Label ID="lblErrorChekList" runat="server" /></td>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12 text-center">
                                        <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btns" runat="server" OnClick="btnGuardar_Click" ValidationGroup="A" />
                                        <asp:Button ID="btnGuardarSalir" Text="Guardar y Salir" CssClass="btns" runat="server" OnClick="btnGuardar_Click" ValidationGroup="A" />
                                        <asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btns" runat="server" Visible="false" OnClick="btnActualizar_Click" ValidationGroup="A" />
                                        <asp:Button ID="btnActaulizarSalir" Text="Actualizar y Salir" CssClass="btns" runat="server" Visible="false" OnClick="btnActualizar_Click" ValidationGroup="A" />
                                        <asp:Button ID="btnNuevo" Text="Registrar Nueva Votación" CssClass="btns" Visible="false" runat="server" OnClick="btnNuevo_Click" />
                                        <asp:Button ID="btnEliminar" Text="Eliminar" CssClass="btns" runat="server" Visible="false" OnClick="btnEliminar_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panGrid" GroupingText="Lista de votaciones" runat="server">
                        <asp:GridView ID="gdvVotaciones" DataKeyNames="ID_SESION" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvVotaciones_SelectedIndexChanged" class="table">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="Modificar" />
                                <asp:BoundField DataField="NOMBRE_SESION" HeaderText="Nombre Campaña" />
                                <asp:BoundField DataField="FECHA_INICIO" HeaderText="Fecha Inicio" />
                                <asp:BoundField DataField="FECHA_FIN" HeaderText="Fecha Fin" />
                                <asp:BoundField DataField="FECHA_INI_INSCRIPCION" HeaderText="Fecha Inicio Inscripción" />
                                <asp:BoundField DataField="FECHA_FIN_INSCRIPCION" HeaderText="Fecha Fin Inscripción" />
                                <asp:BoundField DataField="USUARIO_CANDIDATO" HeaderText="Ganador Parcial" />
                                <asp:BoundField DataField="NUMERO_VOTOS" HeaderText="Número de Votos" />
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>


