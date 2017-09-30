var BookEditorModule = (function (module) {

    module.ModalContentUrl = '/BookEditor/Load';
	module.ModalDialogId = 'idBookBox';
	module.BookManagerUrl = '/api/BooksStorageManager';
    module.BookItemIdPrefix = '';

    var formatErrorMessage = function (info, errorMessages) {
        var message = info;
        if (typeof (errorMessages)=='object')
            message += '\n' + errorMessages.join('\n');
        return message;
    }

	module.InitEvents = function () {
		
		var dialog = $("#" + module.ModalDialogId);
		dialog.on('shown.bs.modal', module.InitContent);


		$("#idTabStorage").on('click', "tbody tr td .edit-button", module.ShowModal);

		$("#" + module.ModalDialogId + ' .btn-default').on('click', module.Save);

	}
	module.InitContent = function (event) {
	    var bookId = parseInt($(event.target).data('bookId'));

	    var url = module.ModalContentUrl;
	    if (!isNaN(bookId))
	        url+='?bookId='+bookId;
	    $("#" + module.ModalDialogId + ' .modal-body').load(url, function () {
	        $.validator.unobtrusive.parse($("#" + module.ModalDialogId + " form"));
	        $("#" + module.ModalDialogId + " input[name='ISBN']").mask("999-9-99-999999-9");
             $("#" +module.ModalDialogId + " input[name='PublishDate']").mask("99.99.9999");

	        FileModule.InitUploadControls(function() {
	            $("#" + module.ModalDialogId + " button").prop("disabled", true);
	        }, function(fileName) {
	            $("#" + module.ModalDialogId + " button").prop("disabled", false);
	            $("input[name='BookFileName']").val(fileName);
	        });
	    
			$("#" + module.ModalDialogId).modal('show');
		});

		
	}

	module.ShowModal = function (event) {
	    
	    var dialog = $("#" + module.ModalDialogId);
	    var bookId = parseInt($(event.currentTarget).data("bookId"));
	    dialog.data("bookId", bookId);
	    dialog.modal('show');
	}
	module.Save = function(event) {
	    $('#' + module.ModalDialogId + " form[id='idSaveBook']").submit();
        
    }
    module.SuccessSave=  function(data) {
        if (typeof (data) == 'object') {
            if (data.IsSuccess) {
                var dialog = $("#" + module.ModalDialogId);
                
                dialog.data("bookId", '');
                dialog.modal('hide');

                var bookId = parseInt(data.DataResult.BookId);
                var url = '/home/bookitem?bookid=' + bookId;
                
                
                $.ajax({
                    method: 'GET',
                    url: url,
                    cache: false,
                    contentType: 'html',
                    traditional: true
                })
                .done(function (data) {
                        $("#" + module.BookItemIdPrefix + bookId).replaceWith(data);
                    })
                .fail(function (data) {
                    alert('Ошибка при загрузки книги. ');
                });
            } else {
                alert(formatErrorMessage("Ошибка при обновлении книги !", data.ErrorMessages));
            }
        }
    }
    module.FailSave = function(data) {
        if (typeof (data) == 'object') {
            alert(formatErrorMessage("Ошибка при обновлении книги !", data.responseJSON.ErrorMessages));
        }
    }

    
	return module;
}(BookEditorModule || {}));