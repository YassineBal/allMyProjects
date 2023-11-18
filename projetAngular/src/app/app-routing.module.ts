import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCoursComponent } from './components/list-cours/list-cours.component';
import { AjoutCoursComponent } from './components/ajout-cours/ajout-cours.component';
import { ModifCoursComponent } from './components/modif-cours/modif-cours.component';
const routes: Routes = [
  {path:'cours' , component:ListCoursComponent},
  {path:'ajout', component:AjoutCoursComponent},
  {path:'modif/:id',component:ModifCoursComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
