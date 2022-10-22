import { Goal } from './../_models/goal';
import { User } from '../_models/user';
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
      map((modules : Module[]) => modules)
    )
  }
  getById(id: number): Observable<Module> {
    return this.http.get<Module>('https://localhost:7290/api/Module/getById' + id).pipe(
      map((module: Module) => module)
    )
  }

  create(module : Module) {
    localStorage.getItem('')
    return this.http.post<Module>('https://localhost:7290/api/Module/create', module)
  }

  update(module: Module): Observable<Module> {
    return this.http.patch('https://localhost:7290/api/Module/update?id=' + module.id, module )
  }

  setGoal(goal : Goal): Observable<Goal> {
    return this.http.put('https://localhost:7290/api/Module/setGoal?id=' + goal.id, goal)
  }

}
