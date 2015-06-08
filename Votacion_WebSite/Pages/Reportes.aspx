<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Votacion_WebSite.Pages.Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes</title>
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script type="text/javascript">

        //// Load the Visualization API and the piechart package.
        google.load('visualization', '1.0', { 'packages': ['corechart'] });

        //// Set a callback to run when the Google Visualization API is loaded.
        //google.setOnLoadCallback(drawChart);

        //// Callback that creates and populates a data table,
        //// instantiates the pie chart, passes in the data and
        //// draws it.
        //function drawChart() {

        //    // Create the data table.
        //    var data = new google.visualization.DataTable();
        //    data.addColumn('string', 'Topping');
        //    data.addColumn('number', 'Slices');
        //    data.addRows([
        //      ['Mushrooms', 1],
        //      ['Onions', 1],
        //      ['Olives', 1],
        //      ['Zucchini', 1],
        //      ['Pepperoni', 1]
        //    ]);

        //    // Set chart options
        //    var options = {
        //        'title': 'Reporte de ganador por campaña',
        //        'width': 400,
        //        'height': 300
        //    };

        //    // Instantiate and draw our chart, passing in some options.
        //    var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
        //    chart.draw(data, options);
        //}


        $(function () {
            $("#ddlCampañas").change(function () {

                $.ajax({
                    type: "POST",
                    url: "Reportes.aspx/GetDataAjax",
                    data: "{'idCampana':" + $("#ddlCampañas").val() + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response != null) {

                            // Create the data table.
                            var data = new google.visualization.DataTable();
                            data.addColumn('string', 'Nombre_Candidato');
                            data.addColumn('number', 'Numero_Votos');
                            var rows = new Array();
                            var Nombre_Candidato = "";
                            var Numero_Votos = 0;

                            for (var i = 0; i < response.d.length; i++) {
                                Nombre_Candidato = response.d[i][1];
                                Numero_Votos = parseInt(response.d[i][2]);
                                rows.push([Nombre_Candidato, Numero_Votos]);
                            }

                            data.addRows(rows);

                            // Set chart options
                            var options = {
                                'title': 'Reporte de ganador por campaña',
                                'width': 800,
                                'height': 600
                            };

                            // Instantiate and draw our chart, passing in some options.
                            var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
                            chart.draw(data, options);
                        }


                    },
                    error: function (result) {
                        alert('ERROR ' + result.status + ' ' + result.statusText);
                    }
                });
            });

            $("#ddlArea").change(function () {

                $.ajax({
                    type: "POST",
                    url: "Reportes.aspx/GetDataAjaxArea",
                    data: "{'idCampana':" + $("#ddlCapanna2").val() + ", idArea:" + $("#ddlArea").val() + " }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response != null) {


                            var data = new google.visualization.DataTable();
                            data.addColumn('string', 'Nombre_Candidato');
                            data.addColumn('number', 'Numero_Votos');
                            var rows = new Array();
                            var Nombre_Candidato = "";
                            var Numero_Votos = 0;

                            for (var i = 0; i < response.d.length; i++) {
                                Nombre_Candidato = response.d[i][1];
                                Numero_Votos = parseInt(response.d[i][2]);
                                rows.push([Nombre_Candidato, Numero_Votos]);
                            }

                            //var data = google.visualization.arrayToDataTable([
                            //            ["Nombre_Candidato", "Numero_Votos", { role: "style" }]]);

                            for (var i = 0; i < response.d.length; i++) {
                                Nombre_Candidato = response.d[i][1];
                                Numero_Votos = parseInt(response.d[i][2]);
                                //rows.push([Nombre_Candidato, Numero_Votos, "color: #e5e4e2"]);
                                data.addRow([Nombre_Candidato, Numero_Votos]);
                            }

                            var options = {
                                title: "Reporte - Ganador de Campaña por Area",
                                width: 600,
                                height: 400,
                                bar: { groupWidth: "95%" },
                                legend: { position: "none" },
                            };
                            var chart = new google.visualization.ColumnChart(document.getElementById("chart_div_2"));
                            chart.draw(data, options);
                        }


                    },
                    error: function (result) {
                        alert('ERROR ' + result.status + ' ' + result.statusText);
                    }
                });
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="scriptManager" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true" ScriptMode="Release" EnablePageMethods="true">
        </asp:ToolkitScriptManager>
        <div class="container text-center">
            <h2>Reporte de ganador por campaña </h2>

        </div>
        <div style="margin-left: 15%">

            <br />
            <div style="width: 50%; margin: 0 auto;">
                Seleccione una campaña
                <asp:DropDownList ID="ddlCampañas" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="width: 70%; margin: 0 auto;" id="chart_div"></div>
        </div>

        <div class="container text-center">
            <h2>Reporte - Ganador de Campaña por Area</h2>

        </div>
        <div style="margin-left: 15%">
            <div style="width: 50%; margin: 0 auto;">
                Seleccione una campaña&nbsp;
                        <asp:DropDownList ID="ddlCapanna2" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlCapanna2_SelectedIndexChanged">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Seleccione una Area&nbsp;
                        <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
            </div>
            <div style="width: 70%; margin: 0 auto;" id="chart_div_2"></div>
        </div>

    </form>
</body>
</html>
