
function setup() {
}
class Company {
    constructor(containerId, cmp, avgrate) {
        let container = select('#' + containerId);
        this.mainDiv = createDiv('').addClass('col-md-4 mb-5').parent(container).id(cmp.Id);
        this.cardDiv = createDiv('').addClass('card h-100').parent(this.mainDiv);
        this.image = createImg(cmp.UrlImage).addClass('card-img-top imgcard').parent(this.cardDiv);
        this.cardBody = createDiv('').addClass('card-body').parent(this.cardDiv);
        this.fillcardbody(cmp.Theme, cmp.Name, cmp.Description);
        this.cardFooter = createDiv('').addClass('card-footer text-muted').parent(this.cardDiv);
        this.fillfooter(avgrate);
    }

    fillcardbody(theme, title, description) {
        this.theme = createElement('h6').addClass('notranslate').html(theme).parent(this.cardBody);
        this.cardTitle = createElement('h4').addClass('card-title notranslate').html(title).parent(this.cardBody);
        this.cardText = createElement('h5').addClass('card-text notranslate').html(description).attribute('style', 'font-size:17px').parent(this.cardBody);
    }

    fillfooter(avgrate) {
        var id = window.URL.createObjectURL(new Blob([])).substring(31)
        this.rating = createInput('').parent(this.cardFooter).id(id);
        var ratingInstance =  $("#" + id).kendoRating({ value: avgrate }).data("kendoRating");
        ratingInstance.readonly(true);
    }

}

function sendCompany(containerId, cmp, avgrate) {
    let company = new Company(containerId, cmp, avgrate)
}




configureTags = function () {
    console.log(document.getElementById("companyTags").value)
    var list = JSON.parse(document.getElementById("companyTags").value);
    var tags = "";
    list.forEach(element => (tags += element.value + ";"));
    return tags;
}

