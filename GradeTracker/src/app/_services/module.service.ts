import { Goal } from './../_models/goal';
import { Observable, map } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable} from '@angular/core';
import { Module } from '../_models/module';

@Injectable({
  providedIn: 'root'
})
export class ModuleService {

  
  constructor(private http: HttpClient) { }
  
  getAll() {
    return this.http.get('https://localhost:7290/api/Module/getAll')
  }
  getById(id: number): Observable<Module> {
    return this.http.get('https://localhost:7290/api/Module/getById' + id).pipe(
      map((module: Module) => module)
    )
  }

  update(module: Module): Observable<Module> {
    return this.http.put('https://localhost:7290/api/Module/update?id=' + module.id, module )
  }

  setGoal(goal : Goal): Observable<Goal> {
    return this.http.put('https://localhost:7290/api/Module/setGoal?id=' + goal.id, goal)
  }

}
