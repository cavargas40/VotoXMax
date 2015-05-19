<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Votar.aspx.cs" Inherits="Votacion_WebSite.Pages.Votar" %>

<link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<form runat="server">
    <asp:toolkitscriptmanager id="scriptManager" runat="server" enablescriptglobalization="true"
        enablescriptlocalization="true" enablepartialrendering="true" scriptmode="Release">
            </asp:toolkitscriptmanager>
    <asp:updatepanel id="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
            <div class="text-center">
                <h2>Bienvenido a la Urna Virtual</h2>
                <label class="control-label">Seleccione un evento de votación, para cargar la lista de candidatos asociados y votar</label>
            </div>            
            <div class="text-center">
                <asp:DropDownList ID="ddlsessionaVotar" CssClass="txts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlsessionaVotar_SelectedIndexChanged" />
            </div>
            <div class="text-center">
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:ListView ID="lstvCandidatos" runat="server" DataKeyNames="IdUsuario" OnSelectedIndexChanged="lstvCandidatos_SelectedIndexChanged"
                                OnSelectedIndexChanging="lstvCandidatos_SelectedIndexChanging" OnDataBound="lstvCandidatos_DataBound"
                                GroupItemCount="2" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1"
                                OnPagePropertiesChanged="lstvCandidatos_PagePropertiesChanged">
                                <LayoutTemplate>
                                    <table>
                                        <asp:PlaceHolder ID="groupPlaceHolder1" runat="server"></asp:PlaceHolder>
                                    </table>
                                    <asp:DataPager runat="server" ID="PeopleDataPager" PageSize="6">
                                        <Fields>
                                            <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true"
                                                FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|" NextPageText=" &gt; " PreviousPageText=" &lt; " />
                                        </Fields>
                                    </asp:DataPager>
                                </LayoutTemplate>
                                <GroupTemplate>
                                    <tr>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                    </tr>
                                </GroupTemplate>
                                <ItemTemplate>
                                    <td>
                                        <table width="370">
                                            <tr>
                                                <td rowspan="6">
                                                    <asp:ImageButton ID="imgBtnCandidato" ImageUrl='<%# Eval("PathImagen")%>' CommandName="Select"
                                                        Height="140px" Width="140px" ToolTip="Click para votar" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 100%">
                                                    <h4>
                                                        <%# Eval("Numero")%></h4>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%# Eval("Nombres")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%# Eval("Apellidos")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%# Eval("Genero")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <%# Eval("FechaNacimiento")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </ItemTemplate>
                                <SelectedItemTemplate>
                                    <td>
                                        <table width="380" style="background-color: rgba(255, 255, 255, 0.25); border-style: double;
                                            border-width: 3px; border-color: #404113">
                                            <tr>
                                                <td rowspan="6">
                                                    <asp:Image ID="imgCandidato" ImageUrl='<%# Eval("PathImagen")%>' Height="150px" Width="150px"
                                                        runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="background: rgba(255, 255, 255, 0.25); width: 100%">
                                                    <h4>
                                                        <%# Eval("Numero")%></h4>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: rgba(255, 255, 255, 0.25)">
                                                    <%# Eval("Nombres")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: rgba(255, 255, 255, 0.25)">
                                                    <%# Eval("Apellidos")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: rgba(255, 255, 255, 0.25)">
                                                    <%# Eval("Genero")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: rgba(255, 255, 255, 0.25)">
                                                    <%# Eval("FechaNacimiento")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </SelectedItemTemplate>
                            </asp:ListView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <%--<cc1:CaptchaControl ID="Captcha1" runat="server" 
                            CaptchaBackgroundNoise="Low" CaptchaLength="5" 
                            CaptchaHeight="60" CaptchaWidth="200" 
                            CaptchaLineNoise="None" CaptchaMinTimeout="5" 
                            CaptchaMaxTimeout="240" CssClass="txts" Visible="false" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                          <%--  <asp:TextBox ID="txtCaptcha" Visible="false" CssClass="txts" runat="server" />
                            <asp:RequiredFieldValidator ID="rfvtxtCaptcha" runat="server" ValidationGroup="A" ControlToValidate="txtCaptcha" ErrorMessage="Captcha Requerida" SetFocusOnError="True"/>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnVotar" Text="Votar" CssClass="btns" Visible="false" runat="server" ValidationGroup="A" OnClick="btnVotar_Click" />
                        </td>
                        <td align="center">
                            <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btns" Visible="false" runat="server" ValidationGroup="A" OnClick="btnCancelar_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:updatepanel>
</form>
