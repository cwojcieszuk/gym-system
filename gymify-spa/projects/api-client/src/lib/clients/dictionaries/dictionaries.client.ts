import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserRole } from './responses/user-role.response';

@Injectable({ providedIn: 'root' })
export class DictionariesClient {
  private readonly url = 'dictionaries';

  constructor(private http: HttpClient) {}

  getUserRoles(): Observable<UserRole[]> {
    return this.http.get<UserRole[]>(`${this.url}/user-roles`);
  }
}
