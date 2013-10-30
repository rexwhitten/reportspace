$(document).ready(function () {
    $(".async-tab").click(function () {
        $.ajax({
            url: $(this).data('url'),
            type: "GET",
            cache: false,
            context: $($(this).attr("href")),
            success: function (response) {
                $(this).html(response);
            }
        });
    });

    $(".async-tab").first().click();
});