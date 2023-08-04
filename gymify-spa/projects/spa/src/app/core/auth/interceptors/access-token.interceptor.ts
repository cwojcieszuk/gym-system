import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { first, map, Observable, switchMap } from 'rxjs';
import { AuthFacade } from '../+state/auth.facade';

@Injectable({ providedIn: 'root' })
export class AccessTokenInterceptor implements HttpInterceptor {
  constructor(private facade: AuthFacade) {}

  private static addAuthorizationHeader(
    req: HttpRequest<never>,
    accessToken: string
  ): HttpRequest<never> {
    return req.clone({
      setHeaders: {
        Authorization: `Bearer ${accessToken}`,
      },
    });
  }

  intercept(req: HttpRequest<never>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return this.facade.accessToken$.pipe(
      first(),
      map(accessToken => {
        if (!accessToken) {
          return req;
        }
        return AccessTokenInterceptor.addAuthorizationHeader(req, accessToken);
      }),
      switchMap(request => next.handle(request))
    );
  }
}
