var MyPersonalShortner = function () {

	this.init = function () {
		$('#shortner-form').on('submit', function (event) {
			event.preventDefault();
			shortenUrl($('#shortner-form').valid(), $(this).attr('action'), $(this).find('#Url').val());
		});
	};

	function shortenUrl(formValid, action, url) {
		if (formValid) {
			$.post(action, { Url: url })
					.success(HandleShortenSuccess)
					.error(HandleShortenFailure);
		}
	}

	function HandleShortenSuccess(result) {
		SetupSuccessMessage(result.Url);
		ShowSuccessMessage();
	}

	function SetupSuccessMessage(url) {
		$('#success-message').remove();
		var successMessage = CreateMessageContainer('success-message', 'alert-success', url);
		$('#main').append(successMessage);
	}

	function ShowSuccessMessage() {
		$('#success-message').fadeIn('slow');
		HideErrorMessage();
	}

	function HandleShortenFailure(data) {
		var result = JSON.parse(data.responseText);
		SetupErrorMessage(result, data.statusText);
		ShowErrorMessage();
	}

	function SetupErrorMessage(result, title) {
		$('#error-message').remove();
		var errorMessage = CreateMessageContainer('error-message', 'alert-error', title);
		CreateErrorMessages(errorMessage, result.Errors);
		$('#main').append(errorMessage);
	}

	function CreateErrorMessages(errorContainer, messages) {
		var ul = $('<ul></ul>');
		$.each(messages, function (index, value) {
			var li = $('<li></li>').append(value);
			li.appendTo(ul);
		});
		errorContainer.append(ul);
	}

	function ShowErrorMessage() {
		$('#error-message').slideDown();
		HideSuccessMessage();
	}

	function HideErrorMessage() {
		$('#error-message').hide();
	}

	function HideSuccessMessage() {
		$('#success-message').hide();
	}

	function CreateMessageContainer(id, cssClass, title) {
		var container = $('<div></div>').attr('id', id).addClass('alert').addClass(cssClass).css('display', 'none');
		var titleElement = $('<h2></h2>').append(title);
		var closeLink = $('<a class="close" data-dismiss="alert"></a>').append('×');
		container.append(closeLink).append(titleElement);
		return container;
	}
};

$(function () {
	new MyPersonalShortner().init();
});