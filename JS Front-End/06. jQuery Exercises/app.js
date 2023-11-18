$(document).ready(function () {
    $("#reveal-button").on({
        mouseover: function () {
            $(this).css({
                "cursor": "pointer",
                "background-color": "rgb(162, 79, 49)",
            });
        },
        mouseleave: function () {
            $(this).css({
                "background-color": "coral",
            });
        },
        click: function () {
            if ($("#text").hasClass("hide-element")) {
                $("#text").removeClass("hide-element");
                $("#reveal-button").text("Hide Content");
            } else {
                console.log('Hide Content');
                $("#text").addClass("hide-element");
                $("#reveal-button").text("Reveal Content");
            }
        }
    });

    $("#question").on("mouseover", function () {
        $("#question").css("cursor", "pointer");
    });

    $("#question").on("click", function () {
        $("#answer").slideToggle(500);
    });


    $("#search").on("click", function () {
        let user = $("#github-user").val();
        $("#github-user").val("");

        $.get(`https://api.github.com/users/${user}`, function (data, status) {
            let dataFromAJAX = data;
            let statusFromAJAX = status;
            
            let userName = user;
            let followers = dataFromAJAX.followers;
            let following = dataFromAJAX.following;
            let repositories = dataFromAJAX.public_repos;

            $("#user-name").text("Name:" + userName);
            $("#followers").text("Followers:" + followers);
            $("#following").text("Following:" + following);
            $("#repositories").text("Repositories:" + repositories);
        })
    });
});