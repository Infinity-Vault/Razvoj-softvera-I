import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';// Bitno je da napravimo importujemo komponentu koju smo exportovali u .ts fajlu
import { StudentiComponent } from './studenti/studenti.component';// Bitno je da napravimo importujemo komponentu koju smo exportovali u .ts fajlu
import { PredmetiComponent } from './predmeti/predmeti.component';
import { HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import { RouterModule} from "@angular/router";
import * as path from "path";

@NgModule({
  declarations: [
    AppComponent,
    StudentiComponent,
    PredmetiComponent

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([{path:"studenti",component:StudentiComponent},
     {path:"predmeti",component:PredmetiComponent}])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
