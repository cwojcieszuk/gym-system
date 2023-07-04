import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as AuthActions from './auth.actions';
import { AuthClient } from '../../../../../api-client/src/lib/clients/auth/auth.client';
import { catchError, map, mergeMap, of, tap } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { AuthHelpers } from '../../shared/helpers/auth.helpers';

@Injectable()
export class AuthEffects {

  login$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.login),
      mergeMap(action => this.authClient.login({ login: action.login, password: action.password }).pipe(
        map(result => AuthActions.loginSuccess(result)),
        catchError(() => of(AuthActions.loginFailure()))
      ))
    )
  );

  loginSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.loginSuccess),
      tap(action => {
        AuthHelpers.setLocalStorageValues({ accessToken: action.accessToken, refreshToken: action.refreshToken });
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

  constructor(
    private readonly actions$: Actions,
    private readonly authClient: AuthClient,
    private readonly toastr: ToastrService,
    private readonly router: Router
  ) {}
}
