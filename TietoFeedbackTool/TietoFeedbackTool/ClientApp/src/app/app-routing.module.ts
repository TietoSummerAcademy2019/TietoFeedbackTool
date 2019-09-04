import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NewQuestionComponent } from './new-question/new-question.component';
import { DisplayDataComponent } from './display-data/display-data.component';
import { MarkingBarComponent } from './marking-bar/marking-bar.component';
import { MarkingBarSideComponent } from './marking-bar-side/marking-bar-side.component';
import { TrackingCodeGenerationComponent } from './tracking-code-generation/tracking-code-generation.component';



const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'new-question',
    component: NewQuestionComponent
  },
  {
    path: 'display-data',
    component: DisplayDataComponent
  },
  {
    path: 'marking-bar',
    component: MarkingBarComponent
  },
  {
    path: 'marking-bar-side',
    component: MarkingBarSideComponent
  },
  {
    path: 'tracking-code-generation',
    component: TrackingCodeGenerationComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }