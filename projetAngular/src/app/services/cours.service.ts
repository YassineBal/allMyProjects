import { Injectable } from '@angular/core';
import { Cours } from '../models/cours.model';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import { RouterTestingHarness } from '@angular/router/testing';

@Injectable({
  providedIn: 'root'
})
export class CoursService {


  baseUrl='http://10.30.40.121:3044/proj/'
  constructor(private http:HttpClient) { }

  AfficherCours():Observable<Cours[]>{
    return this.http.get<Cours[]>(`${this.baseUrl}/cours`);
  }

  AjouterCours(data:any):Observable<any>{
    return this.http.post(`${this.baseUrl}/newCour`,data);
  }

  TrouverCours(idCours:any):Observable<Cours>{
    return this.http.get<Cours>(`${this.baseUrl}/findCour/${idCours}`);
  }

  SupprimerCours(idCours:any):Observable<Cours>{
    return this.http.delete<Cours>(`${this.baseUrl}/delCour/${idCours}`)
  }

  MiseajourCours(data: any, idCours:any):Observable<any>{
    return this.http.put(`${this.baseUrl}/upCour/${idCours}`,data)
  }
}
