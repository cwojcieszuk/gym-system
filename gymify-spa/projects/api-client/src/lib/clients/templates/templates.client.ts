import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PagedRequest } from '../../models/paged-request';
import { Observable } from 'rxjs';
import { TemplatesResponse } from './responses/templates.response';

@Injectable({ providedIn: 'root' })
export class TemplatesClient {
  private readonly url = 'templates';

  constructor(private http: HttpClient) {}

  getPersonalTemplates(query: PagedRequest): Observable<TemplatesResponse> {
    const params = new HttpParams({
      fromObject: JSON.parse(JSON.stringify(query)),
    });

    return this.http.get<TemplatesResponse>(`${this.url}/personal`, { params });
  }
}
