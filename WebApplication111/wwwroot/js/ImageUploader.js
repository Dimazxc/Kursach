function dropimage(classDrop) {
    select('.' + classDrop).drop((file) => {
        select('.' + classDrop).elt.src  = 'https://i.gifer.com/g0R5.gif'
        var form = new FormData();
        form.append("image", file.file)
        $.ajax({
            type: 'POST',
            url: "https://api.imgbb.com/1/upload?key=0422f2bf5620caf874c9042d3e4716ca",
            data: form,
            cache: false,
            contentType: false,
            processData: false,
            success: function (data) {
                select('.' + classDrop).elt.src = data.data.url;
            }
        });
    })
}

function setup() {
}

function draw() {
}