import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, of, switchMap, tap } from 'rxjs';
import { AuthService } from '../../services/auth.service';
import { AuthResponse, User } from '../../models/user';
import { loginAction, loginSuccessAction, registerAction, registerSuccessAction, getCurrentUserAction, getCurrentUserSuccessAction } from '../actions/auth.actions';

@Injectable()
export class LoginEffect {
  constructor(
    private actions: Actions,
    private authService: AuthService,
    private router: Router,
  ) {}

  login = createEffect(() =>
    this.actions.pipe(
      ofType(loginAction),
      switchMap((data) => {
        return this.authService.login(data.request).pipe(
          map((response: AuthResponse) => {
            localStorage.setItem('token', response.user?.token as string)
            return loginSuccessAction(response);
          })
        );
      }),
    ),
  );

  redirectAfterLoginSuccess = createEffect(
    () =>
      this.actions.pipe(
        ofType(loginSuccessAction),
        tap(() => {
          this.router.navigateByUrl('/');
        })
      ),
    { dispatch: false },
  );

  register = createEffect(() =>
    this.actions.pipe(
      ofType(registerAction),
      switchMap((data) => {
        return this.authService.register(data.request).pipe(
          map((response: AuthResponse) => {
            return registerSuccessAction(response);
          })
        );
      }),
    ),
  );

  redirectAfterRegisterSuccess = createEffect(
    () =>
      this.actions.pipe(
        ofType(registerSuccessAction),
        tap(() => {
          this.router.navigateByUrl('/');
        }),
      ),
    { dispatch: false },
  );
}