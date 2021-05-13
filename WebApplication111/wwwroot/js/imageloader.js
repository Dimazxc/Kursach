var dropzone;
function setup() {
	dropzone = select('#dropzone')
	dropzone.dragOver(highlight)
	dropzone.dragLeave(unhighlight)
	dropzone.drop(gotfile, unhighlight)
}

function highlight() {
	dropzone.style('background-color', '#ccc')
}

function unhighlight() {
	dropzone.style('background-color', '#DB7093')
}

var imageFile;
function gotfile(file) {
    select('#dropzone').elt.src = file.data;
    imageFile = file.file
    sendPhoto()
}

function sendPhoto() {
    var form = new FormData();
    form.append("image", imageFile)
    var settings = {
        "url": "https://api.imgbb.com/1/upload?key=0422f2bf5620caf874c9042d3e4716ca",
        "method": "POST",
        "timeout": 0,
        "processData": false,
        "mimeType": "multipart/form-data",
        "contentType": false,
        "data": form
    };


    $.ajax(settings).done(function (response) {
        var jx = JSON.parse(response);
        select('#dropzone').elt.src = jx.data.url;
    });
}
