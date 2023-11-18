import { Component } from '@angular/core';
import { Cours } from 'src/app/models/cours.model';
import { CoursService } from 'src/app/services/cours.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ajout-cours',
  templateUrl: './ajout-cours.component.html',
  styleUrls: ['./ajout-cours.component.css']
})
export class AjoutCoursComponent {

  cours:Cours={
    module: '',
    professeur: '',
    duree: '',
    prix: ''
  }

  constructor( private coursservice:CoursService,private router:Router) {}

  saveCours():void{
    const data={
      module: this.cours.module,
      professeur: this.cours.professeur,
      duree: this.cours.duree,
      prix: this.cours.prix
    }

    this.coursservice.AjouterCours(data).subscribe({
      next:()=>console.log("Ajout fait !"),
      error:(e)=>console.error(e),
      complete:()=>this.router.navigate(['/cours'])
    })


  }

}
