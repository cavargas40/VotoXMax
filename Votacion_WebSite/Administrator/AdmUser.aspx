<%@ Page Title="" Language="C#" MasterPageFile="" AutoEventWireup="true" CodeBehind="AdmUser.aspx.cs" Inherits="Votacion_WebSite.Administrator.AdmUser" %>

<link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

<script type="text/javascript">
    var message = false;
    function ShowDiv(obj) {
        message = true;
    }

    $(function () {
        $("#alert").hide();


        $(window).load(function () {
            if (message) {
                $("#alert").show();
            }

        });

    });

</script>
<form runat="server">    
     <div class="alert alert-success"" role="alert" id="alert">
        <strong>Procesado!</strong> El usuario fue agregado con exito
    </div>
    <div align="center">
        <asp:button runat="server" id="NewUser" text="Nuevo +" onclick="NewUser_Click" />
        <asp:gridview id="GridUser" runat="server" autogeneratecolumns="False"
            onrowcommand="GridUser_RowCommand" onrowdeleting="GridUser_RowDeleting" onrowediting="GridUser_RowEditing"
            pagesize="4" pageindex="0" onpageindexchanging="GridUser_PageIndexChanging" allowpaging="True" class="table">
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
        </asp:gridview>
    </div>
</form>
