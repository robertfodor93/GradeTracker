import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, tap, switchMap } from 'rxjs/operators';
import {User} from '../_models/user'
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable, of } from 'rxjs';

export interface LoginForm {
  username: string;
  password: string;
}

export const JWT_NAME = 'token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private authenticated = new BehaviorSubject<boolean>(false);

  get checkAuthentication() {
    return this.authenticated.asObservable();
  }

  constructor(private http : HttpClient, private jwtHelper : JwtHelperService, private router : Router) { }

  login(loginForm: LoginForm) {  

    return this.http.post<any>('https://localhost:7290/api/Auth/login', {username: loginForm.username, password: loginForm.password}).pipe(
      map((token) => {
        console.log('token' + token.token);
        localStorage.setItem(JWT_NAME, token.token);
        return token;
      })
    )
  }

  logout() {
    localStorage.removeItem(JWT_NAME);
    this.router.navigate(['/login'])
  }

  register(user: User) {
    return this.http.post<any>('https://localhost:7290/api/Auth/register', user);
  }

  isAuthenticated(): boolean {
    const token = JSON.stringify(localStorage.getItem(JWT_NAME));
    if(!this.jwtHelper.isTokenExpired(token)) {
      this.authenticated.next(true);
      return true;
    }
    return false;
  }

  getUserId(): Observable<number>{
    return of(JSON.stringify(localStorage.getItem(JWT_NAME))).pipe(
      switchMap((jwt) => of(this.jwtHelper.decodeToken(jwt)).pipe(
        map((jwt : any) => jwt.user.id)
      )
    ));
  }
}
