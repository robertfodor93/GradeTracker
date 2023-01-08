import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Mark } from '../_models/mark';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MarkService {


  constructor(private http: HttpClient) { }

  getAll(){
    return this.http.get('https://localhost:7290/api/Mark/getAll');
  }

  createMark(mark : Mark): Observable<Mark> {
    return this.http.post<Mark>('https://localhost:7290/api/Mark/create', mark)
  }
}
