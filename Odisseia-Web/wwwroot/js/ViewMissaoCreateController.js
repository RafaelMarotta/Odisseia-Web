var tagArray = ['{"id": 1,"name": "A"}'];
var idQ = 1
var idA = 1

function addQuestao() {
    var result = document.getElementById("QuestaoCard").innerHTML;
    result = result.replace(/_Id_/g, idQ);

    document.getElementById("tblQuestoes").insertAdjacentHTML("beforeend", result);
    idQ++;
}

function addAlternativa(idQp) {
    var result = document.getElementById("AlternativaCard").innerHTML;
    result = result.replace(/_Id_/g, idA);
    result = result.replace(/_Id1_/g, idQp);

    document.getElementById("tblQuestao" + idQp + "Alternativa").insertAdjacentHTML("beforeend", result);
    idA++;
}

function toggleId(id) {
    $(id).toggle();
}

function checkIt(idA, idQ) {
    var item = document.getElementById(idA + "Questao" + idQ + "AlternativaCorreto");
    if (item.value == "true") {
        item.value = "false";
    } else {
        item.value = "true";
    }
}

function listTags(id) {
    var input = document.getElementById(id + "TagComboBox");

    if ((input.value.length % 3 === 0 && input.value.length > 0) || input.value.length > 0) {
        cleanTags(id);
        //Comando na API
        tagArray.push('{"id": 1,"name": "A"}');
        tagArray.push('{"id": 2,"name": "C"}');
        tagArray.push('{"id": 3,"name": "D"}');
        tagArray.push('{"id": 4,"name": "E"}');
        tagArray.push('{"id": 5,"name": "F"}');
    }

    var result = "";
    var list = document.getElementById("TagCard").innerHTML;;

    if (tagArray.length > 0) {
        for (i = 0; i < tagArray.length; i++) {
            var obj = JSON.parse(tagArray[i]);

            var row = list;
            row = row.replace(/_Id1_/g, idQ);
            row = row.replace(/_Id_/g, obj.id);
            row = row.replace(/_Name_/g, obj.name);

            result += row;
        }  
    }

    document.getElementById(id + "TagComboBoxList").innerHTML = "";
    document.getElementById(id + "TagComboBoxList").insertAdjacentHTML("beforeend", result);
}

function cleanTags(id) {
    document.getElementById(id + "TagComboBoxList").innerHTML = "";
    tagArray = [];
}

function selectTag(id, idQ) {
    for (i = 0; i < tagArray.length; i++) {
        if (tagArray[i].id == id) {
            document.getElementById(idQ + "Tags").insertAdjacentHTML("beforeend", tagArray[i].name);
        }
    } 
    cleanTags(idQ);
}