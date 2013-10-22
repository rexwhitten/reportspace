$(document).ready(function () {
    $('#add-role-btn').live('click', function () {
        var url = $(this).data("modal-url");
        $.ajax({
            url: url,
            cache: false,
            success: function (data) {
                $('#edit-role-container').html(data);
                $('#edit-role').modal('show');
            }
        });
    });

    $('.edit-role-btn').live('click', function () {
        var url = $(this).data("modal-url");
        $.ajax({
            url: url,
            cache: false,
            success: function (data) {
                $('#edit-role-container').html(data);
                $('#edit-role').modal('show');
            }
        });
    });
});