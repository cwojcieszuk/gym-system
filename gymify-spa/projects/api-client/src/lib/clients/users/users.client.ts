import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserListFilters } from './params/user-list.filters';
import { Observable } from 'rxjs';
import { UserListResponse } from './responses/user-list.response';

@Injectable({ providedIn: 'root' })
export class UsersClient {
  private readonly url = 'users';

  constructor(private http: HttpClient) {}

  fetch(params: UserListFilters): Observable<UserListResponse> {
    return this.http.post<UserListResponse>(`${this.url}`, params);
  }
}
