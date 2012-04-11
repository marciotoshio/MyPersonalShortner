var shortner = {
    HandleShortenSuccess: function (result) {
        if (result.Success) {
            shortner.SetupSuccessMessage(result.Url);
            shortner.ShowSuccessMessage();
        }
        else {
            shortner.SetupErrorMessage(result.Message);
            shortner.ShowErrorMessage();
        }
    },

    SetupSuccessMessage: function (url) {
        $('#success-message').remove();        
        var successMessage = shortner.CreateMessageContainer('success-message', 'alert-success', url);
        $('#main').append(successMessage);
    },

    ShowSuccessMessage: function () {
        $('#success-message').fadeIn('slow');
        shortner.HideErrorMessage();
    },

    HandleShortenFailure: function (data) {
        var result = JSON.parse(data.responseText);
        shortner.SetupErrorMessage(result);
        shortner.ShowErrorMessage();
    },

    SetupErrorMessage: function (result) {
        $('#error-message').remove();
        var errorMessage = shortner.CreateMessageContainer('error-message', 'alert-error', result.Message);
        shortner.CreateErrorMessages(errorMessage, result.Errors);
        $('#main').append(errorMessage);
    },

    CreateErrorMessages: function (errorContainer, messages) {
        var ul = $('<ul></ul>');
        $.each(messages, function (index, value) {
            var li = $('<li></li>').append(value);
            li.appendTo(ul);
        });
        errorContainer.append(ul);
    },

    ShowErrorMessage: function () {
        $('#error-message').slideDown();
        shortner.HideSuccessMessage();
    },

    HideErrorMessage: function () {
        $('#error-message').hide();
    },

    HideSuccessMessage: function () {
        $('#success-message').hide();
    },

    CreateMessageContainer: function (id, cssClass, title) {
        var container = $('<div></div>').attr('id', id).addClass('alert').addClass(cssClass).css('display', 'none');
        var titleElement = $('<h2></h2>').append(title);
        var closeLink = $('<a class="close" data-dismiss="alert"></a>').append('×');
        container.append(closeLink).append(titleElement);
        return container;
    }
};