<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MPVotacion.Master" AutoEventWireup="true" CodeBehind="Votaciones.aspx.cs" Inherits="Votacion_WebSite.Pages.Votaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="panCampos" GroupingText="Agregando Votación..." runat="server">
                    <table width="100%">
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Label ID="lblCampania" Text="Nombre de la Campaña:" runat="server" />
                            </td>
                            <td colspan="2" align="left">
                                <asp:TextBox ID="txtCampania" CssClass="txts" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvtxtCampania" ControlToValidate="txtCampania" runat="server" ErrorMessage="Nombre de Votación requerida" ValidationGroup="A"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFechaIni" Text="Fecha Inicial:" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaIni" CssClass="txts" runat="server" onkeydown="return false;"/>
                                <asp:RequiredFieldValidator ID="rfvtxtFechaIni" ControlToValidate="txtFechaIni" runat="server" ErrorMessage="Fecha Inicio Requerida" ValidationGroup="A"/>
                                <asp:CalendarExtender ID="cetxtFechaIni" TargetControlID="txtFechaIni" Format="dd/MM/yyyy" runat="server"/>
                            </td>
                            <td>
                                <asp:Label ID="lblFechaFin" Text="Fecha Final:" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaFin" CssClass="txts" runat="server" onkeydown="return false;"/>
                                <asp:RequiredFieldValidator ID="rfvtxtFechaFin" ControlToValidate="txtFechaFin" Format="dd/MM/yyyy" runat="server" ErrorMessage="Fecha fin Requerida" ValidationGroup="A"/>
                                <asp:CalendarExtender ID="cetxtFechaFin" TargetControlID="txtFechaFin" Format="dd/MM/yyyy" runat="server"/>
                            </td>
                            <tr>
                                <td colspan="4"><asp:Label ID="lblErrorFecha" runat="server" /></td>
                            </tr>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFechaInsIni" Text="Fecha Inscripción Inicial:" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaInsIni" CssClass="txts" runat="server" onkeydown="return false;"/>
                                <asp:RequiredFieldValidator ID="rfvtxtFechaInsIni" ControlToValidate="txtFechaInsIni" Format="dd/MM/yyyy" runat="server" ErrorMessage="Fecha Inicio de inscripcion Requerida" ValidationGroup="A"/>
                                <asp:CalendarExtender ID="cetxtFechaInsIni" TargetControlID="txtFechaInsIni" Format="dd/MM/yyyy" runat="server"/>
                            </td>
                            <td>
                                <asp:Label ID="lblFechaInsFin" Text="Fecha Inscripción Final:" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaInsFin" CssClass="txts" runat="server" onkeydown="return false;"/>
                                <asp:RequiredFieldValidator ID="rfvtxtFechaInsFin" ControlToValidate="txtFechaInsFin" Format="dd/MM/yyyy" runat="server" ErrorMessage="Fecha Inicio de inscripción Requerida" ValidationGroup="A"/>
                                <asp:CalendarExtender ID="cetxtFechaInsFin" TargetControlID="txtFechaInsFin" Format="dd/MM/yyyy" runat="server"/>
                            </td>
                            <tr>
                            <td colspan="4"><asp:Label ID="lblErrorFechaIns" runat="server" /></td>
                            </tr>
                        </tr>
                        <tr>
                            <td colspan="4"><asp:Label ID="lblAreas" Text="Grupo areas de trabajo de la empresa que permiten acceder a la votación" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:CheckBoxList ID="cblstAreas" RepeatColumns="3" Width="100%" runat="server">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                            <tr>
                            <td colspan="4"><asp:Label ID="lblErrorChekList" runat="server" /></td>
                            </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btns" runat="server" onclick="btnGuardar_Click" ValidationGroup="A" />
                                <asp:Button ID="btnGuardarSalir" Text="Guardar y Salir" CssClass="btns" runat="server" onclick="btnGuardar_Click" ValidationGroup="A" />
                                <asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btns" runat="server" Visible="false" onclick="btnActualizar_Click" ValidationGroup="A" />
                                <asp:Button ID="btnActaulizarSalir" Text="Actualizar y Salir" CssClass="btns" runat="server" Visible="false" onclick="btnActualizar_Click" ValidationGroup="A" />
                                <asp:Button ID="btnNuevo" Text="Registrar Nueva Votación" CssClass="btns" Visible="false" runat="server" onclick="btnNuevo_Click" />
                                <asp:Button ID="btnEliminar" Text="Eliminar" CssClass="btns" runat="server" Visible="false" onclick="btnEliminar_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="panGrid" GroupingText="Lista de votaciones..." runat="server">
                    <asp:GridView ID="gdvVotaciones" DataKeyNames="ID_SESION" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" onselectedindexchanged="gdvVotaciones_SelectedIndexChanged" >
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Modificar" />
                            <asp:BoundField DataField="NOMBRE_SESION" HeaderText="Nombre Campaña" />
                            <asp:BoundField DataField="FECHA_INICIO" HeaderText="Fecha Inicio" />
                            <asp:BoundField DataField="FECHA_FIN" HeaderText="Fecha Fin" />
                            <asp:BoundField DataField="FECHA_INI_INSCRIPCION" HeaderText="Fecha Inicio Inscripción" />
                            <asp:BoundField DataField="FECHA_FIN_INSCRIPCION" HeaderText="Fecha Fin Inscripción" />
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
</asp:Content>
