$('.fa-star').click(function () {
    var i = $(this).index();
    $('.checked').removeClass('checked');
    $('.fa-star:lt(' + (i + 1) + ')').addClass('checked');
    $('#Rating').val(i+1);
});