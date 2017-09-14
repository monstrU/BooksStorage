var BookEditorModule = (function (module) {

    module.ModalContentUrl = '/BookEditor/Load';
	module.ModalDialogId = 'idBookBox';
	module.BookManagerUrl = '/api/BooksStorageManager';
    module.BookItemIdPrefix = '';
    var formatErrorMessage = function(info, errorMessages) {
        return info + '\n' + errorMessages.join('\n');
    }

	module.InitEvents = function () {
		
		var dialog = $("#" + module.ModalDialogId);
		dialog.on('shown.bs.modal', module.InitContent);

		var editButtons = $("#idTabStorage tbody tr td .edit-button");
		editButtons.on('click', module.ShowModal);

		$("#" + module.ModalDialogId + ' .btn-default').on('click', module.Save);

	}
	module.InitContent = function (event) {
	    var bookId = parseInt($(event.target).data('bookId'));

	    var url = module.ModalContentUrl;
	    if (!isNaN(bookId))
	        url+='?bookId='+bookId;
	    $("#" + module.ModalDialogId + ' .modal-body').load(url, function () {
	        $.validator.unobtrusive.parse($("#" + module.ModalDialogId+" form"));
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
        var urlSave = module.BookManagerUrl + '/SaveBook';
        $('#' + module.ModalDialogId + " form").submit();
        /* 
    */
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
                        var row = $("#" + module.BookItemIdPrefix + bookId);
                        row.replaceWith(data);
                        row.find("td .edit-button").on('click', module.ShowModal);
                    })
                .fail(function () {
                    alert('Ошибка при загрузки книги. ');
                });
                
                /*$("#" + module.BookItemIdPrefix + bookId).load(url, function() {
                    
                });*/

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