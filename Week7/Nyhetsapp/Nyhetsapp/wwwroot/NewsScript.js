$("#addNewsButton").click(function () {
    var form = $("#addForm");
    var header = $("[name = header]", form).val();
    var intro = $("[name = intro]", form).val();
    var body = $("[name = body]", form).val();

    $.ajax({
            url: '/news/add',
            method: 'POST',
            data: {
                "Header": header,
                "Intro": intro,
                "Body": body
            }
        })
        .done(function(id) {
                alert(`News with id = ${id} added`);
            })
            .fail(function(xhr, status, error) {
                handleError(xhr, status, error);
            });
});

$("#countButton").click(function() {
    $.ajax({
            url: '/news/count',
            method: 'GET'
        })
        .done(function (result) {
            alert(`Number of news: ${result}`);
        })
        .fail(function(xhr, status, error) {
            alert("Nu blev det fel");
            console.log(xhr);
            console.log(status);
            console.log(error);
        });
});

