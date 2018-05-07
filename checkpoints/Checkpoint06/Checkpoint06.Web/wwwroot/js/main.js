
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
            showObservations();
            showSpecies();
        })
        
        .fail(function (xhr, status, error) {
            alert(`${xhr.responseText}`);
            console.log("status", status);
            console.log("fel", error);


        });
});


//$("#viewButton").click(showObservations());


function showObservations() {

    $.ajax({
            url: '/birds/viewObservations',
            method: 'get'
        })
        .done(function(result) {
            $("#view").html(`<h3>Observationer:</h3> 
            <table>
                <tr>
                    <th>Art</th>
                    <th>Datum</th>
                    <th>Plats</th>  
                    <th>Anteckningar</th>
                </tr>
                ${result}
            </table>`);
        })
        .fail(function(xhr, status, error) {
            alert("Nu blev det fel");
            console.log(xhr);
            console.log(status);
            console.log(error);
        });
}

function showSpecies() {

        $.ajax({
            url: '/birds/viewSpecies',
                method: 'get'
            })
            .done(function (result) {
                $("#viewSpecies").html(`<h3>Arter:</h3> 
            <table>
               
                ${result}
            </table>`);
            })
            .fail(function (xhr, status, error) {
                alert("Nu blev det fel");
                console.log(xhr);
                console.log(status);
                console.log(error);
            });
}
    
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