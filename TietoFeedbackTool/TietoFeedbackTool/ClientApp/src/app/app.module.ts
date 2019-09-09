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
      TranslatePipe
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      FormsModule,
      HttpClientModule,
      ClipboardModule
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