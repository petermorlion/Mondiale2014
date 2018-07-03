(function () {
    'use strict';

    var controllerId = 'overview';
    angular.module('app')
        .controller(controllerId, ['$q', '$http', '$stateParams', 'alertr', function ($q, $http, $stateParams, alertr) {
        
            var vm = this;
            vm.title = 'Een overzicht';

            vm.isLoading = true;

            $http({
                method: 'GET',
                url: '/api/Overview/' + $stateParams.tournamentId
            }).success(function (data, status, headers, config) {
                vm.overview = data;
                vm.isLoading = false;
                setTimeout(initializeTable, 1);
            }).error(function (data, status, headers, config) {
                alertr.error('Er is helaas een fout gebeurd.');
            });

            // TODO: UI logic in controller...
            var initializeTable = function () {
                var table = $('table.table-fixed-header');
                if (table.length === 0) {
                    console.log('nothing found!');
                    return;
                }

                var tableHeader = table.find('thead');
                var clonedHeader = tableHeader.clone(true);

                var tableHeaderCells = tableHeader.find('th');
                var clonedHeaderCells = clonedHeader.find('th');
                for (var i = 0; i < tableHeaderCells.length; i++) {
                    $(clonedHeaderCells[i]).css({ width: $(tableHeaderCells[i]).width() });
                }

                var navbarHeight = $('.navbar').height();

                var fixedTable = $('<table class="table"/>')
                      .insertBefore(table)
                    .css({
                        position: 'fixed',
                        top: navbarHeight + 'px',
                        'background-color': '#fff',
                        width: table.width()
                    });

                clonedHeader
                    .hide()
                    .appendTo(fixedTable);

                var y = table.position().top - navbarHeight;

                var handleScroll = function () {
                    var scrollTop = $(window).scrollTop();
                    if (scrollTop > y) {
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

                $('.overview-table-container').scroll(function() {
                    handleScroll();
                });
            };
        
    }]);
})();