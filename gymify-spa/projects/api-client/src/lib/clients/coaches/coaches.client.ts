import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GetCoachesParams } from './params/get-coaches.params';
import { Observable } from 'rxjs';
import { PagedResponse } from '../../models/paged-response';
import { CoachDTO } from './models/coach.dto';
import { mapToHttpParams } from '../../mappers/map-to-http-params';
import { UUID } from '../../types/uuid.type';
import { EmptyResponse } from '../../types/empty.response';
import { CoachHourDTO } from './models/coach-hour.dto';
import { HttpHelpers } from '../../helpers/http.helpers';

@Injectable({ providedIn: 'root' })
export class CoachesClient {
  private readonly url = 'coaches';

  constructor(private http: HttpClient) {}

  getCoaches(params: GetCoachesParams): Observable<PagedResponse<CoachDTO>> {
    return this.http.get<PagedResponse<CoachDTO>>(this.url, { params: mapToHttpParams(params) });
  }

  likeCoach(coachUid: UUID): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.url}/like`, { coachUid });
  }

  dislikeCoach(coachUid: UUID): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.url}/dislike`, { coachUid });
  }

  getCoachHoursByDate(coachUid: UUID, date: Date): Observable<CoachHourDTO[]> {
    return this.http.get<CoachHourDTO[]>(`${this.url}/hours`,{ params: mapToHttpParams({ coachUid, date: HttpHelpers.formatDate(date) }) });
  }

  signupForCoach(coachHourUid: UUID): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.url}/signup`, { coachHourUid });
  }
}
