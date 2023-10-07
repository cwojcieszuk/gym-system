import { HttpParams } from '@angular/common/http';

export const mapToHttpParams = (query: any): HttpParams => new HttpParams({ fromObject: JSON.parse(JSON.stringify(query)) });
