import { Action, createReducer, on } from '@ngrx/store';
import { DecodedUserData } from '../../../../../../api-client/src/lib/clients/auth/responses/decoded-user-data';
import * as AuthActions from './auth.actions';
import { LocalStorageHelpers } from '../../../shared/helpers/local-storage.helpers';
import { AuthHelpers } from '../../../shared/helpers/auth.helpers';

export const AUTH_FEATURE_KEY = 'auth';

export interface AuthState {
  user?: DecodedUserData;
  accessToken?: string;
  refreshToken?: string;
  refreshTokenExp?: number;
  isLoading: boolean;
}

export const initialState: AuthState = {
  isLoading: false,
  accessToken: LocalStorageHelpers.getAccessToken(),
  refreshToken: LocalStorageHelpers.getRefreshToken(),
  user: AuthHelpers.getUser(LocalStorageHelpers.getAccessToken()),
  refreshTokenExp: LocalStorageHelpers.getRefreshTokenExp(),
};

const reducer = createReducer(
  initialState,
  on(AuthActions.loginSuccess, AuthActions.refreshSuccess, (state, action) => ({
    ...state,
    user: action.user,
    accessToken: action.accessToken,
    refreshToken: action.refreshToken,
    refreshTokenExp: action.user.exp,
    isLoading: false,
  })),
  on(AuthActions.login, state => ({
    ...state,
    isLoading: true,
  })),
  on(AuthActions.loginFailure, state => ({
    ...state,
    isLoading: false,
  })),
  on(AuthActions.logoutSuccess, AuthActions.refreshFailure, state => ({
    ...state,
    user: undefined,
    accessToken: undefined,
    refreshToken: undefined,
    refreshTokenExp: undefined,
  }))
);

export function authReducer(state: AuthState | undefined, action: Action): AuthState {
  return reducer(state, action);
}
