import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { NewQuestionComponent } from './new-question/new-question.component';
import { HttpClientModule } from '@angular/common/http';
import { DisplayDataComponent } from './display-data/display-data.component';
import { MarkingBarComponent } from './marking-bar/marking-bar.component';
import { MarkingBarSideComponent } from './marking-bar-side/marking-bar-side.component';
import { TrackingCodeGenerationComponent } from './tracking-code-generation/tracking-code-generation.component';
import { ClipboardModule } from 'ngx-clipboard';
import { TranslateService } from './translate-service/translate-service.service';
import { TranslatePipe } from './translate-service/translate.pipe';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { DeletePopupComponent } from './dashboard/delete-popup/delete-popup.component';
import { MatDialogModule } from '@angular/material';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ChartsModule } from 'ng2-charts';

export function setupTranslateFactory(
  service: TranslateService): Function {
  return () => service.use('en');
}

@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      NewQuestionComponent,
      DisplayDataComponent,
      MarkingBarComponent,
      MarkingBarSideComponent,
      TrackingCodeGenerationComponent,
      DashboardComponent,
      DeletePopupComponent,
      TranslatePipe
   ],
   entryComponents: [
     DeletePopupComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      FormsModule,
      HttpClientModule,
      ClipboardModule,
      MatSlideToggleModule,
      MatDialogModule,
      NgbModule,
      ChartsModule
   ],
   providers: [
     TranslateService,
     {
      provide: APP_INITIALIZER,
      useFactory: setupTranslateFactory,
      deps: [ TranslateService ],
      multi: true
    }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }