$(function () {

    showSearchResultMessage();

    //loadWaitingList();

    //$("#newPatient").click(function () {
    //    window.location.href = "/Patient/Create";
    //});

    //$("#newArrival").click(function () {
    //    $.post("/Reception/NewArrival", {}, function (returned) {
    //        if (returned.result) {
    //            toastr.success(returned.message);
    //            loadWaitingList();
    //        }
    //    }, "json");
    //});

    //$("body").on("click", "#attendedAction", function () {
    //    attendedAction();
    //    loadWaitingList();
    //});

    //$("body").on("click", "#unattendedAction", function () {
    //    unattendedAction();
    //    loadWaitingList();
    //});
});

function onSearchPatientSuccess(data)
{
    console.log("Search Patient Success");
    showSearchResultMessage(data);
    showSearchResultRecords(data);
}

function onSearchPatientFailure()
{
    console.log("Search Patient Failure");
}

function showSearchResultMessage(data)
{
    if (!data) {
        $("#searchResultMessage").attr({
            class: "alert alert-info",
            role: "alert"
        }).html("No record to display.");
    }
    else {
        $("#searchResultMessage").attr({
            class: "alert alert-success",
            role: "alert"
        }).html(data.records.length + " records founds.");
    }
}

function showSearchResultRecords(data)
{
    if (data && data.records) {
        var containerDiv = $("#searchResultRecords");
        $(containerDiv).attr({
            class: "list-group"
        });

        $.each(data.records, function (i, item) {
            var newListItem = '<a href="#" class="list-group-item">'
             + '<h4 class="list-group-item-heading">' + item.FullName + '</h4>'
             + '<p class="list-group-item-text">' + item.PhoneNumber + '</p>'
             + '</a>';

            $(containerDiv).append(newListItem);
        });
    }
    else {
        $("#searchResultRecords").html('<a href="/Patient/Create" class="btn btn-primary"></a>');
    }
}

function loadWaitingList()
{
    $.get("/Reception/GetWaitingList", {}, function (returned) {
        if (returned.result) {
            $(".waiting-list-container").html("");

            var htmlContent = "";
            if (returned.waitingList && returned.waitingList.length > 0) {

                htmlContent += '<div class="btn-group" role="group">';

                returned.waitingList.forEach(function (item, index) {
                    if (index == 0) {
                        htmlContent += '<button type="button" class="btn btn-default"><span class="glyphicon glyphicon-menu-left" aria-hidden="true"></span> ' + item + '</button>';
                    }
                    else {
                        htmlContent += '<button type="button" class="btn btn-default">' + item + '</button>';
                    }
                });
               
                htmlContent += '</div>';
            }
            else {
                htmlContent = '<div class="alert alert-warning" role="alert">Welcome! no-one in waiting yet.</div>';
            }

            $(".waiting-list-container").html(htmlContent);
        }

        loadActionOnTokenView();
    }, "json");
}

function loadActionOnTokenView()
{
    $.get("/Reception/GetActionOnToken", {}, function (view) {

        $(".actionOnToken-container").html("");

        $(".actionOnToken-container").html(view);
    });
}

function attendedAction() {
    $.post("/Reception/Attended", {}, function (returned) {
        if (returned.result) {
            toastr.success(returned.message);
            loadWaitingList();
        }
    }, "json");
}

function unattendedAction() {
    $.post("/Reception/Unattended", {}, function (returned) {
        if (returned.result) {
            toastr.success(returned.message);
            loadWaitingList();
        }
    }, "json");
}