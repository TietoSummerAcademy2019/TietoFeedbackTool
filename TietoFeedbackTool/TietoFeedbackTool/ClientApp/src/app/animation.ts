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
  }
}