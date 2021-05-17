var Bonus_Types = {
    Edit: 'edit',
    Read: 'read',
    User : 'user',
};

function setup() {
}

let bonusMap = new Map();

class Bonus {
    constructor(id, title, price) {
        this.bcontainer = document.getElementById('bonusContainer');
        this.maindiv = createDiv('').addClass('col-md-4 mb-5').addClass(id).parent(this.bcontainer).id(id);
        this.card = createDiv('').addClass('card h-100').parent(this.maindiv);
        this.cardbody = createDiv('').addClass('card-body').parent(this.card);
        this.title = createElement('h2').addClass('card-title notranslate').html(title).parent(this.cardbody);
        this.priceTilte = createElement('h4').html('Price: $').parent(this.cardbody).attribute("style", "display: inline;");
        this.priceHtml = createElement('h4').addClass('card-price notranslate').html(price).attribute("style", "display: inline;").parent(this.cardbody);
        this.tooldiv = createDiv('').addClass('card-footer text-center').parent(this.card);      
    }
}


class EditBonus extends Bonus {
    constructor(newBonus) {
        super(newBonus.Id, newBonus.Title, newBonus.Price);
        this.editbtn = createButton('Edit').addClass('editbtn btn-warning').parent(this.tooldiv);
        this.delbtn = createButton('Delete').addClass('delbtn btn-danger').parent(this.tooldiv);
        this.delbtn.elt.addEventListener('click', () => this.deteleBonus(), false);
        this.editbtn.elt.addEventListener('click', () => this.editBonus(), false);
    }

    deteleBonus() {
        $.post('/Bonus/DeleteBonus', { '': this.maindiv.elt.id }, (response) => {
            if (response) this.maindiv.remove();
            else kendo.alert('This bonus bought! Failed operation!')
        });
    }

    editBonus() {
        select('.bns-m-title').id(this.maindiv.elt.id);
        select('#createBonus').elt.style.display = "none"
        select('#updateBonus').elt.removeAttribute('style')
        select('#bonusTitle').elt.value = this.title.elt.innerHTML;
        select('#bonusPrice').elt.value = this.priceHtml.elt.innerHTML;
        $('#modalBonus').modal();
    }

    editField(bonus) {
        this.title.elt.innerHTML = bonus.Title;
        this.priceHtml.elt.innerHTML =bonus.Price;
    }
}

class ReadOnlyBonus extends Bonus {
    constructor(newBonus) {
        super(newBonus.Id, newBonus.Title, newBonus.Price);
        this.donatebtn = createButton('Donate').addClass('btn btn-warning').parent(this.tooldiv);
        this.donatebtn.elt.addEventListener('click', () => this.donate(), false)
    }

    donate() {
        if (curruser == null) $('#logregmodal').modal();
        else {
            select('#userbonusTitle').html(this.title.elt.innerHTML);
            select('#userbonusPrice').html(this.priceHtml.elt.innerHTML);
            select('.modal-header').id(this.maindiv.elt.id);
            $('#modalUserBonus').modal();
        }
    }
}

class UserBonus extends Bonus {
    constructor(newBonus) {
        super(newBonus.Id, newBonus.Title, newBonus.Price);
        this.cmpTitle = createElement('h5').addClass('notranslate').html('Company: ' + newBonus.cmpTitle).parent(this.tooldiv);
    }
}


function sendBonus(mode, newBonus) {
    let bonus
    switch (mode) {
        case Bonus_Types.Edit:
            bonus = new EditBonus(newBonus)
            break;
        case Bonus_Types.Read:
            bonus = new ReadOnlyBonus(newBonus)
            break;
        case Bonus_Types.User:
            bonus = new UserBonus(newBonus)
            break;
    }

    bonusMap.set(newBonus.Id, bonus);
}
