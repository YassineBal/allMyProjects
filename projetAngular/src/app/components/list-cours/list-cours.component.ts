import { Component , OnInit } from '@angular/core';
import { Cours } from 'src/app/models/cours.model';
import { CoursService } from 'src/app/services/cours.service';
@Component({
  selector: 'app-list-friandise',
  templateUrl: './list-cours.component.html',
  styleUrls: ['./list-cours.component.css']
})
export class ListCoursComponent implements OnInit {

  cours:Cours[] | undefined;

  ngOnInit() : void{
     this.afficherCours();
  }

  constructor(private coursService:CoursService){}

  afficherCours(){
    this.coursService.AfficherCours().subscribe({
      next:(data)=>this.cours=(data),
      error:(e)=>console.error(e),
      complete:()=>console.log("Affichage reussi !")

    })
  }

}
