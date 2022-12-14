import { Observable, map } from 'rxjs';
import { EducationType } from './../_models/educationType';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EducationtypeService {

  constructor(private httpClient: HttpClient) { }
  
  getAll() : Observable<EducationType[]> {
    return this.httpClient.get<EducationType[]>('https://localhost:7290/api/EducationType/getAll').pipe(
      map((educationType : EducationType[]) => educationType)
    )}

  getById(id: number): Observable<EducationType> {
    return this.httpClient.get<EducationType>('https://localhost:7290/api/EducationType/getById' + id).pipe(
      map((educationType: EducationType) => educationType)
    )}
  
}
