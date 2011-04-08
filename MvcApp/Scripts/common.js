var common = {
    HandleShortenSuccess: function (result) {
        if (result.Success) {
            $('#shorten-url h2').text(result.Url);
        }
        else {
            $('#shorten-url h2').text('error');
        }
        $('#shorten-url').fadeIn();
    }
};