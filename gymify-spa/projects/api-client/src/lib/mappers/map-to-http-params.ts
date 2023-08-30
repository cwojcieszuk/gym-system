import { PagedRequest } from '../models/paged-request';
import { HttpParams } from '@angular/common/http';

export const mapToHttpParams = (query: PagedRequest): HttpParams => new HttpParams({ fromObject: JSON.parse(JSON.stringify(query)) });
