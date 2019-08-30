import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AnimationService {

constructor() { }

  toggle(visibility: string) : void {
    if(visibility === 'hidden') {
      visibility = 'shown'
    }
    else {
      visibility = 'hidden'
    }
  }

}
