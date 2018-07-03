(function () {
    'use strict';
    var serviceId = 'alertr';
    angular.module('app')
        .factory(serviceId, function () {
            var alertDuration = 3000;
            var lifetimeAfterFadeOut = alertDuration + 200;
            var service = {
                error: function (msg) {
                    var element = $('<div class="alert alert-error alert-dismissible fade show" role="alert"> \
                                        '+ msg + ' \
                                        <button type= "button" class="close" data-dismiss="alert" aria-label="Close"> \
                                        <span aria-hidden="true">&times;</span> \
                                        </button> \
                                        </div>');
                    element.appendTo('#alertrContainer');
                    window.setTimeout(function () {
                        element.fadeTo(500, 0).slideUp(500, function () {
                            $(this).remove();
                        });
                    }, alertDuration);
                    window.setTimeout(function () {
                        element.remove();
                    }, lifetimeAfterFadeOut);
                },
                info: function (msg) {
                    var element = $('<div class="alert alert-info alert-dismissible fade show" role="alert"> \
                                        '+ msg + ' \
                                        <button type= "button" class="close" data-dismiss="alert" aria-label="Close"> \
                                        <span aria-hidden="true">&times;</span> \
                                        </button> \
                                        </div>');
                    element.appendTo('#alertrContainer');
                    window.setTimeout(function () {
                        element.removeClass('show');
                    }, alertDuration);
                    window.setTimeout(function () {
                        element.remove();
                    }, lifetimeAfterFadeOut);
                }
            };

            return service;
        });
})();