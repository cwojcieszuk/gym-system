import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class DashboardClient {
  private readonly url = 'dashboard';

  constructor(private http: HttpClient) {}
}
