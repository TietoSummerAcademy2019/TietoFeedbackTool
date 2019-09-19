import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewQuestionComponent } from './new-question/new-question.component';
import { DisplayDataComponent } from './display-data/display-data.component';
import { MarkingBarComponent } from './marking-bar/marking-bar.component';
import { MarkingBarSideComponent } from './marking-bar-side/marking-bar-side.component';
import { TrackingCodeGenerationComponent } from './tracking-code-generation/tracking-code-generation.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NewPageComponent } from './new-page/new-page.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent
  },
  {
    path: 'new-question',
    component: NewQuestionComponent
  },
  {
    path: 'new-question/:id',
    component: NewQuestionComponent
  },
  {
    path: 'new-page',
    component: NewPageComponent
  },
  {
    path: 'display-data/:id',
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