import { createAction, props } from '@ngrx/store';
import { LoginRequest } from '../../../../../api-client/src/lib/clients/auth/requests/login.request';
import { LoginResponse } from '../../../../../api-client/src/lib/clients/auth/responses/login.response';

export const login = createAction(
  '[Auth/API] Login',
  props<LoginRequest>()
);

export const loginSuccess = createAction(
  '[Auth/API] Login Success',
  props<LoginResponse>()
);

export const loginFailure = createAction(
  '[Auth/API] Login Failure'
);

export const redirectToLogin = createAction(
  '[Auth] Redirect To Login'
);
