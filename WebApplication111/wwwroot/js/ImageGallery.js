class Photo {
    constructor(newPhoto, mode) {
        this.pcontainer = document.getElementById('photosContainer');
        this.mainDiv = createDiv('').addClass('carousel-item').id(newPhoto.Id).parent(this.pcontainer);
        this.image = createImg(newPhoto.ImageUrl).parent(this.mainDiv);
        this.toolDiv = createDiv('').addClass('carousel-caption').parent(this.mainDiv);
        this.title = createElement('h3').html(newPhoto.Title).parent(this.toolDiv);
        if (mode == Bonus_Types.Edit) this.edittools();
    }

    edittools() {
        this.delbtn = createButton('Delete').addClass('btn-danger').parent(this.toolDiv);
        this.delbtn.elt.addEventListener('click', () => this.detelePhoto(), false);
    }

    detelePhoto() {
        $.ajax({
            type: 'delete',
            url: '/Gallery/DeletePhoto',
            data: { '': this.mainDiv.elt.id },
            success: () => {
                this.mainDiv.remove();
                var photos = selectAll('.carousel-item');
                if (photos.length > 0) photos[0].elt.className = 'carousel-item active';
            }
        })
    }
}

function sendPhoto(newPhoto, mode) {
    var photo = new Photo(newPhoto, mode)
}

function setup() {
}