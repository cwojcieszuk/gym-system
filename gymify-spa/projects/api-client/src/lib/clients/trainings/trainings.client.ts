import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class TrainingsClient {
  private readonly url = 'trainings';

  constructor(private http: HttpClient) {}
}
