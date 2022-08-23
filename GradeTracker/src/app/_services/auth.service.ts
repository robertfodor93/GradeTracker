import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, tap, switchMap } from 'rxjs/operators';
import {User} from '../_models/user'
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, of } from 'rxjs';

export interface LoginForm {
  username: string;
  password: string;
}

export const jwt = 'token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  constructor(private http : HttpClient, private jwtHelper: JwtHelperService) { }

  login(loginForm: LoginForm) {  

    return this.http.post<any>('https://localhost:7290/Auth/login', {email: loginForm.username, password: loginForm.password}).pipe(
      map((token) => {
        console.log('token' + token.access_token);
        localStorage.setItem(jwt, token.access_token);
        return token;
      })
    )
  }

  logout() {
    localStorage.removeItem(jwt)
  }

  register(user: User) {
    return this.http.post<any>('https://localhost:7290/Auth/register', user);
  }

  isAuthenticated(): boolean {
    const token = JSON.stringify(localStorage.getItem(jwt));
    return !this.jwtHelper.isTokenExpired(token);
  }

  getUserId(): Observable<number>{
    return of(JSON.stringify(localStorage.getItem(jwt))).pipe(
      switchMap((jwt) => of(this.jwtHelper.decodeToken(jwt)).pipe(
        map((jwt : any) => jwt.user.id)
      )
    ));
  }
}
