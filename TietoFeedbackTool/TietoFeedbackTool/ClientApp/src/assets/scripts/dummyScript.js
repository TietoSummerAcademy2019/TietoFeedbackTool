function surveySetup() {
  var survey;
  if (document.getElementsByName("new-answer").length == 0) {
    survey = {
      answer: document.getElementById('answer'),
      questionId: document.getElementById('answer').getAttribute("data-id"),
      submit: document.getElementById('survey-submit')
    };
  } else {
    survey = {
      questionId: document.getElementById('answer').getAttribute("data-id"),
      submit: document.getElementById('survey-submit')
    };
  }

  survey.submit.addEventListener('click', () => {
    var request = new XMLHttpRequest();

    var requestData;
    if (document.getElementsByName("new-answer").length == 0) {
      requestData = {
        answer: `${survey.answer.value}`,
        questionId: `${survey.questionId}`
      };
    } else {
      if (document.querySelector('input[name="new-answer"]:checked') != null) {
        requestData = {
          rating: `${document.querySelector('input[name="new-answer"]:checked').value}`,
          questionId: `${survey.questionId}`
        };
      }
    }

    var jsonData = JSON.stringify(requestData);

    var link = 'https://localhost:44350/api/Answer/open';
    request.open('post', link);
    request.setRequestHeader('Content-type', 'application/json');

    request.send(jsonData);
    checkAnswer();
  });
}

function addCSS(isBottom) {
  var linkNode = document.createElement("link");
  linkNode.setAttribute("rel", "stylesheet");
  linkNode.setAttribute("type", "text/css");
  linkNode.setAttribute("href", "https://localhost:44350/api/survey/getstyle/" + isBottom);
  document.head.appendChild(linkNode);
}
function checkDomain() {
  var apiLink = "https://localhost:44350/api/survey/getsurvey/" + key + "/" + currentDomain;
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function () {
    if (this.readyState == 4 && this.status == 200) {
      var HTMLnode = document.createElement("div");
      HTMLnode.innerHTML = this.responseText;
      document.body.appendChild(HTMLnode);
      addCSS(document.getElementById("feedback-main").getAttribute("data-isBottom"))
      surveySetup();
    }
  };
  xhttp.open("GET", apiLink, true);
  xhttp.send();
}

function changeHtmlContent() {
  document.getElementById('answer-body').style.display = 'none';
  document.getElementById('success-message').style.display = 'inline';
  setTimeout(function () {
    closeTool();
  }, 1000); //delay is in milliseconds 
}

function closeTool() {
  document.getElementsByClassName('feedback')[0].style.opacity = 0;
  setTimeout(function () {
    document.getElementsByClassName('feedback')[0].style.display = 'none';
  }, 2000);
}

window.addEventListener('load', () => {
  checkDomain();
});

function changeOpacity() {
  if (document.getElementsByClassName('img-exit')[0].style.opacity == 0) {
    document.getElementsByClassName('img-exit')[0].style.opacity = 1;
  } else {
    document.getElementsByClassName('img-exit')[0].style.opacity = 0;
  }
}

function checkAnswer() {
  if (isEmptyOrSpaces(document.getElementById('answer').value)) {
    document.getElementById('answer').style.backgroundColor = "#ffedf1";
    document.getElementById('answer').style.borderColor = "#d9135d";
    document.getElementById('need').style.display = 'inline';
  } else {
    changeHtmlContent();
  }
}

function isEmptyOrSpaces(str) {
  if (document.getElementsByName("new-answer").length == 0) {
    return str === null || str.match(/^\s* *$/) !== null;
  } else {
    if (document.querySelector('input[name="new-answer"]:checked') == null) {
      return true;
    } else {
      return false;
    }
  }
}