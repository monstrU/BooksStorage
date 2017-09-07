var BookEditorModule = (function (module) {

	module.ModalContentUrl = '/BookEditor/Load';
	module.ModalBodyBlockId = "#idAddressBox .modal-dialog .modal-content .modal-body";

	module.InitEvents = function () {
		var dialog = $("#idTabStorage tbody tr td .edit-button");

		dialog.on('shown.bs.modal', module.InitContent);
		dialog.on('click', module.ShowModal);


	}
	module.InitContent = function (event) {
		var bookId = parseInt($(event.currentTarget).data("bookId"));
			
		$("#" + module.ModalBodyBlockId).load(module.ModalContentUrl, function() {
			$("#idAddressBox").modal('show');
		});

		
	}

	module.ShowModal = function (event) {
		$("#idAddressBox").modal('show');
	}

	return module;
}(BookEditorModule || {}));