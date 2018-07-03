(function () {
    'use strict';

    var controllerId = 'statistics';
    angular.module('app')
        .controller(controllerId, ['$q', '$stateParams', '$http', 'alertr', function ($q, $stateParams, $http, alertr) {
        
            var vm = this;
            vm.title = 'Enkele statistieken';
            
            vm.isLoading = true;

            $http({
                method: 'GET',
                url: '/api/Stats/' + $stateParams.tournamentId
            }).success(function (data, status, headers, config) {
                var chartConfig = {
                    type: 'line',
                    data: {
                        labels: [],
                        datasets: []
                    },
                    options: {
                        responsive: true,
                        title: {
                            display: true,
                            text: 'Puntenopbouw'
                        },
                        tooltips: {
                            mode: 'index',
                            intersect: false,
                        },
                        hover: {
                            mode: 'nearest',
                            intersect: true
                        },
                        scales: {
                            xAxes: [{
                                display: true,
                                scaleLabel: {
                                    display: true,
                                    labelString: 'Matchen'
                                }
                            }],
                            yAxes: [{
                                display: true,
                                scaleLabel: {
                                    display: true,
                                    labelString: 'Punten'
                                }
                            }]
                        }
                    }
                }

                for (var i = 0; i < data.Categories.length; i++) {
                    chartConfig.data.labels.push('');
                }

                var colors = [
                    '#7CB5EC',
                    '#434348',
                    '#90ED7D',
                    '#F7A35C',
                    '#8085E9',
                    '#F15C80',
                    '#E4D354',
                    '#8D4653',
                    '#E559CB',
                    '#3D45E2',
                    '#1F701D',
                    '#BF2FB3',
                    '#BC2022',
                ];

                for (var i = 0; i < data.Series.length; i++) {
                    var serie = {
                        label: data.Series[i].Name,
                        data: data.Series[i].Data,
                        fill: false,
                        backgroundColor: colors[i],
                        borderColor: colors[i]
                    };

                    chartConfig.data.datasets.push(serie);
                }

                var ctx = document.getElementById("chart").getContext('2d');
                var myChart = new Chart(ctx, chartConfig);

                vm.mostExactResults = data.MostExactResults;
                vm.mostExactResultsUsers = data.MostExactResultsUsers;

                vm.leastExactResults = data.LeastExactResults;
                vm.leastExactResultsUsers = data.LeastExactResultsUsers;

                vm.isLoading = false;
            }).error(function (data, status, headers, config) {
                alertr.error('Er is helaas een fout gebeurd.');
            });
        
    }]);
})();