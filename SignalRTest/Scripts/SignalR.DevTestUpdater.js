// Crockford's supplant method (poor man's templating)
if (!String.prototype.supplant) {
    String.prototype.supplant = function (o) {
        return this.replace(/{([^{}]*)}/g,
            function (a, b) {
                var r = o[b];
                return typeof r === 'string' || typeof r === 'number' ? r : a;
            }
        );
    };
}

$(function () {

    var hub = $.connection.devTestHub;
    var tblDevTestsBody = $('#tblDevTests').find('tbody');
    var rowTemplate = '<tr><td>{CampaignName}</td><td>{Date}</td><td>{Clicks}</td><td>{Conversions}</td><td>{Impressions}</td><td>{AffiliateName}</td></tr>';

    function init() {
        return hub.server.getAllDevTests().done(function (devTests) {
            debugger;
            tblDevTestsBody.empty();
            $.each(devTests, function () {
                debugger;
                tblDevTestsBody.append(rowTemplate.supplant(this));
            });
        });
    }

    $.extend(hub.client, {
        refresh: function (devTests) {
            debugger;
            tblDevTestsBody.empty();
            $.each(devTests, function () {
                debugger;
                tblDevTestsBody.append(rowTemplate.supplant(this));
            });
        }
    });

    $.connection.hub.start()
        .then(init)
        .done(function (state) {
            debugger;
            hub.server.startUpdatingClients();
        });
});