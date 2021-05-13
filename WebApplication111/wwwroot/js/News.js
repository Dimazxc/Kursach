let emtpyUrl = 'https://mizez.com/custom/mizez/img/general/no-image-available.png'

let newsmap = new Map();

class News {
    constructor(id) {
        this.ncontainer = document.getElementById('newsContainer');
        this.mainDiv = createDiv('').addClass('card mb-3').addClass(id).attribute('style', 'width: 640px').id(id).parent(this.ncontainer);
        this.row = createDiv('').addClass('row g-0').parent(this.mainDiv);
    }

    tall(title, content) {
        this.cardbody = createDiv('').addClass('card-body').parent(this.col);
        this.title = createElement('h3').addClass('companyTitle notranslate').attribute('disabled', 'disabled').html(title).parent(this.cardbody);
        this.content = createElement('p').html(content).addClass('companyText').attribute('disabled', 'disabled').parent(this.cardbody);
        this.butGroup = createDiv().addClass('btn-group float-right').attribute('role', 'group').parent(this.cardbody);
    }

    edittool() {
        this.editbtn = createButton('Edit').addClass('btn-warning').parent(this.butGroup);
        this.delbtn = createButton('Delete').addClass('btn-danger').parent(this.butGroup);
        this.delbtn.elt.addEventListener('click', () => this.deteleNews(), false);
        this.editbtn.elt.addEventListener('click', () => this.editNews(), false);
    }

    deteleNews() {
        $.post('/News/DeleteNews', { '': this.mainDiv.elt.id }, () => {
            this.mainDiv.remove();
        })
    }

    editSetting() {
        select('.nws-m-title').id(this.mainDiv.elt.id);
        select('#createNews').elt.style.display = "none"
        select('#updateNews').elt.removeAttribute('style')
        select('#newsTitle').elt.value = this.title.elt.innerHTML;
        select('#newsContent').elt.value = this.content.elt.innerHTML;
    }

}

class ImageNews extends News {
    constructor(id, title, content, imageUrl, mode) {
        super(id);
        this.imageDiv = createDiv('').addClass('col-md-5 text-center').parent(this.row);
        this.image = createImg(imageUrl).addClass('newsImg img-responsive rounded product-image').parent(this.imageDiv);
        this.col = createDiv('').addClass('col-md-7 mt-1').parent(this.row);
        this.tall(title, content)
        if (mode == Bonus_Types.Edit) this.edittool();
    }

    editNews() {
        this.editSetting();
        select('#newsImage').elt.removeAttribute('style');
        select('#newsImage').elt.src = this.image.elt.src;
        $('#modalNews').modal();
    }

    editField(updateNews) {
        this.title.elt.innerHTML = updateNews.title;
        this.content.elt.innerHTML = updateNews.content;
        this.image.elt.src = updateNews.imageurl;
    }
}

class TextNews extends News {
    constructor(id, title, content, mode) {
        super(id);
        this.col = createDiv('').addClass('col-md-12 mt-1').parent(this.row);
        this.tall(title, content);
        console.log(mode)
        if (mode == Bonus_Types.Edit) this.edittool();
    }

    editNews() {
        this.editSetting();
        select('#newsImage').hide();
        $('#modalNews').modal();
    }

    editField(updateNews) {
        this.title.elt.innerHTML = updateNews.title;
        this.content.elt.innerHTML = updateNews.content;
    }
}

function sendNews(id, title, content, imageUrl, mode) {
    let news;
    if (imageUrl == emtpyUrl) news = new TextNews(id, title, content, mode)
    else news = new ImageNews(id, title, content, imageUrl, mode)
    newsmap.set(id, news);
}

function setup() {
}