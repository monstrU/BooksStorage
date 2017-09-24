var FileModule = (function (module) {

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

            done: function () {
                // Success!
                alert('Woot!');
            },
            fail: function () {

            }
        });
    }


    return module;
}(FileModule || {}));