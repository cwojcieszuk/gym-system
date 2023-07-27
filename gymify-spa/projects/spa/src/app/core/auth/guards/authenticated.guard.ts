import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AuthFacade } from '../+state/auth.facade';
import { first, Observable, tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthenticatedGuard implements CanActivate {
  constructor(private facade: AuthFacade) {}

  canActivate(): Observable<boolean>  {
    return this.facade.isAuthenticated$.pipe(
      first(),
      tap(isAuthenticated => {
        if (!isAuthenticated) {
          this.facade.redirectToLogin();
        }
      })
    );
  }
}
