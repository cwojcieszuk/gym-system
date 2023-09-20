import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TrainingsResponse } from './responses/trainings.response';
import { PagedRequest } from '../../models/paged-request';
import { mapToHttpParams } from '../../mappers/map-to-http-params';

@Injectable({ providedIn: 'root' })
export class TrainingsClient {
  private readonly url = 'trainings';

  constructor(private http: HttpClient) {}

  getTrainings(query: PagedRequest): Observable<TrainingsResponse> {
    return this.http.get<TrainingsResponse>(this.url, { params: mapToHttpParams(query) });
  }
}
