import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { ListCoursComponent } from './components/list-cours/list-cours.component';
import { AjoutCoursComponent } from './components/ajout-cours/ajout-cours.component';
import { FormsModule } from '@angular/forms';
import { ModifCoursComponent } from './components/modif-cours/modif-cours.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    ListCoursComponent,
    AjoutCoursComponent,
    ModifCoursComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
