export class ButtonFadeAnimation {
  public toggle(visibility: string) {
    if(visibility === 'hidden') {
      return 'shown';
    }
    else {
      return 'hidden';
    }
  }
}