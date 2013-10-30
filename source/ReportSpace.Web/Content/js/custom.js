// dropdown in leftmenu
jQuery('.leftmenu .dropdown > a').click(function () {
    if (!jQuery(this).next().is(':visible'))
        jQuery(this).next().slideDown('fast');
    else
        jQuery(this).next().slideUp('fast');
    return false;
});

$('.widgettitle .close').live('click', function () {
    $(this).parents('.widgetbox').fadeOut(function () {
        $(this).remove();
    });
});

$('.minimize').live('click', function () {
    if (!$(this).hasClass('collapsed')) {
        $(this).addClass('collapsed');
        $(this).html("&#43;");
        $(this).parents('.widgetbox')
                      .css({ marginBottom: '20px' })
                        .find('.widgetcontent')
                        .hide();
    } else {
        $(this).removeClass('collapsed');
        $(this).html("&#8211;");
        $(this).parents('.widgetbox')
                      .css({ marginBottom: '0' })
                        .find('.widgetcontent')
                        .show();
    }
    return false;
});