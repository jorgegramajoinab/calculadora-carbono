    function apiGet( url ) {
        $.ajax("api/species/all")
            .done(data => console.log(data))
            .fail(() => console.log("Error."))
            .always(() => console.log("Completado."));
        //$.ajax({
        //    url: url,
        //    method: "GET",
        //    data: {
        //        especie: especie
        //    },
        //    success: function (data) {
        //        var status = data.status;
        //        // Llamada correcta, muestra resultado
        //        if (status == 200) {
        //            $('#sel_sitio').html('');
        //            $('#sel_sitio').select2({ data: data.response });
        //        }
        //    },
        //    error: function (requestObject, error, errorThrown) {
        //        alert('Error al obtener índices de sitio');
        //    }
        //});
    }
