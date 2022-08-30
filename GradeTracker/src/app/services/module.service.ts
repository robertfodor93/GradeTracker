import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


export interface Subject {
  Id: number;
  name: string;
  competenceArea: string;
  teacher: string;
  averageDesiredMark: number;
  marks: number;
  showOnDashboard: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class ModuleService {

  private url = 'https://localhost:7290/api/module/getAll';
  
   
  constructor(private http: HttpClient) { }
  
  getModule(){
    return this.http.get(this.url);
  }

}
