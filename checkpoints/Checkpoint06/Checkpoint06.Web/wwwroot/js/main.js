
$("#speciesButton").click(function () {

    var species = $("#species").val();
    var date = $("#date").val();
    var place = $("#place").val();
    var notes = $("#notes").val();

    $.ajax({
        url: '/birds/addObservations/',
        method: 'POST',
        data: {
            Species: species,
            Date: date,
            Place: place,
            Notes: notes
}

        })
        .done(function (result) {
            alert("Art tillagd");

        })
        .fail(function (xhr, status, error) {
            alert(`${xhr.responseText}`);
            console.log("status", status);
            console.log("fel", error);


        });
});


$("#viewButton").click(function () {
  
    
    $.ajax({
        url: '/birds/viewObservations',
        
        method: 'get',
        success: function (result) {
            $("#view").html(`<h3>Observationer:</h3> 
<table>
            <tr>
                <th>Art</th>
                <th>Datum</th>
                <th>Plats</th>
                <th>Anteckningar</th>
            </tr> ${result}`);
        },
        error: function (xhr, status, error) {
            alert("Nu blev det fel");
            console.log(xhr);
            console.log(status);
            console.log(error);
        }
    });
    
    /*
    $.ajax({
            url: '/birds/viewObservations/',
            method: 'GET'
        })
        .done(function (result) {
            ("body").html(result);

        })
        .fail(function (xhr, status, error) {
            alert(`${xhr.responseText}`);
            console.log("status", status);
            console.log("fel", error);


        });
        */
});
