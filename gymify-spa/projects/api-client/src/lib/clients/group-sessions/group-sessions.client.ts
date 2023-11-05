import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GroupSessionListFilters } from './params/group-session-list.filters';
import { Observable } from 'rxjs';
import { GroupSessionListResponse } from './responses/group-session-list.response';
import { mapToHttpParams } from '../../mappers/map-to-http-params';

@Injectable({ providedIn: 'root' })
export class GroupSessionsClient {
  private readonly url = 'group-sessions';

  constructor(private http: HttpClient) {}

  getGroupSessions(query: GroupSessionListFilters): Observable<GroupSessionListResponse> {
    return this.http.get<GroupSessionListResponse>(this.url, { params: mapToHttpParams(query) });
  }
}
