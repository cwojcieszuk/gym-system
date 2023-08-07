import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { UserListFilters } from './params/user-list.filters';
import { Observable } from 'rxjs';
import { UserListResponse } from './responses/user-list.response';
import { AddUserParams } from './params/add-user.params';
import { EmptyResponse } from '../../types/empty.response';

@Injectable({ providedIn: 'root' })
export class UsersClient {
  private readonly url = 'users';

  constructor(private http: HttpClient) {}

  fetch(query: UserListFilters): Observable<UserListResponse> {
    const params = new HttpParams({
      fromObject: JSON.parse(JSON.stringify(query)),
    });

    return this.http.get<UserListResponse>(`${this.url}`, { params });
  }

  addUser(params: AddUserParams): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.url}`, params);
  }
}
