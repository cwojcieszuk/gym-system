import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class ProfileClient {
  private readonly url = 'profile';

  constructor(private http: HttpClient) {}
}
