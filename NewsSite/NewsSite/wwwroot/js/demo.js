﻿$(window).on('load', function () {
    $.ajax({
        url: 'user/Users',
        method: 'GET',
        data: {

        }
    })

        .done(function (result) {
            console.log("Success!", result);

            let contentString = "";
            $.each(result, function (index, users) {
                contentString += '<option value="' + users.email + '">' + users.email + '</option >'

            });
            $("#user").html(contentString);

        })

        .fail(function (xhr, status, error) {


            console.log("Error", xhr, status, error);

        });
});

$("#recreate").click(function () {

    $.ajax({
        url: 'user/Empty',
        method: 'GET',
        data: {

        }
    })

        .done(function (result) {
            console.log("Success!", result);


        })

        .fail(function (xhr, status, error) {


            console.log("Error", xhr, status, error);

        });
});

$("#logIn").click(function () {
    let email = $("#user").val();
    $.ajax({

        url: 'user/login',
        method: 'GET',
        data: {
            email: email

        }
    })

        .done(function (result) {
            console.log("Success!", result);


        })

        .fail(function (xhr, status, error) {


            console.log("Error", xhr, status, error);

        });
});

$("#isSport").click(function () {

    $.ajax({

        url: 'check/Sport',
        method: 'GET',
        data: {


        }
    })

        .done(function (result) {
            console.log("Success!", result);


        })

        .fail(function (xhr, status, error) {


            console.log("Error", xhr, status, error);

        });
});

$("#isCulture").click(function () {

    $.ajax({

        url: 'check/Culture',
        method: 'GET',
        data: {


        }
    })

        .done(function (result) {
            console.log("Success!", result);


        })

        .fail(function (xhr, status, error) {


            console.log("Error", xhr, status, error);

        });
});

$("#isOpen").click(function () {

    $.ajax({

        url: 'check/OpenNews',
        method: 'GET',
        data: {


        }
    })

        .done(function (result) {
            console.log("Success!", result);


        })

        .fail(function (xhr, status, error) {


            console.log("Error", xhr, status, error);

        });
});

$("#isHidden").click(function () {

    $.ajax({

        url: 'check/HiddenNews',
        method: 'GET',
        data: {


        }
    })

        .done(function (result) {
            console.log("Success!", result);


        })

        .fail(function (xhr, status, error) {


            console.log("Error", xhr, status, error);

        });
});

$("#isHidden20").click(function () {

    $.ajax({

        url: 'check/HiddenAgeNews',
        method: 'GET',
        data: {


        }
    })

        .done(function (result) {
            console.log("Success!", result);


        })

        .fail(function (xhr, status, error) {


            console.log("Error", xhr, status, error);

        });
});

$("#usersAndClaims").click(function () {

    $.ajax({

        url: 'user/usersAndClaims',
        method: 'GET',
        data: {


        }
    })

        .done(function (result) {
            console.log("Success!", result);


        })

        .fail(function (xhr, status, error) {


            console.log("Error", xhr, status, error);

        });
});

