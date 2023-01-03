import { Observable, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EducationType } from '../_models/educationType';

@Injectable({
  providedIn: 'root'
})
export class EducationTypeService {

  constructor(private httpClient : HttpClient) { }

  getAll() : Observable<EducationType[]> {
    return this.httpClient.get<EducationType[]>('https://localhost:7290/api/EducationType/getAll').pipe(
      map((educationTypes : EducationType[]) => educationTypes)
  )}

  getById(id: number): Observable<EducationType> {
    return this.httpClient.get<EducationType>('https://localhost:7290/api/EducationType/getById' + id).pipe(
      map((educationType: EducationType) => educationType)
  )}

}
