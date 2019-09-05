import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { NewQuestionComponent } from './new-question/new-question.component';
import { HttpClientModule } from '@angular/common/http';
import { DisplayDataComponent } from './display-data/display-data.component';
import { MarkingBarComponent } from './marking-bar/marking-bar.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MarkingBarSideComponent } from './marking-bar-side/marking-bar-side.component';
import { TrackingCodeGenerationComponent } from './tracking-code-generation/tracking-code-generation.component';

@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      NewQuestionComponent,
      DisplayDataComponent,
      MarkingBarComponent,
      MarkingBarSideComponent,
      TrackingCodeGenerationComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      FormsModule,
      HttpClientModule,
      MatTableModule,
      MatPaginatorModule,
      MatDialogModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }