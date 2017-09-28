var  AuthorsModule = (function (module) {

    module.ModalContentUrl = '/AuthorEditor/Load';
    module.ModalDialogId = 'idAuthorBox';

    module.InitEvents = function () {

        var dialog = $("#" + module.ModalDialogId);
        dialog.on('shown.bs.modal', module.InitContent);


        $("#idTabStorage").on('click', "tbody tr td .edit-button", module.ShowModal);

        $("#" + module.ModalDialogId + ' .btn-default').on('click', module.Save);

    }

    module.InitContent = function (event) {
        var personId = parseInt($(event.target).data('personId'));

        var url = module.ModalContentUrl;
        if (!isNaN(personId))
            url += '?personId=' + personId;
        $("#" + module.ModalDialogId + ' .modal-body').load(url, function () {
            $.validator.unobtrusive.parse($("#" + module.ModalDialogId + " form"));

           
            $("#" + module.ModalDialogId).modal('show');
        });


    }


    module.ShowModal = function () {
        var dialog = $("#" + module.ModalDialogId);
        var personId = parseInt($(event.currentTarget).data("personId"));
        dialog.data("personId", personId);
        dialog.modal('show');
    }

    module.Save = function (data) {

    }
    return module;
}(AuthorsModule || {}));