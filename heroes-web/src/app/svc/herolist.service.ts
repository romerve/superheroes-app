import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs'; 

@Injectable({
  providedIn: 'root'
})
export class HerolistService {

  constructor( private http: HttpClient) { }

  fetchHeros() {
    return this.http.get('/assets/hero-profile-dm.json');
  }

}