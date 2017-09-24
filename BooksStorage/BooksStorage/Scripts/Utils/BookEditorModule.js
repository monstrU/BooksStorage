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

		//var editButtons = $("#idTabStorage tbody tr td .edit-button");
	    //editButtons.on('click', module.ShowModal);
		$("#idTabStorage").on('click', "tbody tr td .edit-button", module.ShowModal);

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
        $('#' + module.ModalDialogId + " form").submit();
        
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
                .fail(function () {
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
	module.UploadFile = function() {
	    var formData = new FormData();

	    // We'll grab our file upload form element (there's only one, hence [0]).
	    var file = $('#file')[0];

	    // If this example we'll just grab the one file (and hope there's at least one).
	    formData.append("file", file.files[0]);

	    var urlUpload = "/api/file/upload";
	    //var urlUpload = "/bookeditor/save";
	    $.ajax({
	        url: urlUpload, 
	        data: formData, 
	        cache: false,
	        contentType: false,
	        enctype: 'multipart/form-data',
	        processData: false,
            method: 'POST',
	        type: 'POST',

	        done: function() {
	            // Success!
	            alert('Woot!');
	        },
	        fail:function(){
	        
	    }
	});
	}
	return module;
}(BookEditorModule || {}));