import { Component , OnInit} from '@angular/core';
import { Cours } from 'src/app/models/cours.model';
import { CoursService } from 'src/app/services/cours.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-modif-cours',
  templateUrl: './modif-cours.component.html',
  styleUrls: ['./modif-cours.component.css']
})
export class ModifCoursComponent implements OnInit {

  cours:Cours={
  module: '',
  professeur: '',
  duree: '',
  prix: ''

  }


  constructor(private coursservice :CoursService, private  routes :Router,private route:ActivatedRoute){}
  ngOnInit(): void {
     this.AfficherCours();
  }

  AfficherCours(){
    this.coursservice.TrouverCours(this.route.snapshot.paramMap.get('id')).subscribe({
      next:(data)=>{
        this.cours.module=data.module,
        this.cours.professeur=data.professeur,
        this.cours.duree=data.duree
        this.cours.prix=data.prix
      },
      error:(e)=>console.error(e),
      complete:()=>console.log("Bingo !")
    })

  }

  Supprimercours():void{
    this.coursservice.SupprimerCours(this.route.snapshot.paramMap.get('id')).subscribe({
      error:(e)=>console.error(e),
      complete:()=>this.routes.navigate(['/cours'])
    })

  }

  Miseajourcours():void{
    const data={
      module:this.cours.module,
      professeur:this.cours.professeur,
      duree:this.cours.duree,
      prix:this.cours.prix
    }

    this.coursservice.MiseajourCours(data,this.route.snapshot.paramMap.get('id')).subscribe({
      next:()=>console.log('Modification reussi !'),
      error:(e)=>console.error(e),
      complete:()=>console.log(this.routes.navigate(['/cours']))
    })
  }


}
