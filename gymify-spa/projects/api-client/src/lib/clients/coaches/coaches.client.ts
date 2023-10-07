import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class CoachesClient {
  private readonly url = 'coaches';

  constructor(private http: HttpClient) {}
}
