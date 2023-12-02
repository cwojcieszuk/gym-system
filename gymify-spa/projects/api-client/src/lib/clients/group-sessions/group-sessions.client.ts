import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GroupSessionListFilters } from './params/group-session-list.filters';
import { Observable } from 'rxjs';
import { GroupSessionListResponse } from './responses/group-session-list.response';
import { mapToHttpParams } from '../../mappers/map-to-http-params';
import { UUID } from '../../types/uuid.type';
import { EmptyResponse } from '../../types/empty.response';
import { CreateGroupSessionParams } from './params/create-group-session.params';
import { HttpHelpers } from '../../helpers/http.helpers';

@Injectable({ providedIn: 'root' })
export class GroupSessionsClient {
  private readonly url = 'group-sessions';

  constructor(private http: HttpClient) {}

  getGroupSessions(query: GroupSessionListFilters): Observable<GroupSessionListResponse> {
    return this.http.get<GroupSessionListResponse>(this.url, { params: mapToHttpParams(query) });
  }

  bookIn(groupSessionUid: UUID): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.url}/book-in`, { groupSessionUid });
  }

  resign(groupSessionUid: UUID): Observable<EmptyResponse> {
    return this.http.post(`${this.url}/resign`, { groupSessionUid });
  }

  createGroupSession(params: CreateGroupSessionParams): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(this.url, HttpHelpers.getParamsWithFormattedDates(params));
  }
}
