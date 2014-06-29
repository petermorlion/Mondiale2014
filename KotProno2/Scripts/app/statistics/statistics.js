(function () {
    'use strict';

    var controllerId = 'statistics';
    angular.module('app')
        .controller(controllerId, ['$q', 'breeze', '$http', function ($q, breeze, $http) {
        
            var vm = this;
            vm.title = 'Enkele statistieken';
            
            vm.isLoading = true;

            Highcharts.setOptions({
                lang: {
                    resetZoom: 'Zoom resetten'
                }
            });

            $http({
                method: 'GET',
                url: '/breeze/matches/Statistics'
            }).success(function (data, status, headers, config) {
                var pointsGraphData = {
                    chart: { zoomType: 'xy' },
                    subtitle: {
                        text: document.ontouchstart === undefined ?
                            'Klik en trek een kader op de grafiek om in te zoomen. Klik op een naam om die lijn in/uit te schakelen.' :
                            'Gebruik twee vingers om in te zoomen. Druk op een naam om die lijn in/uit te schakelen.'
                    },
                    title: {
                        text: 'Puntenopbouw',
                        x: -20 //center
                    },
                    tooltip: {
                        shared: true,
                        crosshairs: true
                    },
                    xAxis: { categories: [] },
                    yAxis: {
                        plotLines: [{ value: 0, width: 1, color: '#808080' }],
                        min: 0,
                        title: { text: 'Punten' }
                    },
                    series: []
                }

                for (var i = 0; i < data.Categories.length; i++) {
                    pointsGraphData.xAxis.categories.push(data.Categories[i]);
                }

                for (var i = 0; i < data.Series.length; i++) {
                    var serie = {
                        name: data.Series[i].Name,
                        data: data.Series[i].Data
                    };

                    pointsGraphData.series.push(serie);
                }

                $('#container').highcharts(pointsGraphData);

                vm.mostExactResults = data.MostExactResults;
                vm.mostExactResultsUsers = data.MostExactResultsUsers;

                vm.leastExactResults = data.LeastExactResults;
                vm.leastExactResultsUsers = data.LeastExactResultsUsers;

                vm.isLoading = false;
            }).error(function (data, status, headers, config) {
                toastr.error('Er is helaas een fout gebeurd.');
            });
        
    }]);
})();