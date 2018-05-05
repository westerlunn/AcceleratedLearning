
$("#speciesButton").click(function () {

    var observation = $("#species").val();

    $.ajax({
        url: '/birds/addObservations/',
            method: 'POST',
            data: { Species: observation }

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
            $("#view").html(`<h3>Observationer:</h3> ${result}`);
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
