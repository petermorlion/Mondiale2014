(function ($) {


    var initializeTable = function() {
        var table = $('table.table-fixed-header');
        var tableHeader = table.find('thead');
        var clonedHeader = tableHeader.clone(true);

        var navbarHeight = $('.navbar').height();

        var fixedTable = $('<table class="table"/>')
              .insertBefore(table)
              .css({ position: 'fixed', top: navbarHeight + 'px', 'background-color': '#fff', width: table.width() });

        clonedHeader
            .hide()
            .appendTo(fixedTable);

        var y = tableHeader.position().top - navbarHeight;
        console.log('y: ' + y);

        $(window).scroll(function () {
            if ($(window).scrollTop() > y) {
                clonedHeader.show();
            } else {
                clonedHeader.hide();
            }
        });
    };

    setTimeout(function () { initializeTable(); }, 3000);

})(jQuery);
