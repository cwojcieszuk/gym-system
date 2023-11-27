import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserListFilters } from './params/user-list.filters';
import { Observable } from 'rxjs';
import { UserListResponse } from './responses/user-list.response';
import { AddUserParams } from './params/add-user.params';
import { EmptyResponse } from '../../types/empty.response';
import { EditUserParams } from './params/edit-user.params';
import { UUID } from '../../types/uuid.type';
import { mapToHttpParams } from '../../mappers/map-to-http-params';
import { HttpHelpers } from '../../helpers/http.helpers';

@Injectable({ providedIn: 'root' })
export class UsersClient {
  private readonly url = 'users';

  constructor(private http: HttpClient) {}

  fetch(query: UserListFilters): Observable<UserListResponse> {
    return this.http.get<UserListResponse>(`${this.url}`, { params: mapToHttpParams(query) });
  }

  addUser(params: AddUserParams): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.url}`, HttpHelpers.getParamsWithFormattedDates(params));
  }

  editUser(params: EditUserParams): Observable<EmptyResponse> {
    return this.http.put<EmptyResponse>(`${this.url}/${params.userUid}`, HttpHelpers.getParamsWithFormattedDates(params));
  }

  deleteUser(userUid: UUID): Observable<EmptyResponse> {
    return this.http.delete(`${this.url}/${userUid}`);
  }
}
