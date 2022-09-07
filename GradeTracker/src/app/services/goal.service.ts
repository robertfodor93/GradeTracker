import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


export interface Goal {
  id: number;
  educationTypes: number;
  averageDesiredMark: number;

}

@Injectable({
  providedIn: 'root'
})

export class GoalService {

  private urlGoals ='https://localhost:7290/api/EducationTypeGoal/getAll';
 

  constructor(private http: HttpClient) { }

  getGoals() {
    return this.http.get(this.urlGoals);
  }

}
