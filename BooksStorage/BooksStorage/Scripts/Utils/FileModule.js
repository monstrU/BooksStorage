﻿var FileModule = (function (module) {

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

    module.UploadFile = function () {
        var formData = new FormData();

      
        var file = $('#file')[0];

        formData.append("file", file.files[0]);

        var urlUpload = "/api/file/upload";
      
        $.ajax({
            url: urlUpload,
            data: formData,
            cache: false,
            contentType: false,
            enctype: 'multipart/form-data',
            processData: false,
            method: 'POST',

            success: function (data) {
                
                alert('Woot!');
                return false;
            },
            error: function () {
                alert('Ошибка во время загрузки файлов.');
                return false;
            },
            done : function() {
                alert('done');
            }
        });
    }


    return module;
}(FileModule || {}));