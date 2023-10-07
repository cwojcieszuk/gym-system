import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GetCoachesParams } from './params/get-coaches.params';
import { Observable } from 'rxjs';
import { PagedResponse } from '../../models/paged-response';
import { CoachDTO } from './models/coach.dto';
import { mapToHttpParams } from '../../mappers/map-to-http-params';

@Injectable({ providedIn: 'root' })
export class CoachesClient {
  private readonly url = 'coaches';

  constructor(private http: HttpClient) {}

  getCoaches(params: GetCoachesParams): Observable<PagedResponse<CoachDTO>> {
    return this.http.get<PagedResponse<CoachDTO>>(this.url, { params: mapToHttpParams(params) });
  }
}
