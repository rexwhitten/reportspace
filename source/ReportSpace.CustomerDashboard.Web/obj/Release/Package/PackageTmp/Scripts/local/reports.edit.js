$(document).ready(function() {
    $('#add-report-btn').live("click", function () {
        var url = $("#add-report-btn").data("modal-url");
        $.ajax({
            url: url,
            cache: false,
            success: function(data) {
                $('#edit-report-container').html(data);
                $('#edit-report').modal('show');
            }
        });
    });
    
    $('.edit-report-btn').live('click', function() {
        var url = $(this).data("modal-url");
        $.ajax({
            url: url,
            cache: false,
            success: function (data) {
                $('#edit-report-container').html(data);
                $('#edit-report').modal('show');
            }
        });
    });
});
