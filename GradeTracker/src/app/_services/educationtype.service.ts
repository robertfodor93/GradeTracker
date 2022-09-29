import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EducationtypeService {

  private url = 'https://localhost:7290/api/EducationType/getAll';
   
  constructor(private httpClient: HttpClient) { }
  
  getEducationTypes(){
    return this.httpClient.get(this.url);
  }
  
}
