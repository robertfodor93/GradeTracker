import { Action, createReducer, on } from '@ngrx/store';
import {
  getCurrentUserAction,
  getCurrentUserFailureAction,
  getCurrentUserSuccessAction,
  loginAction,
  loginFailureAction,
  loginSuccessAction,
  registerAction,
  registerFailureAction,
  registerSuccessAction,
} from '../actions/auth.actions';
import { User } from '../../models/user';

export interface AuthStateInterface {
    isSubmitting: boolean;
    token: string | undefined;
    isLoading: boolean;
    currentUser: User | null;
  }

const initialState: AuthStateInterface = {
  isSubmitting: false,
  isLoading: false,
  token: '',
  currentUser: null,
};

const authReducer = createReducer(
  initialState,
  on(
    registerAction,
    (state, action): AuthStateInterface => ({
      ...state,
      isSubmitting: true,
    }),
  ),
  on(
    registerSuccessAction,
    (state, action): AuthStateInterface => ({
      ...state,
      isSubmitting: false,
      token: action.user?.token,
    }),
  ),
  on(
    registerFailureAction,
    (state, action): AuthStateInterface => ({
      ...state,
      isSubmitting: false,
    }),
  ),
  on(
    loginAction,
    (state, action): AuthStateInterface => ({
      ...state,
      isSubmitting: true,
    }),
  ),
  on(
    loginSuccessAction,
    (state, action): AuthStateInterface => ({
      ...state,
      isSubmitting: false,
      token: action.user?.token,
    }),
  ),
  on(
    loginFailureAction,
    (state, action): AuthStateInterface => ({
      ...state,
      isSubmitting: false,
    }),
  ),
  on(
    getCurrentUserAction,
    (state, action): AuthStateInterface => ({
      ...state,
      isLoading: true,
    }),
  ),
  on(
    getCurrentUserSuccessAction,
    (state, action): AuthStateInterface => ({
      ...state,
      isLoading: false,
      currentUser: action.user,
    }),
  ),
  on(
    getCurrentUserFailureAction,
    (state, action): AuthStateInterface => ({
      ...state,
      isLoading: false,
    }),
  ),
);

export function reducers(state: AuthStateInterface, action: Action) {
  return authReducer(state, action);
}