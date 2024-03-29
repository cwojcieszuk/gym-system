import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { LoginRequest } from '../../../../../../api-client/src/lib/clients/auth/requests/login.request';
import * as AuthActions from './auth.actions';
import * as AuthSelectors from './auth.selectors';
import { debounceTime, filter, Subscription, timer } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthFacade {
  isLoading$ = this.store.select(AuthSelectors.getIsLoading);
  accessToken$ = this.store.select(AuthSelectors.getAccessToken);
  refreshToken$ = this.store.select(AuthSelectors.getRefreshToken);
  refreshTokenExp$ = this.store.select(AuthSelectors.getRefreshTokenExp);
  user$ = this.store.select(AuthSelectors.getUser);
  isAuthenticated$ = this.store.select(AuthSelectors.getIsAuthenticated);
  isAdmin$ = this.store.select(AuthSelectors.getIsAdmin);
  isCoach$ = this.store.select(AuthSelectors.getIsCoach);

  private _refresh$?: Subscription;

  constructor(private readonly store: Store) {}

  init(): void {
    this.refreshTokenExp$
      .pipe(filter(Boolean), debounceTime(1000))
      .subscribe(exp => {
        const timeToExpiry = exp - Date.now();
        if(timeToExpiry < 0) {
          return;
        }

        const timeToRefresh = timeToExpiry - 30000;

        if(timeToRefresh < 0) {
          this.store.dispatch(AuthActions.refresh());
          return;
        }

        this.setupRefresh(timeToRefresh);
      });
  }

  login(params: LoginRequest): void {
    this.store.dispatch(AuthActions.login(params));
  }

  setupRefresh(expirationTime?: number): void {
    this.clearRefreshTimer();
    if (!expirationTime) {
      return;
    }
    const expirationDate = this.calculateExpirationTime(expirationTime);

    this._refresh$ = timer(expirationDate).subscribe(() => this.refresh());
  }

  refresh(): void {
    this.clearRefreshTimer();
    this.store.dispatch(AuthActions.refresh());
  }

  clearRefreshTimer(): void {
    this._refresh$?.unsubscribe();
  }

  redirectToLogin(): void {
    this.store.dispatch(AuthActions.redirectToLogin());
  }

  redirectToHome(): void {
    this.store.dispatch(AuthActions.redirectToHome());
  }

  logout(): void {
    this.store.dispatch(AuthActions.logout());
  }

  private calculateExpirationTime(expiresIn: number): Date {
    const now = Date.now();

    expiresIn = expiresIn * 1000;

    let refreshTime = expiresIn - 30000;

    if (refreshTime < now) {
      refreshTime = now;
    }

    return new Date(refreshTime);
  }
}
