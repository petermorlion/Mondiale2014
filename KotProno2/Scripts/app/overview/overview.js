(function () {
    'use strict';

    var controllerId = 'overview';
    angular.module('app')
        .controller(controllerId, ['$q', 'breeze', '$http', function ($q, breeze, $http) {
        
            var vm = this;
            vm.title = 'Een overzicht';

            vm.isLoading = true;

            $http({
                method: 'GET',
                url: '/breeze/matches/Overview'
            }).success(function (data, status, headers, config) {
                vm.overview = data;
                vm.isLoading = false;
                setTimeout(initializeTable, 1);
            }).error(function (data, status, headers, config) {
                toastr.error('Er is helaas een fout gebeurd.');
            });

            // TODO: UI logic in controller...
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

                    var move = $(window).scrollLeft();
                    var origin = table.position().left;
                    fixedTable.css('left', origin - move);
                };

                handleScroll();

                $(window).scroll(function () {
                    handleScroll();
                });
            };
        
    }]);
})();