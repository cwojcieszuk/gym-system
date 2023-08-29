import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class TemplatesClient {
  private readonly url = 'templates';

  constructor(private http: HttpClient) {}
}
