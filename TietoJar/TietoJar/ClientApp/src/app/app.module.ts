import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { NewQuestionComponent } from './new-question/new-question.component';
import { HttpClientModule } from '@angular/common/http';
import { MarkingBarComponent } from './marking-bar/marking-bar.component';
import { MarkingBarSideComponent } from './marking-bar-side/marking-bar-side.component';

@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      NewQuestionComponent,
      MarkingBarComponent,
      MarkingBarSideComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      FormsModule,
      HttpClientModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }