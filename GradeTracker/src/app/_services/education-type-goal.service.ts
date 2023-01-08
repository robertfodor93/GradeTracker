import { Observable, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EducationTypeGoal } from '../_models/educationTypeGoal';

@Injectable({
  providedIn: 'root'
})
export class EducationTypeGoalService {

  constructor(private httpClient : HttpClient) { }

  getAll() : Observable<EducationTypeGoal[]> {
    return this.httpClient.get<EducationTypeGoal[]>('https://localhost:7290/api/EducationTypeGoal/getAll').pipe(
      map((educationTypeGoals : EducationTypeGoal[]) => educationTypeGoals)
  )}

  getById(id: number): Observable<EducationTypeGoal> {
    return this.httpClient.get<EducationTypeGoal>('https://localhost:7290/api/EducationTypeGoal/getById' + id).pipe(
      map((educationTypeGoal: EducationTypeGoal) => educationTypeGoal)
  )}

  create(educationTypeGoal: EducationTypeGoal) {
    return this.httpClient.post<EducationTypeGoal>('https://localhost:7290/api/EducationTypeGoal/create', educationTypeGoal)
  }
}
