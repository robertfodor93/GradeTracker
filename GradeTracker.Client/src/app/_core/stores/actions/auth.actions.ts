import { createAction, props } from '@ngrx/store';
import { User, LoginUser, RegisterUser, AuthResponse } from '../../models/user';

export enum AuthActionTypes {
    REGISTER = '[Auth] REGISTER',
    REGISTER_SUCCESS = '[Auth] REGISTER_SUCCESS',
    REGISTER_FAILURE = '[Auth] REGISTER_FAILURE',
  
    LOGIN = '[Auth] LOGIN',
    LOGIN_SUCCESS = '[Auth] LOGIN_SUCCESS',
    LOGIN_FAILURE = '[Auth] LOGIN_FAILURE',
  
    GET_CURRENT_USER = '[Auth] GET_CURRENT_USER',
    GET_CURRENT_USER_SUCCESS = '[Auth] GET_CURRENT_USER_SUCCESS',
    GET_CURRENT_USER_FAILURE = '[Auth] GET_CURRENT_USER_FAILURE',
}

export const loginAction = createAction(
    AuthActionTypes.LOGIN,
    props<{ request: LoginUser }>()
);
export const loginSuccessAction = createAction(
    AuthActionTypes.LOGIN_SUCCESS,
    props<AuthResponse>()
);
export const loginFailureAction = createAction(
    AuthActionTypes.LOGIN_FAILURE
);

export const registerAction = createAction(
    AuthActionTypes.REGISTER,
    props<{ request: RegisterUser }>(),
);
export const registerSuccessAction = createAction(
    AuthActionTypes.REGISTER_SUCCESS,
    props<AuthResponse>(),
);
export const registerFailureAction = createAction(
    AuthActionTypes.REGISTER_FAILURE
);

export const getCurrentUserAction = createAction(AuthActionTypes.GET_CURRENT_USER);
export const getCurrentUserSuccessAction = createAction(
  AuthActionTypes.GET_CURRENT_USER_SUCCESS,
  props<{ user: User }>(),
);
export const getCurrentUserFailureAction = createAction(
  AuthActionTypes.GET_CURRENT_USER_FAILURE
);