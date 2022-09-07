import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


export interface Goal {
  averageDesiredMark: number;
}

@Injectable({
  providedIn: 'root'
})

export class GoalService {

  private urlGoals = 'https://localhost:7290/api/module/getAll';
  private urlAddGoal = 'https://localhost:7290/api/module/update?id=';


  constructor(private http: HttpClient) { }

  getGoals() {
    return this.http.get(this.urlGoals);
  }

}
