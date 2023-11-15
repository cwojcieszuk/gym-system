import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AUTH_FEATURE_KEY, AuthState } from './auth.reducer';
import { Roles } from '../../../shared/constants/roles.enum';

const getAuthState = createFeatureSelector<AuthState>(AUTH_FEATURE_KEY);

export const getIsLoading = createSelector(
  getAuthState,
  state => state.isLoading
);

export const getAccessToken = createSelector(
  getAuthState,
  state => state.accessToken
);

export const getRefreshToken = createSelector(
  getAuthState,
  state => state.refreshToken
);

export const getRefreshTokenExp = createSelector(
  getAuthState,
  state => state.refreshTokenExp
);

export const getUser = createSelector(
  getAuthState,
  state => state.user
);

export const getIsAuthenticated = createSelector(
  getAuthState,
  state => state.user != null
);

export const getIsAdmin = createSelector(
  getAuthState,
  state => state.user?.role === Roles.Admin
);

export const getIsCoach = createSelector(
  getAuthState,
  state => state.user?.role === Roles.Coach
);
