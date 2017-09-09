var BookEditorModule = (function (module) {

	module.ModalContentUrl = '/BookEditor/Load';
	module.ModalDialogId = 'idBookBox';
	

	var modalSuffix = '.modal-dialog .modal-content .modal-body';

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
		$("#" + module.ModalDialogId+ ' .modal-body' ).load(url, function() {
			$("#" + module.ModalDialogId).modal('show');
		});

		
	}

	module.ShowModal = function (event) {
	    
	    var dialog = $("#" + module.ModalDialogId);
	    var bookId = parseInt($(event.currentTarget).data("bookId"));
	    dialog.data("bookId", bookId);
	    dialog.modal('show');
	}
	module.Save = function (event) {
	    alert('save');
	}
	return module;
}(BookEditorModule || {}));