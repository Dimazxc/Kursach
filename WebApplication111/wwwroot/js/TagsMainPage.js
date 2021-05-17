var input = document.querySelector('input[name="tags"]');

var whitelist = [];

var tagify = new Tagify(input, {
    whitelist: whitelist,
    maxTags: 100,
    dropdown: {
        maxItems: 100,
        classname: "tags-look notranslate",
        enabled: 0,
        closeOnSelect: false
    }
})