import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


export interface Exam {
  grade: number;
  weighting: number;
  date: Date;
  moduleId: number;
}

@Injectable({
  providedIn: 'root'
})
export class GradeService {
  private url = 'https://localhost:7290/api/Mark/getAll';
  
  constructor(private http: HttpClient) { }
  getGrade(){
    return this.http.get(this.url);
  }
}
