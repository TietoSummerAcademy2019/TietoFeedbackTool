function surveySetup() {
  const survey = {
    answer: document.getElementByName('answerInput'),
    surveyPuzzleId: document.getElementById('questionIdInput'),
    submit: document.getElementById('surveySubmit')
  };

  survey.submit.addEventListener('click', () => {
    var request = new XMLHttpRequest();

    request.onload = () => {
      //document.getElementById('serverResponse').innerHTML = request.responseText;// here we will add actions that should happens after successful survey submit
    }

    var requestData = {
      answer: `${survey.answer.value}`,
      surveyPuzzleId: `${survey.surveyPuzzleId.value}`
    };

    var jsonData = JSON.stringify(requestData);

    var link = 'https://localhost:44350/api/survey/postanswer';
    request.open('post', link);
    request.setRequestHeader('Content-type', 'application/json');

    request.send(jsonData);
  });
}

function getSurvey() {
  var key = getSurveyKey();
  var apiLink = "api/survey/getsurvey/" + key
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function () {
    if (this.readyState == 4 && this.status == 200) {
      var node = document.createElement("div");
      node.appendChild(this.responseText);
      surveyOptions();
    }
  };
  xhttp.open("GET", apiLink, true);
  xhttp.send();
}

window.addEventListener('load', () => {
  getSurvey();
});