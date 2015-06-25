!function ($) {
    $(function () {
        // Start of Carousel
        $('#homeCarousel').carousel({
            interval: 4000,
            pause: "false"
        });

        $('#playButton').click(function () {
            if ($('#playButton').hasClass('is-play')) {
                $('#homeCarousel').carousel('cycle');
                $('#playButton').toggleClass('is-paused is-play');
                $('#playButton span').toggleClass('glyphicon-pause glyphicon-play');
            } else if ($('#playButton').hasClass('is-paused')) {
                $('#homeCarousel').carousel('pause');
                $('#playButton').toggleClass('is-play is-paused');
                $('#playButton span').toggleClass('glyphicon-play glyphicon-pause');
            }
        });

        $('#nextButton').click(function () {
            $('#homeCarousel').carousel('next');
        });

        $('#prevButton').click(function () {
            $('#homeCarousel').carousel('prev');
        });
        // End of Carousel

        // Setup drop down menu
        $('.dropdown-toggle-signup, .dropdown-toggle-login, .dropdown-toggle-search').dropdown();

        // Fix input element click problem
        $('.dropdown-menu input, .dropdown-menu label').click(function (e) {
            e.stopPropagation();
        });
    })
}(window.jQuery)