
var thems = ["Education", "Electionics", "Science", "Music", "Art", "Game", "Literature"]

$(document).ready(function () {

    var cmp = new kendo.data.DataSource({
        transport: {
            read: { url: "/Company/GetCompanies", data: { 'userId': user.id }, cache: false }
        }
    });

    $('#companyED').kendoDatePicker({ format: "{0: yyyy-MM-dd}" });

    $("#companyTh").kendoDropDownList({ dataSource: thems });

    $("#gridcompany").kendoGrid({
        columns: [
            { field: "id", hidden: true, 'editable': function () { return false } },
            { field: "name", width: 100 },
            { field: "price", width: 100 },
            { field: "urlVideo", width: 150 },
            { field: "endDay", width: 100, editor: endDayPicker, type: "date", format: "{0: yyyy-MM-dd}" },
            { field: "theme", width: 100, editor: themeDropDownEditor },
            { command: "edit", width: 80 },
            { command: { text: "Delete", click: deletecompany }, width: 80 },
            { command: { text: "Open read", click: openread }, width: 80 },
            { command: { text: "Open edit", click: openedit }, width: 80 },
        ],
        editable: "popup",
        dataSource: cmp,
        pageable: true,
        sortable: true,
        navigatable: true,
        resizable: true,
        reorderable: true,
        groupable: true,
        filterable: true,
        edit: function (e) {
            this.one("save", function () {
                $.post('/Company/UpdateCompany', { '': JSON.stringify(e.model) }, function () {
                    $("#gridcompany").data("kendoGrid").dataSource.read();
                })
            });
            this.one("cancel", function () {
                $('#gridcompany').data('kendoGrid').dataSource.cancelChanges();
            });
        }
    });
});
function themeDropDownEditor(container, options) {
    $('<input required name="' + options.field + '"/>').appendTo(container).kendoDropDownList({ dataSource: thems });
}

function endDayPicker(container, options) {
    $('<input required name="' + options.field + '"/>').appendTo(container).kendoDatePicker();
}

$('[data-dismiss=modal]').on('click', function (e) {
    clearModal();
})

createCompany = function () {
    var newCompany = {
        id: window.URL.createObjectURL(new Blob([])).substring(31),
        name: select('#companyName').elt.value,
        urlvideo: select('#companyYT').elt.value,
        urlimage: select('.dropzoneCompany').elt.src,
        description: select('#companyDesc').elt.value,
        price: select('#companyPrice').elt.value,
        userId: user.id,
        tags: configureTags(),
        theme: select('#companyTh').elt.value,
        endDay: select('#companyED').elt.value
    }
    $.post('/Company/AddCompany', { '': newCompany }, function () {
        $("#gridcompany").data("kendoGrid").dataSource.read();
        clearModal();
        $("#staticBackdrop").modal('hide')
    })
}


function deletecompany(e) {
    var tr = $(e.target).closest("tr");
    var id = this.dataItem(tr).id;
    kendo.confirm("Are you sure that you want delete this company?").then(function () {
        $.post('/Company/DeleteCompany', { '': id }, function () {
            $("#gridcompany").data("kendoGrid").dataSource.read();
        });
    }, function () { });
}



(() => {
    'use strict';
    const forms = document.querySelectorAll('.modalcreate');
    Array.prototype.slice.call(forms).forEach((form) => {
        form.addEventListener('submit', (event) => {
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            } else {
                event.preventDefault();
                createCompany();
            }
            form.classList.add('was-validated');
        }, false);
    });
})();

clearModal = function () {   
    $('.tagify').children('.tagify__tag').remove()
    document.getElementById('dropzone').src = 'https://img.flaticon.com/icons/png/512/1753/1753543.png?size=1200x630f&pad=10,10,10,10&ext=png&bg=FFFFFFFF'
    $('.modalcreate').children('.form-group ').children('.form-control').val('');
}