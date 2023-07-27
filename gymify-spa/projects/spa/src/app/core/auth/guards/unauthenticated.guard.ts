import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from '@angular/router';
import { AuthFacade } from '../+state/auth.facade';
import { first, Observable, tap } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UnauthenticatedGuard implements CanActivate {
  constructor(private facade: AuthFacade) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean>  {
    return this.facade.isAuthenticated$.pipe(
      first(),
      tap((isAuthenticated) => {
        if (isAuthenticated) {
          this.facade.redirectToHome();
        }
      })
    );
  }
}
