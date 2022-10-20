import { Observable, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CompetenceArea } from '../_models/competenceArea';

@Injectable({
  providedIn: 'root'
})
export class CompetenceareaService {

  constructor(private httpClient : HttpClient) { }

  getAll() : Observable<CompetenceArea[]> {
    return this.httpClient.get<CompetenceArea[]>('https://localhost:7290/api/CompetenceArea/getAll').pipe(
      map((competenceAreas : CompetenceArea[]) => competenceAreas)
  )}

  getById(id: number): Observable<CompetenceArea> {
    return this.httpClient.get<CompetenceArea>('https://localhost:7290/api/Module/getById' + id).pipe(
      map((competenceArea: CompetenceArea) => competenceArea)
  )}

  getByEducationType(educationTypeId: number): Observable<CompetenceArea[]> {
    return this.httpClient.get<CompetenceArea[]>('https://localhost:7290/api/CompetenceArea/GetByEducationType' + educationTypeId).pipe(
      map((competenceAreas: CompetenceArea[]) => competenceAreas)
    )}
}
