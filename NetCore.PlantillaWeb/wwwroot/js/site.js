// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

async function BuscarMunicipios()
{
    //event.preventDefault();
    let nombreEstadoSeleccionado = document.getElementById("estadoInput").value;

    if (nombreEstadoSeleccionado == '') {
        /* DESOCULTAR MUNICIPIOS Y EL BUSCADOR */
        document.getElementById("municipioSelect").style.display = 'none';
        document.getElementById("btnBuscar").style.display = 'none';

        document.getElementById("AsentamientosData").style.display = 'none';

    } else
    {
        /** CONSULTA DE MUNICIPIOS ***/
        //MensajeCargando();

        const response = await axios.get('/Home/ObtenerMunicipios?nombreEstadoSeleccionado='+nombreEstadoSeleccionado+'');

        
        if (response.data.statusCode != 200) {
            console.log(response.data.message);
        } else {
            let listaMunicipios = document.getElementById("municipioSelect");

            /*Eliminar options cargadas */
            while (listaMunicipios.options.length > 1) {
                listaMunicipios.remove(1);
            }

            document.getElementById("municipioSelect").options.item(0).selected = 'selected';

            let municipios = response.data.result;
            //console.log(municipios);
            municipios.forEach(function (item) {
                var option = document.createElement('option');
                option.value = item.idMunicipio;
                option.text = item.nombreMunicipio;
                listaMunicipios.appendChild(option);

            });
        

            /* DESOCULTAR MUNICIPIOS Y EL BUSCADOR */
            document.getElementById("municipioSelect").style.display = 'block';
            document.getElementById("btnBuscar").style.display = 'block';

        }


    }

}


let estadoInput = document.getElementById("estadoInput");
estadoInput.addEventListener("change", () => BuscarMunicipios(), false);





async function BuscarAsentamientos(event) {
    event.preventDefault();

    let nombreEstadoSeleccionado = document.getElementById("estadoInput").value;
    if (nombreEstadoSeleccionado == '') {
        alert("No cargo ningun estado y municipio")
    } else
    {

        let municipioSelect = document.getElementById("municipioSelect");
        let municipioOption = municipioSelect.options[municipioSelect.selectedIndex]


        //console.log(municipioOption);
        //console.log(municipioOption.value);
        //console.log(municipioOption.text);

        if (municipioOption.value == 0) {
            alert("Seleccione un municipio");
        } else
        {
            const response = await axios.post('/Home/ObtenerAsentamientos',
                {
                    Value: parseInt(municipioOption.value)
                });

            //console.log(response);

            if (response.data.statusCode != 200) {
                alert(response.data.message);
                console.log(response.data.message);
            } else {

                $('#divAsentamientos').empty();
                DibujarTblAsentamientos(municipioOption.text);
                RellenarTblAsentamientos(response.data.result, municipioOption.text);
                document.getElementById("AsentamientosData").style.display = 'block';
            }
        }
        
    }
}

function DibujarTblAsentamientos(nombreMunicipio) {
    $("#divAsentamientos").append(

        "<table id='TblAsentamientos'  class='table table-striped display table-bordered table-hover' cellspacing='0'  style='width:100%'>" +
        " <caption class='text-uppercase'>Asentamientos dentro del municipio de: "+nombreMunicipio+" </caption>"
        + "<thead class='tabla'>" +

        "<tr class='text-center text-uppercase'>" +

        "<th>Codigo Postal</th>" +
        "<th>Nombre Asentamiento</th>" +
        "<th>Tipo Zona</th>" +
        "<th>Descripcion </th>" +
        "</tr>" +
        "</thead>" +
        "</table>"
    );
};


function RellenarTblAsentamientos(datos, nombreMunicipio) {

    $('#TblAsentamientos').DataTable({
        "dom": 'Blfrtip',
        "buttons": [
            {
                extend: 'excel',
                className: 'btn btn-primary ',
                text: '<i class="fas fa-file-download"></i>  &nbsp  EXCEL',
                filename: `Detalle_Municipio_EXCEL`,
                title: `ASENTAMIENTOS EN : ${nombreMunicipio} `
            },
            {
                extend: 'pdf',
                className: 'btn btn-primary ',
                text: ' <i class="fas fa-download"></i>  &nbsp PDF ',
                filename: `Detalle_Municipio_PDF`,
                title: `ASENTAMIENTOS EN : ${nombreMunicipio} `
            }
        ],
        "bDestroy": true,
        "ordering": true,
        "info": true,
        "searching": true,
        "paging": true,
        "lengthMenu": [[5, 15, 20, 40, -1], [5, 15, 20, 40, 'Todo']],
        "language":{
            "processing": "Procesando...",
            "lengthMenu": "Mostrar _MENU_ registros",
            "zeroRecords": "No se encontraron resultados",
            "emptyTable": "Ningún dato disponible en esta tabla",
            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
            "search": "Buscar:",
            "info": "Mostrando de _START_ a _END_ de _TOTAL_ entradas",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "data": datos,
        "columns": [
            { "data": "codigoPostal" },
            { "data": "nombreAsentamiento" },
            { "data": "tipoZona" },
            { "data": "descripcionZona" }
        ],
        "columnDefs": [
            { "className": "dt-center", "targets": "_all" }
        ],
        "order": [[0, 'asc']]

    });

};



