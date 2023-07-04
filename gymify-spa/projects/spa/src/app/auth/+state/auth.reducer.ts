import { Action, createReducer, on } from '@ngrx/store';
import { DecodedUserData } from '../../../../../api-client/src/lib/clients/auth/responses/decoded-user-data';
import * as AuthActions from './auth.actions';

export const AUTH_FEATURE_KEY = 'auth';

export interface AuthState {
  user?: DecodedUserData;
  accessToken?: string;
  isLoading: boolean;
}

export const initialState: AuthState = {
  isLoading: false,
};

const reducer = createReducer(
  initialState,
  on(AuthActions.loginSuccess, (state, action) => ({
    ...state,
    user: action.user,
    accessToken: action.accessToken,
    isLoading: false,
  })),
  on(AuthActions.login, state => ({
    ...state,
    isLoading: true,
  })),
  on(AuthActions.loginFailure, state => ({
    ...state,
    isLoading: false,
  }))
);

export function authReducer(state: AuthState | undefined, action: Action): AuthState {
  return reducer(state, action);
}
