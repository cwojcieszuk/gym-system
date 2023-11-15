import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UUID } from '../../types/uuid.type';
import { Observable } from 'rxjs';
import { UserDataResponse } from './responses/user-data.response';
import { UpdateUserDataParams } from './params/update-user-data.params';
import { EmptyResponse } from '../../types/empty.response';
import { UpdateUserPasswordParams } from './params/update-user-password.params';

@Injectable({ providedIn: 'root' })
export class ProfileClient {
  private readonly url = 'profile';

  constructor(private http: HttpClient) {}

  getUserData(userUid: UUID): Observable<UserDataResponse> {
    return this.http.get<UserDataResponse>(`${this.url}/${userUid}`);
  }

  updateUserData(userUid: UUID, body: UpdateUserDataParams): Observable<EmptyResponse> {
    return this.http.put<EmptyResponse>(`${this.url}/${userUid}/data`, { ...body, userUid });
  }

  updateUserPassword(userUid: UUID, body: UpdateUserPasswordParams): Observable<EmptyResponse> {
    return this.http.put<EmptyResponse>(`${this.url}/${userUid}/password`, { ...body, userUid });
  }

  uploadAvatar(userUid: UUID, file: File): Observable<EmptyResponse> {
    const formData = new FormData();
    formData.append('avatar', file);

    return this.http.post(`${this.url}/${userUid}/avatar`, formData);
  }

  updateCoachDescription(userUid: UUID, description: string, categoryId: number[]): Observable<EmptyResponse> {
    return this.http.put<EmptyResponse>(`${this.url}/${userUid}/coach-data`, { userUid, description, categoryId });
  }
}
