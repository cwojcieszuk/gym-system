import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PagedRequest } from '../../models/paged-request';
import { Observable } from 'rxjs';
import { TemplatesResponse } from './responses/templates.response';
import { mapToHttpParams } from '../../mappers/map-to-http-params';
import { CreateTemplateParams } from './params/create-template.params';
import { EmptyResponse } from '../../types/empty.response';
import { UUID } from '../../types/uuid.type';
import { TemplateDetailsDTO } from './models/template.details.dto';
import { UpdateTemplateParams } from './params/update-template.params';

@Injectable({ providedIn: 'root' })
export class TemplatesClient {
  private readonly url = 'templates';

  constructor(private http: HttpClient) {}

  getPersonalTemplates(query: PagedRequest): Observable<TemplatesResponse> {
    return this.http.get<TemplatesResponse>(`${this.url}/personal`, { params: mapToHttpParams(query) });
  }

  getCommunityTemplates(query: PagedRequest): Observable<TemplatesResponse> {
    return this.http.get<TemplatesResponse>(`${this.url}/community`, { params: mapToHttpParams(query) });
  }

  createTemplate(params: CreateTemplateParams): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(this.url, params);
  }

  getTemplate(templateUid: UUID): Observable<TemplateDetailsDTO> {
    return this.http.get<TemplateDetailsDTO>(`${this.url}/${templateUid}`);
  }

  shareTemplate(templateUid: UUID): Observable<EmptyResponse> {
    return this.http.post<TemplateDetailsDTO>(`${this.url}/${templateUid}/share`, { templateUid });
  }

  deleteTemplate(templateUid: UUID): Observable<EmptyResponse> {
    return this.http.delete<EmptyResponse>(`${this.url}/${templateUid}`);
  }

  updateTemplate(params: UpdateTemplateParams): Observable<EmptyResponse> {
    return this.http.put<EmptyResponse>(`${this.url}/${params.templateUid}`, params);
  }

  importTemplate(templateUid: UUID): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.url}/import`, { templateUid });
  }

  getTemplatesBySearch(search: string): Observable<TemplateDetailsDTO[]> {
    return this.http.get<TemplateDetailsDTO[]>(`${this.url}/search`, { params: mapToHttpParams({ search: search ?? '' }) });
  }
}
