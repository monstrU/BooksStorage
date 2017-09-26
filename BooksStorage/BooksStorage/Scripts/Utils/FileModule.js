var FileModule = (function (module) {

    module.InitUploadControls = function(preAjaxCallback, fileUploaded) {
        $("#file").fileinput({
            showPreview: false,
            showUpload: false,
            showRemove: false,
            allowedFileExtensions: ["jpg", "png", "gif"],
            uploadUrl: "/api/file/upload"

        });

        $("#file").on('fileselect', function (event, previewId, index) {
            $("#file").fileinput('upload');
        });
        if (typeof (preAjaxCallback)=='function') {
            $("#file").on('filepreajax', preAjaxCallback);
        }

        
        $('#file').on('fileuploaded', function (event, data, previewId, index) {
            if (typeof (fileUploaded) == 'function' && typeof (data) == 'object') {
                if (data.response.IsSuccess===true)
                    fileUploaded(data.response.DataResult);
            }
            });
        


        $('#file').on('fileerror', function (event, data, msg) {
            alert('Ошибка во время загрузки файла!.');

        });
    }
    
    return module;
}(FileModule || {}));