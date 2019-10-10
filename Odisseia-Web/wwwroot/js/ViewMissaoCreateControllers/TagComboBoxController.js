var tagArray = ['{"id": 1,"name": "A"}'];

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

            row = row.replace(/_Id1_/g, idQ);
            row = row.replace(/_Id_/g, obj.id);
            row = row.replace(/_Name_/g, obj.name);
            result += row;
        }

        hideTags(list);
        list.innerHTML = result;
        showTags(list);
    }
}

function searchTags(id) {
    var list = document.getElementById(id + "TagComboBoxList");
    var input = document.getElementById(id + "TagComboBox");

    if ((input.value.length % 3 === 0 && input.value.length > 0) || input.value.length == 1) {

        tagArray = [];
        //Comando na API
        tagArray.push('{"id": 1,"name": "A"}');
        tagArray.push('{"id": 2,"name": "C"}');
        tagArray.push('{"id": 3,"name": "D"}');
        tagArray.push('{"id": 4,"name": "E"}');
        tagArray.push('{"id": 5,"name": "F"}');
        listTags(list);
    }
}

function selectTag(id, idQ) {
    for (i = 0; i < tagArray.length; i++) {
        if (tagArray[i].id == id) {
            document.getElementById(idQ + "Tags").insertAdjacentHTML("beforeend", tagArray[i].name);
        }
    }
    hideTags(idQ);
}