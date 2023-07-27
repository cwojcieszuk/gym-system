import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginRequest } from './requests/login.request';
import { Observable } from 'rxjs';
import { LoginResponse } from './responses/login.response';
import { EmptyResponse } from '../../types/empty.response';

@Injectable({ providedIn: 'root' })
export class AuthClient {
  private readonly url = 'auth';

  constructor(private http: HttpClient) {}

  login(params: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.url}/login`, params);
  }

  logout(): Observable<EmptyResponse> {
    return this.http.post(`${this.url}/logout`, {});
  }

  refresh(refreshToken?: string): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.url}/refresh`, { refreshToken });
  }
}
