<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AdmCompanys.aspx.cs" Inherits="Votacion_WebSite.Administrator.AdmCompanys" %>

<link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />

<form runat="server">
    <asp:panel id="SelectCompany" runat="server">
        <div align="center">
            <asp:Button runat="server" ID="NewCompany" Text="Nueva +" OnClick="NewCompany_Click" />
            <asp:GridView ID="GridCompany"
                runat="server"
                AutoGenerateColumns="False"
                AllowPaging="True"                
                PageSize="6"
                CellPadding="4"
                PageIndex="0"
                HorizontalAlign="Center"
                OnRowEditing="GridCompany_RowEditing"
                OnRowDeleting="GridCompany_RowDeleting"
                OnRowCommand="GridCompany_RowCommand"
                UseAccessibleHeader="False" 
                OnPageIndexChanging="GridCompany_PageIndexChanging" class="table">
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
    </asp:panel>
    <asp:panel id="DataCompany" runat="server" visible="False">
        <h2>Registrar Empresa</h2>
        <div class="form-horizontal" role="form">
          <div class="form-group">
            <label class="control-label col-sm-2" for="NameCompany">Nombre:</label>
            <div class="col-sm-10">
              <%--<input type="text" class="form-control" id="NameCompany" placeholder="Ingrese Nombre"  maxlength="50" required title="El nombre de la empresa es requerido.">--%>
              <asp:TextBox ID="NameCompany" class="form-control" placeholder="Ingrese Nombre" runat="server" MaxLength="50" runat="server" required title="El nombre de la empresa es requerido."/>
            </div>
          </div>
          <div class="form-group">
            <label class="control-label col-sm-2" for="Nit">NIT:</label>
            <div class="col-sm-10"> 
              <%--<input type="text" class="form-control" ID="Nit" maxlength="12" placeholder="Ingrese NIT" runat="server" required title="El Nit de la empresa es requerido.">--%>
                <asp:TextBox ID="Nit" class="form-control" placeholder="Ingrese NIT" runat="server" MaxLength="12" runat="server" required title="El Nit de la empresa es requerido."/>
            </div>
          </div>
          <div class="form-group">
            <label class="control-label col-sm-2" for="Address">Dirección:</label>
            <div class="col-sm-10"> 
              <%--<input type="text" class="form-control" ID="Address" maxlength="50" placeholder="Ingrese Direccion" runat="server" required title="La Dirección de la empresa es requerida.">--%>
                <asp:TextBox ID="Address" class="form-control" placeholder="Ingrese Direccion" runat="server" MaxLength="50" runat="server" required title="La Dirección de la empresa es requerido."/>
            </div>
          </div>
          <div class="form-group">
            <label class="control-label col-sm-2" for="Telephone">Telefono:</label>
            <div class="col-sm-10"> 
              <%--<input type="text" class="form-control" ID="Telephone" maxlength="50" placeholder="Ingrese Telefono" runat="server" required title="El Telefono de la empresa es requerido.">--%>
                <asp:TextBox ID="Telephone" class="form-control" placeholder="Ingrese Telefono" runat="server" MaxLength="50" runat="server" required title="El Telefono de la empresa es requerido."/>
            </div>
          </div>
          <div class="form-group">
            <label class="control-label col-sm-2" for="Mail">Correo:</label>
            <div class="col-sm-10"> 
              <%--<input type="email" class="form-control" ID="Mail" maxlength="50" placeholder="Ingrese correo" runat="server" required title="El correo de usuario es requerido.">--%>
                <asp:TextBox ID="Mail" class="form-control" placeholder="Ingrese correo" runat="server" MaxLength="50" runat="server" required title="El correo de la empresa es requerido."/>
            </div>
          </div>
          <div class="form-group"> 
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Label runat="server" ID="FailureText" CssClass="field-validation-error"></asp:Label><br />
                <asp:Button runat="server" Text="Registrar" ID="RegisterCompany" OnClick="RegisterCompany_Click" />
                <asp:LinkButton runat="server" text="Volver" id="Volver" OnClick="Volver_Click"></asp:LinkButton>                
            </div>
          </div>
        </div>
    </asp:panel>
</form>
