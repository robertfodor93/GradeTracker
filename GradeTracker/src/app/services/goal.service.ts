import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


export interface Goal {
  Id: number;
  name: string;
  teacher: string;
  goal: number;
  needed: number;
}

@Injectable({
  providedIn: 'root'
})

export class GoalService {

  private url = 'https://localhost:7290/api/module/getAll';
  
   
  constructor(private http: HttpClient) { }
  
  getGoals(){
    return this.http.get(this.url);
  }
}
