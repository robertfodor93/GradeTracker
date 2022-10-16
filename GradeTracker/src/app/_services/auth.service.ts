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
  private currentUser = new BehaviorSubject<any>(null);

  userId : Pick<User, "id">

  get checkAuthentication() {
    return this.authenticated.asObservable();
  }

  constructor(private http : HttpClient, private jwtHelper : JwtHelperService, private router : Router) { }

  login(user: User) {  

    return this.http.post<any>('https://localhost:7290/api/Auth/login', user).pipe(
      map((userInfo) => {
        console.log('token' + userInfo.token);
        localStorage.setItem(JWT_NAME, userInfo.token);
        this.currentUser.next(userInfo.user)
        return userInfo;
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

  getCurrentUser() : Observable<User> {
    return this.currentUser.asObservable();
  }
}
