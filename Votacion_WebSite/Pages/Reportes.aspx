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

        // Load the Visualization API and the piechart package.
        google.load('visualization', '1.0', { 'packages': ['corechart'] });

        // Set a callback to run when the Google Visualization API is loaded.
        google.setOnLoadCallback(drawChart);

        // Callback that creates and populates a data table,
        // instantiates the pie chart, passes in the data and
        // draws it.
        function drawChart() {

            // Create the data table.
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Topping');
            data.addColumn('number', 'Slices');
            data.addRows([
              ['Mushrooms', 1],
              ['Onions', 1],
              ['Olives', 1],
              ['Zucchini', 1],
              ['Pepperoni', 1]
            ]);

            // Set chart options
            var options = {
                'title': 'Reporte de ganador por campaña',
                'width': 400,
                'height': 300
            };

            // Instantiate and draw our chart, passing in some options.
            var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }


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

                            for (var i = 0; i < response.d.length; i++)
                            {
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
            Seleccione una campaña
        <br />
            <div style="width: 50%; align-items: center">
                <asp:DropDownList ID="ddlCampañas" runat="server"></asp:DropDownList>
            </div>
            <br />
            <div id="chart_div"></div>
        </div>

    </form>
</body>
</html>
