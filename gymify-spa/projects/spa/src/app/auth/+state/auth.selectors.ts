import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AUTH_FEATURE_KEY, AuthState } from './auth.reducer';

const getAuthState = createFeatureSelector<AuthState>(AUTH_FEATURE_KEY);

export const getIsLoading = createSelector(
  getAuthState,
  state => state.isLoading
);

export const getAccessToken = createSelector(
  getAuthState,
  state => state.accessToken
);

export const getUser = createSelector(
  getAuthState,
  state => state.user
);

export const getIsAuthenticated = createSelector(
  getAuthState,
  state => state.user != null
);
