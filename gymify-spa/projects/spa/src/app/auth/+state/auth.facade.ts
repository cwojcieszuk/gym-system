import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { LoginRequest } from '../../../../../api-client/src/lib/clients/auth/requests/login.request';
import * as AuthActions from './auth.actions';
import * as AuthSelectors from './auth.selectors';

@Injectable({ providedIn: 'root' })
export class AuthFacade {
  isLoading$ = this.store.select(AuthSelectors.getIsLoading);
  accessToken$ = this.store.select(AuthSelectors.getAccessToken);
  user$ = this.store.select(AuthSelectors.getUser);
  isAuthenticated$ = this.store.select(AuthSelectors.getIsAuthenticated);

  constructor(private readonly store: Store) {}

  login(params: LoginRequest): void {
    this.store.dispatch(AuthActions.login(params));
  }

  redirectToLogin(): void {
    this.store.dispatch(AuthActions.redirectToLogin());
  }
}
