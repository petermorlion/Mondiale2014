(function ($) {
    var initializeTable = function () {
        var table = $('table.table-fixed-header');
        if (table.length === 0) {
            console.log('nothing found!')
            return;
        }

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
        var handleScroll = function () {
            if ($(window).scrollTop() > y) {
                clonedHeader.show();
            } else {
                clonedHeader.hide();
            }
        };

        handleScroll();
        
        $(window).scroll(function () {
            handleScroll();
        });
    };

    var isInitialized = false;
    $(window).scroll(function () {
        if (!isInitialized) {
            console.log('initializing...');
            initializeTable();
            isInitialized = true;
            console.log('initialized!');
        }
    });

})(jQuery);
