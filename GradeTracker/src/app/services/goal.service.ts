import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


export interface Goal {
  name: string;
  goal: number;
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

  setGoals(dataGoal: Goal) {
    const headers = { 'content-type': 'application/json' }
    const goal = JSON.stringify(dataGoal);
    console.log(goal)
    this.http.post('https://localhost:7290/api/module/update?id=' + 1 , goal, { 'headers': headers }).subscribe((result) => {
      console.warn("result", result);

    });
  }
}
