function getReportStudent(studentId) {
    $.ajax({
        type: "GET",
        url: "/Relatorio/StudentsReports/?questId=" + studentId,
        success: function (result) {
            var values = JSON.parse(result);
            document.getElementById("tableResultStudent").innerHTML = "";
            values.forEach(printReport);
            $("#ResultStudentCard").display = "block";
        }
    });
}

function printReport(item) {

    var card = document.getElementById("ResultStudentCard").innerHTML;
    card = card.replace(/_StudentName_/g, item.studentName);
    card = card.replace(/_RightAverage_/g, item.rightAverage);
    card = card.replace(/_WrongAverage_/g, item.wrongAverage);

    var timeArray = item.timeSpent.substring(0, 8).split(":");
    var timeText = timeArray[0] + ":" + timeArray[1] + ":" + timeArray[2];

    card = card.replace(/_TimeSpent_/g, timeText);

    document.getElementById("tableResultStudent").insertAdjacentHTML("beforeend", card);

}