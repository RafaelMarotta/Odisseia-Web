var idT = 1;

var tagArray = ['{"name": "A", "color": "EC7063"}'];

function hideTags(list) {
    $(list).slideUp(300);
    $(list).innerHTML = "";
}

function showTags(list) {

    $(list).slideDown(300);
}

function listTags(list) {
    var result = "";
    var card = document.getElementById("TagCard").innerHTML;

    if (tagArray.length > 0) {
        for (i = 0; i < tagArray.length; i++) {

            var obj = JSON.parse(tagArray[i]);
            var row = card;

            row = row.replace(/_Id_/g, idQ);
            row = row.replace(/_Name_/g, obj.name);
            result += row;
        }

        hideTags(list);
        list.innerHTML = result;
        showTags(list);
    }
}

function searchTags(id) {
    var input = document.getElementById(id + "TagComboBox");
    var list = document.getElementById(id + "TagComboBoxList");

    if ($(input).is(":focus")) {

        if ((input.value.length % 3 === 0 && input.value.length > 0) || input.value.length == 1) {

            tagArray = [];
            //Comando na API
            tagArray.push('{"name": "A", "color": "A569BD"}');
            tagArray.push('{"name": "C", "color": "5DADE2"}');
            tagArray.push('{"name": "D", "color": "45B39D "}');
            tagArray.push('{"name": "E", "color": "F4D03F"}');
            tagArray.push('{"name": "F", "color": "#7DCEA0"}');
            listTags(list);

        }
    } else {
        hideTags(list);
    }
}

function selectTag(name, idQp) {
    var card = document.getElementById("TagBoxCard").innerHTML;
    for (i = 0; i < tagArray.length; i++) {
        var obj = JSON.parse(tagArray[i])
        if (obj.name == name) {
            $("#" + idQp + "QuestaoTags").insertAdjacentHTML("beforeend", replace(/_Name_/g, obj.name));
            break;
        }
    }
    hideTags(idQ);
}
