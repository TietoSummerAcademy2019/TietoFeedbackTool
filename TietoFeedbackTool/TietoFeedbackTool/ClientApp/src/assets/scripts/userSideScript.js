function surveySetup() {
  const survey = {
    answer: document.getElementById('answer'),
    surveyPuzzleId: document.getElementById('answer').getAttribute("data-id"),
    submit: document.getElementById('survey-submit')
  };

  survey.submit.addEventListener('click', () => {
    var request = new XMLHttpRequest();

    request.onload = () => {
      console.log( request.responseText );// here we will add actions that should happens after successful survey submit
    }

    var requestData = {
      answer: `${survey.answer.value}`,
      surveyPuzzleId: `${survey.surveyPuzzleId}`
    };

    var jsonData = JSON.stringify(requestData);

    var link = 'https://localhost:44350/api/answer/open';
    request.open('post', link);
    request.setRequestHeader('Content-type', 'application/json');

    request.send(jsonData);
  });
}

function addSCSS()
{
  var linkNode = document.createElement("link");
  linkNode.setAttribute("rel", "stylesheet");
  linkNode.setAttribute("type", "text/css");
  linkNode.setAttribute("href", "https://localhost:44350/api/survey/getstyle");
  document.head.appendChild(linkNode);
}
function checkDomain() {
  var key = getSurveyKey();
  var currentDomain = window.location.host;
  var apiLink = "https://localhost:44350/api/survey/getsurvey/" + key + "/" + currentDomain;
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function () {
    if (this.readyState == 4 && this.status == 200) {
      addSCSS();
      var HTMLnode = document.createElement("div");
      HTMLnode.innerHTML = this.responseText;
      document.body.appendChild(HTMLnode);
      surveySetup();
    }
  };
  xhttp.open("GET", apiLink, true);
  xhttp.send();
}

window.addEventListener('load', () => {
  checkDomain();
});