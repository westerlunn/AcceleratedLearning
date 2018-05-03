$("#button1").click(function () {

    var numberFromInputBox = $("#numberInput").val();

    $.ajax({
            url: '/calculate/square/',
        method: 'GET',
        data: {number: numberFromInputBox}
            
        })
        .done(function (result) {
            alert(`Kvadrerat: ${result}`);
            console.log("Succé", result);


        })
        .fail(function (xhr, status, error) {
            alert(`Fel! ${xhr.responseText}`);
            console.log("status", status);
            console.log("fel", error);


        });
});