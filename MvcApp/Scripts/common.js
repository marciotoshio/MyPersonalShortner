var common = {
    HandleShortenSuccess: function (result) {
        if (result.Success) {
            common.SetupUrl(result.Url);
            common.ShowUrl();
        }
        else {
            common.SetupError(result.Message);
            common.ShowMessage();
        }
    },

    HandleShortenFailure: function (data) {
        var result = JSON.parse(data.responseText);
        common.SetupError(result.Message);
        common.CreateMessages($('#shorten-message ul'), result.Errors);
        common.ShowMessage();
    },

    SetupUrl: function (url) {
        $('#shorten-url h2').text(url);
    },

    SetupError: function (title) {
        $('#shorten-message').addClass('error');
        $('#shorten-message h2').text(title);
    },

    CreateMessages: function (ul, messages) {
        ul.empty();
        $.each(messages, function (index, value) {
            var li = $('<li></li>').append(value);
            li.appendTo(ul);
        });
    },

    ShowUrl: function () {
        $('#shorten-url').fadeIn('slow');
        common.HideMessage();
    },

    ShowMessage: function () {
        $('#shorten-message').slideDown();
        common.HideUrl();
    },

    HideMessage: function () {
        $('#shorten-message').hide();
    },

    HideUrl: function () {
        $('#shorten-url').hide();
    }
};