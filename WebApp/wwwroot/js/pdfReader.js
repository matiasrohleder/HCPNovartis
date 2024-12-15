$(document).ready(function () {
    $('#uploadForm').on('submit', function (e) {
        e.preventDefault();
        
        var formData = new FormData();
        var fileInput = $('#pdfFile')[0];
        formData.append('file', fileInput.files[0]);

        $.ajax({
            url: '/PdfRead/Scan',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response.success) {
                    var result = JSON.parse(response.data);
                    $('#extractedText').text(result.extractedText);
                    $('#result').show();
                } else {
                    alert('Error: ' + response.message);
                }
            },
            error: function () {
                alert('Error processing the file');
            }
        });
    });
});