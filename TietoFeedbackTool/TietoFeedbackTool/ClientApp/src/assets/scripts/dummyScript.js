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

  loadImages();

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
  var apiLink = "https://localhost:44350/api/survey/getdummysurvey/";
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
  xhttp.open('post', apiLink);
  xhttp.setRequestHeader('Content-type', 'application/json');
  console.log(getQuestion());
  xhttp.send(getQuestion());
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

function markStars(x) {
  for (var c = 0; c < 5; c++) {
    document.getElementsByName("starImage")[c].classList.remove("star-select");
    document.getElementsByName("starImage")[c].classList.add("star");
  }
  for (var i = 0; i < x; i++) {
    for (var j = 0; j <= i; j++) {
      document.getElementsByName("starImage")[j].classList.add("star-select");
      document.getElementsByName("starImage")[j].classList.remove("star");
    }
  }
}

function getBackSelectedStar() {
  if (document.querySelector('input[name="new-answer"]:checked') != null) {
    markStars(document.querySelector('input[name="new-answer"]:checked').value);
  } else {
    markStars(0);
  }
}

function loadImages() {
  var node = document.getElementById('img-loader');
  var nodes1 = document.getElementById('img-loader-stage1');
  var nodes2 = document.getElementById('img-loader-stage2');
  var nodes3 = document.getElementById('img-loader-stage3');
  node.style.visibility = "hidden";
  node.style.width = "0px";
  node.style.height = "0px";
  node.style.marginLeft = "-99px";
  if (document.getElementsByClassName("star").length != 0) {
    nodes1.getElementsByTagName("img")[0].classList.add("star-select");
    nodes1.getElementsByTagName("img")[1].classList.add("star");
  } else if (document.getElementsByClassName("smile").length != 0) {
    for (var i = 1; i <= 5; i++) {
      nodes1.getElementsByTagName("img")[i - 1].classList.add("smile" + i + "s1");
      nodes2.getElementsByTagName("img")[i - 1].classList.add("smile" + i + "s2");
      nodes3.getElementsByTagName("img")[i - 1].classList.add("smile" + i + "s3");
    }
  } else if (document.getElementsByClassName("number").length != 0) {
    for (var i = 1; i <= 5; i++) {
      nodes1.getElementsByTagName("img")[i - 1].classList.add("number" + i + "s1");
      nodes2.getElementsByTagName("img")[i - 1].classList.add("number" + i + "s2");
      nodes3.getElementsByTagName("img")[i - 1].classList.add("number" + i + "s3");
    }
  }
}
