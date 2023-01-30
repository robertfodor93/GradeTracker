import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AuthStateInterface } from '../reducers/auth.reducer';

export const authFeatureSelector = createFeatureSelector<AuthStateInterface>('auth');

export const isSubmittingSelector = createSelector(
  authFeatureSelector,
  (state: AuthStateInterface) => state.isSubmitting,
);

export const errorSelector = createSelector(
  authFeatureSelector,
  (state: AuthStateInterface) => state
);

export const isLoggedInSelector = createSelector(
  authFeatureSelector,
  (state: AuthStateInterface) => Boolean(state.token)
);

export const authTokenSelector = createSelector(
  authFeatureSelector,
  (state: AuthStateInterface) => state.token
);