export class Transition {
  public toggleButton(buttonVisibility: boolean) {
    if (buttonVisibility == false) {
      return true;
    }
    else {
      return false;
    }
  }

  public changeHtmlContent() {
    document.getElementById('answer-body').style.display = 'none';
    document.getElementById('success-message').style.display = 'inline';
    setTimeout(function () {
      document.getElementById('tool').style.display = 'none';
    }, 3000)
  }
  public changeOpacity() {
    if (document.getElementById('exitsvg')[0].style.opacity == 0) {
      document.getElementById('exitsvg')[0].style.opacity = 1;
    } else {
      document.getElementById('exitsvg')[0].style.opacity = 0;
    }
  }
}