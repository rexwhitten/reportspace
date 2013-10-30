$(document).ready(function () {
    $('#add-user-btn').live('click', function () {
        var url = $(this).data("modal-url");
        $.ajax({
            url: url,
            cache: false
            }).then(function (data) {
                $('#edit-user-container').html(data);
                $('#edit-user').modal('show');
            });
    });

    $('.edit-user-btn').live('click', function () {
        var url = $(this).data("modal-url");
        $.ajax({
            url: url,
            cache: false
        }).then(function (data) {
            $('#edit-user-container').html(data);
            $('#edit-user').modal('show');
        });
    });

    $('.activate-user').live('click', function () {
        var url = $(this).data("url");
        $.ajax(url, {
            type: "PUT",
            contentType: 'application/json; charset=utf-8',
            context: $(this),
            cache: false
        }).then(function (data) {
            toastr["success"]("User successfully activated.");
            return data.url;
        }, function(error) {
            toastr["error"]("Error occured. User was not activated.");
        }).then(function(candidateUrl) {
            $.ajax(
                candidateUrl,
                {
                    type: "GET",
                    context: $(this)
                }).then(function(data) {
                    $(this).parent().parent().replaceWith(data);
                });
        });
    });
});