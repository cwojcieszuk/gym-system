import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginRequest } from './requests/login.request';
import { Observable } from 'rxjs';
import { LoginResponse } from './responses/login.response';

@Injectable({ providedIn: 'root' })
export class AuthClient {
  constructor(private http: HttpClient) {}

  login(params: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>('auth/login', params);
  }
}
