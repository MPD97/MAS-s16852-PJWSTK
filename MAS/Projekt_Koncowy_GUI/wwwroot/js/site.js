// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var btn = document.getElementById("CheckBtn");
btn.onclick = function () {

    var selectors = document.querySelectorAll("select");
    var canRepair = true;

    selectors.forEach(element => {
        if (element.selectedIndex === 0) {
            alert("Wybierz opcję Koniecznosć wymiany!");
            canRepair = false;
            return;

        }
    });

    selectors.forEach(element => {


        if (element.selectedIndex === 1) {
            var amount = $(element).parent().parent().find("input").val();
            var identifier = $(element).parent().parent().children().first().text().trim();
            console.log(identifier + ", " + amount);


  
            jQuery.ajax({
                url: '/api/Component/' + identifier + '?amount=' + amount,
                success: function (data) {
                    console.log(identifier + ", " + data);
                    if (data === false) {
                        alert("Brak wystarczającej ilosći sztuk dla podzespołu o identyfikatorze: " + identifier);
                        canRepair = false;
                    }
                },
                async: false
            });

        }
    });
    if (canRepair === true) {
        var div = $("#ResultDiv");
        if (div.hasClass("hidden")) {
            div.removeClass("hidden");
        }

        selectors.forEach(element => {
            $(element).prop("disabled", true);
            $(element).parent().parent().find("input").prop("disabled", true);
        });
    }
};