<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Postular.aspx.cs" Inherits="Votacion_WebSite.Pages.Postular" %>


<link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />

<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script type="text/javascript" id="testjs">
       
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
    <asp:toolkitscriptmanager id="scriptManager" runat="server" enablescriptglobalization="true"
        enablescriptlocalization="true" enablepartialrendering="true" scriptmode="Release">
            </asp:toolkitscriptmanager>
     <div class="alert alert-success"" role="alert" id="alert">
          <strong>Procesado!</strong> El usuario fue postulado con exito
        </div>
    <div class="form-horizontal" role="form">
        <div class="form-group">
            <div class="text-center">
                <asp:image id="imgCandidato" runat="server" height="140px" width="140px" />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-6" for="fuImagen">Seleccionar Imagen</label>
            <div class="col-sm-6">
                <asp:fileupload id="fuImagen" runat="server" />
                <asp:button id="btnCargar" text="Cargar" runat="server" onclick="btnCargar_Click" />
                <asp:label id="lblMsgImgReq" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-6" for="txtNumCand">Número de Candidato</label>
            <div class="col-sm-6">
                <asp:updatepanel id="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtNumCand" runat="server" class="form-control"  Width="160px" required placerholder="Ingrese numero de candidato" title="Número Candidato Requerido" />
                            <asp:LinkButton Text="Aleatorio" runat="server" ID="linkBtnRandomNumber" onclick="linkBtnRandomNumber_Click" />
                        </ContentTemplate>
                    </asp:updatepanel>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-6" for="ddlSesion">Evento a Postularse</label>
            <div class="col-sm-6">
                <asp:dropdownlist id="ddlSesion" runat="server" width="320px" cssclass="txts" />
            </div>           
        </div>
        <div class="form-group text-center">
            <asp:button id="btnPostular" text="Postularme" validationgroup="A" cssclass="btns" runat="server" onclick="btnPostular_Click" />
        </div>
    </div>
</form>