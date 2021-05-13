var whitelist = []


var input = document.querySelector('input[name=tags]'),
    tagify = new Tagify(input, {
        pattern: /^.{0,20}$/,
        delimiters: ",| ",
        keepInvalidTags: true,
        editTags: 1,
        maxTags: 6,
        whitelist: whitelist,
        transformTag: transformTag,
        backspace: "edit",
        placeholder: "Type something",
        dropdown: {
            enabled: 1,
            fuzzySearch: false,
            position: 'text',
            caseSensitive: true,
        },
        templates: {
            dropdownItemNoMatch: function (data) {
                return `<div class='${this.settings.classNames.dropdownItem}' tabindex="0" role="option">
                    No suggestion found for: <strong>${data.value}</strong>
                </div>`
            }
        }
    })

function getRandomColor() {
    function rand(min, max) {
        return min + Math.random() * (max - min);
    }

    var h = rand(1, 360) | 0,
        s = rand(40, 70) | 0,
        l = rand(65, 72) | 0;

    return 'hsl(' + h + ',' + s + '%,' + l + '%)';
}

function transformTag(tagData) {
    tagData.style = "--tag-bg:" + getRandomColor();
}

