$("#addNewsButton").click(function () {
    var form = $("#addForm");
    var header = $("[name = header]", form).val();
    var intro = $("[name = intro]", form).val();
    var body = $("[name = body]", form).val();

    $.ajax({
            url: '/News/',
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

