var BookEditorModule = (function (module) {

	module.ModalContentUrl = '/BookEditor/LoadOne';
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
		var bookId = parseInt($(event.currentTarget).data("bookId"));
			
		$("#" + module.ModalDialogId+ ' .modal-body' ).load(module.ModalContentUrl, function() {
			$("#" + module.ModalDialogId).modal('show');
		});

		
	}

	module.ShowModal = function (event) {
		$("#" + module.ModalDialogId).modal('show');
	}
	module.Save = function (event) {
	    alert('save');
	}
	return module;
}(BookEditorModule || {}));