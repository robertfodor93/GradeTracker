import { Goal } from './../_models/goal';
import { Observable, map } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable} from '@angular/core';
import { Module } from '../_models/module';
import { SortDirection } from '@angular/material/sort';

@Injectable({
  providedIn: 'root'
})
export class ModuleService {

  
  constructor(private http: HttpClient) { }
  
  getAll() : Observable<Module[]> {
    return this.http.get<Module[]>('https://localhost:7290/api/Module/getAll').pipe(
      map((module : Module[]) => module)
    )
  }
  getById(id: number): Observable<Module> {
    return this.http.get<Module>('https://localhost:7290/api/Module/getById' + id).pipe(
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
