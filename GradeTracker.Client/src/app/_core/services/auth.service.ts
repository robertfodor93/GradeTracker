import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { RegisterUser, LoginUser, AuthResponse } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private router: Router) { }

  login(user : LoginUser) {
    return this.http.post<AuthResponse>('https://localhost:7056/api/Auth/login', user);
  }

  register(user: RegisterUser) {
    return this.http.post<AuthResponse>('https://localhost:7290/api/Auth/register', user);
  }
}
