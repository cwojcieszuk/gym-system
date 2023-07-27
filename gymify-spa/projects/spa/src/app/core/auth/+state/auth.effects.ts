import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as AuthActions from './auth.actions';
import { AuthClient } from '../../../../../../api-client/src/lib/clients/auth/auth.client';
import {
  catchError,
  map,
  mergeMap,
  of,
  tap,
  withLatestFrom
} from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { AuthHelpers } from '../../../shared/helpers/auth.helpers';
import { LoginResponse } from '../../../../../../api-client/src/lib/clients/auth/responses/login.response';
import { AuthFacade } from './auth.facade';

@Injectable()
export class AuthEffects {

  login$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.login),
      mergeMap(action => this.authClient.login({ email: action.email, password: action.password }).pipe(
        map(result => AuthActions.loginSuccess(new LoginResponse(result))),
        catchError(() => of(AuthActions.loginFailure()))
      ))
    )
  );

  loginSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.loginSuccess),
      tap(({ user }) => this.facade.setupRefresh(user.exp)),
      tap(action => {
        AuthHelpers.setLocalStorageValues({ accessToken: action.accessToken, refreshToken: action.refreshToken, refreshTokenExpiresIn: String(action.user.exp) });
        this.router.navigate(['..']);
      })
    ), { dispatch: false });

  loginFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.loginFailure),
      tap(() => this.toastr.error('Login failed'))
    ), { dispatch: false });

  redirectToLogin$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.redirectToLogin),
      tap(() => {
        void this.router.navigateByUrl('/login');
      })
    ), { dispatch: false });

  redirectToHome$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.redirectToHome),
      tap(() => this.router.navigate(['..']))
    ), { dispatch: false });

  logout$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.logout),
      tap(() => this.facade.setupRefresh()),
      mergeMap(() => this.authClient.logout().pipe(
        map(() => AuthActions.logoutSuccess()),
        catchError(() => of(AuthActions.logoutFailure()))
      ))
    )
  );

  logoutSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.logoutSuccess),
      tap(() => {
        AuthHelpers.removeLocalStorageValues();
        this.facade.redirectToLogin();
      })
    ), { dispatch: false });

  refresh$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.refresh),
      withLatestFrom(this.facade.refreshToken$),
      mergeMap(([,refreshToken]) => {

        return this.authClient.refresh(refreshToken).pipe(
          map(result => AuthActions.refreshSuccess(new LoginResponse(result))),
          catchError(() => of(AuthActions.refreshFailure()))
        );
      })
    ));

  refreshSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.refreshSuccess),
      tap(({ user }) => this.facade.setupRefresh(user.exp))
    ), { dispatch: false });

  refreshFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.refreshFailure),
      map(() => AuthActions.logout())
    ));

  constructor(
    private readonly actions$: Actions,
    private readonly authClient: AuthClient,
    private readonly toastr: ToastrService,
    private readonly router: Router,
    private readonly facade: AuthFacade
  ) {}
}
