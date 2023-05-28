import { Inject, Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BASE_URL } from '../config/base-url.token';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {
  constructor(@Inject(BASE_URL) private baseUrl: string) {}

  intercept(req: HttpRequest<never>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const updatedReq = req.clone({ url: [this.baseUrl, req.url].join('/') });

    return next.handle(updatedReq);
  }
}
