<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/VotoXMax.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Votacion_WebSite.Pages.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h2 {
            text-shadow: 0px 0px 27px rgba(133, 133, 133, 0.75);
            color: #FFFFFF;
            font-size: 25px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            //$(".menu-item").on("click", function () {
            //    var DivIdIframe = $(this).find("a").attr("href");
            //    var Iframe = $(DivIdIframe).find("iframe");
            //    //Iframe.css("width", $(document).width());
            //    //Iframe.css("height", $(window).height());
            //})
        });

        
    </script>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Main Body Section -->
    <div class="mainbody-section text-center">
        <h2>Que Deseas Hacer?</h2>
        <div class="container">
            <div class="row">
                <!-- Begin Div Super Administrador -->
                <div runat="server" id="dvSuperAdmin" visible="false">
                    <span style="color: white">Super Admin</span>
                    <br />
                    <div class="col-md-4">
                        <div class="menu-item color responsive">
                            <a href="#admempresas-modal" data-toggle="modal">
                                <i class="fa fa-building"></i>
                                <p>Administrar Empresas</p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="menu-item light-red">
                            <a href="#admusuarios-modal" data-toggle="modal">
                                <i class="fa fa-users"></i>
                                <p>Administrar Usuarios</p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="menu-item light-orange responsive">
                            <a href="#admareas-modal" data-toggle="modal">
                                <i class="fa fa-bar-chart"></i>
                                <p>Administrar Areas de Trabajo</p>
                            </a>
                        </div>
                    </div>
                </div>
                <!-- End Div Super Administrador -->

                <!-- Begin Div Administrador -->
                <div runat="server" id="dvCompanies" visible="false">
                    <span style="color: white">Admin</span>
                    <br />
                    <div class="col-md-1">
                    </div>
                    <div class="col-md-2">
                        <div class="menu-item light-red">
                            <a href="#admusuarios-modal" data-toggle="modal">
                                <i class="fa fa-users"></i>
                                <p>Administrar
                                    <br />
                                    Usuarios</p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="menu-item blue">
                            <a href="#admvot-modal" data-toggle="modal">
                                <i class="fa fa-flag"></i>
                                <p>Administrar
                                    <br />
                                    Votaciones</p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="menu-item light-orange responsive">
                            <a href="#admareas-modal" data-toggle="modal">
                                <i class="fa fa-university"></i>
                                <p>Administrar
                                    <br />
                                    Areas de Trabajo</p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="menu-item green">
                            <a href="#admcandid-modal" data-toggle="modal">
                                <i class="fa fa-check-circle-o"></i>
                                <p>Administrar
                                    <br />
                                    Candidatos</p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="menu-item color">
                            <a href="#adm-reportes" data-toggle="modal">
                                <i class="fa fa-bar-chart"></i>
                                <p>Reportes
                                    <br />
                                    &nbsp</p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>
                <!-- End Div Administrador -->

                <!-- Begin Div User -->
                <div runat="server" id="dvUsers" visible="false">
                    <span style="color: white">User</span>
                    <br />
                    <div class="col-md-3">
                    </div>
                    <div class="col-md-3">
                        <div class="menu-item color">
                            <a href="#postcandidato-modal" data-toggle="modal">
                                <i class="fa fa-pencil"></i>
                                <p>Postularme como Candidato</p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="menu-item light-red">
                            <a href="#votar-modal" data-toggle="modal">
                                <i class="fa fa-cube"></i>
                                <p>Votar por un Candidato</p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-3">
                    </div>
                </div>
                <!-- End Div User -->
            </div>

        </div>
        <!-- begin secciones-->

        <!-- Start administrar empresas Section -->
        <div class="section-modal modal fade" id="admempresas-modal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-content">
                <div class="close-modal" data-dismiss="modal">
                    <div class="lr">
                        <div class="rl">
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="section-title text-center">
                            <h3>Administrar Empresas</h3>
                            <p>En esta opcion podra realizar las operaciones requeridas para las empresas</p>
                        </div>
                    </div>

                    <!-- 16:9 aspect ratio -->
                    <div class="embed-responsive embed-responsive-16by9">
                        <iframe src="../Administrator/AdmCompanys.aspx" class="embed-responsive-item" style="overflow-x: hidden"></iframe>
                    </div>
                </div>

            </div>
        </div>
        <!-- End administrar empresas Section -->

        <!-- Start administrar usuarios Section -->
        <div class="section-modal modal fade" id="admusuarios-modal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-content">
                <div class="close-modal" data-dismiss="modal">
                    <div class="lr">
                        <div class="rl">
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="section-title text-center">
                            <h3>Administrar Usuarios</h3>
                            <p>En esta opcion podra realizar las operaciones requeridas para los usuarios</p>
                        </div>
                    </div>

                    <!-- 16:9 aspect ratio -->
                    <div class="embed-responsive embed-responsive-16by9">
                        <iframe src="../Administrator/AdmUser.aspx" class="embed-responsive-item" style="overflow-x: hidden"></iframe>
                    </div>
                </div>

            </div>
        </div>
        <!-- End administrar usuarios Section -->

        <!-- Start administrar areas de trabajo Section -->
        <div class="section-modal modal fade" id="admareas-modal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-content">
                <div class="close-modal" data-dismiss="modal">
                    <div class="lr">
                        <div class="rl">
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="section-title text-center">
                            <h3>Administrar Areas de Trabajo</h3>
                            <p>En esta opcion podra realizar las operaciones requeridas para las Areas de Trabajo</p>
                        </div>
                    </div>

                    <!-- 16:9 aspect ratio -->
                    <div class="embed-responsive embed-responsive-16by9">
                        <iframe src="Areas.aspx" class="embed-responsive-item" style="overflow-x: hidden"></iframe>
                    </div>
                </div>
            </div>
        </div>
        <!-- End administrar areas de trabajo Section -->

        <!-- Start administrar votaciones Section -->
        <div class="section-modal modal fade" id="admvot-modal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-content">
                <div class="close-modal" data-dismiss="modal">
                    <div class="lr">
                        <div class="rl">
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="section-title text-center">
                            <h3>Administrar Votaciones</h3>
                            <p>En esta opcion podra realizar las operaciones requeridas para las votaciones</p>
                        </div>
                    </div>

                    <!-- 16:9 aspect ratio -->
                    <div class="embed-responsive embed-responsive-16by9">
                        <iframe src="Votaciones.aspx" class="embed-responsive-item" style="overflow-x: hidden"></iframe>
                    </div>
                </div>
            </div>
        </div>
        <!-- end administrar votaciones Section -->

        <!-- Start administrar candidatos Section -->
        <div class="section-modal modal fade" id="admcandid-modal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-content">
                <div class="close-modal" data-dismiss="modal">
                    <div class="lr">
                        <div class="rl">
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="section-title text-center">
                            <h3>Administrar Candidatos</h3>
                            <p>En esta opcion podra realizar las operaciones requeridas para los candidatos</p>
                        </div>
                    </div>

                    <!-- 16:9 aspect ratio -->
                    <div class="embed-responsive embed-responsive-16by9">
                        <iframe src="InscribirUsuario.aspx" class="embed-responsive-item" style="overflow-x: hidden"></iframe>
                    </div>
                </div>
            </div>
        </div>
        <!-- end administrar candidatos Section -->

        <!-- Start postularme como Candidato -->
        <div class="section-modal modal fade" id="postcandidato-modal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-content">
                <div class="close-modal" data-dismiss="modal">
                    <div class="lr">
                        <div class="rl">
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="section-title text-center">
                            <h3>Postularme como Candidato</h3>
                            <p>En esta opcion podra realizar las operaciones requeridas para postularse como candidato</p>
                        </div>
                    </div>

                    <!-- 16:9 aspect ratio -->
                    <div class="embed-responsive embed-responsive-16by9">
                        <iframe src="Postular.aspx" class="embed-responsive-item" style="overflow-x: hidden"></iframe>
                    </div>
                </div>
            </div>
        </div>
        <!-- End postularme como Candidato-->

        <!-- Start Votar por un Candidato -->
        <div class="section-modal modal fade" id="votar-modal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-content">
                <div class="close-modal" data-dismiss="modal">
                    <div class="lr">
                        <div class="rl">
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="section-title text-center">
                            <h3>Votar por un Candidato</h3>
                            <p>En esta opcion podra realizar las operaciones requeridas para votar por un candidato</p>
                        </div>
                    </div>

                    <!-- 16:9 aspect ratio -->
                    <div class="embed-responsive embed-responsive-16by9">
                        <iframe src="Votar.aspx" class="embed-responsive-item" style="overflow-x: hidden"></iframe>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Votar por un Candidato-->

        <!-- -->
        <div id="adm-reportes" class="section-modal modal fade" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-content">
                <div class="close-modal" data-dismiss="modal">
                    <div class="lr">
                        <div class="rl">
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="section-title text-center">
                            <h3>Reportes</h3>
                            <p>En esta opcion podra realizar las operaciones requeridas para los reportes</p>
                        </div>
                    </div>

                    <!-- 16:9 aspect ratio -->
                    <div class="embed-responsive embed-responsive-16by9">
                        <iframe src="Reportes.aspx" class="embed-responsive-item" style="overflow-x: hidden"></iframe>
                    </div>
                </div>
            </div>
        </div>
        <!-- -->
        <!-- End Secciones -->
        <!-- End Main Body Section -->
    </div>
</asp:Content>
