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

function alternativaCheckIt(idA, idQ) {
    var item = document.getElementById(idA + "Questao" + idQ + "AlternativaCorreto");
    if (item.value == "true") {
        item.value = "false";
    } else {
        item.value = "true";
    }
}
