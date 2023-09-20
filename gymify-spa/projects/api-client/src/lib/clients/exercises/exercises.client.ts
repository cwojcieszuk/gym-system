import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ExerciseListParams } from './params/exercise-list-params';
import { Observable } from 'rxjs';
import { ExerciseListResponse } from './responses/exercise-list.response';
import { LikeExerciseParams } from './params/like-exercise.params';
import { EmptyResponse } from '../../types/empty.response';
import { mapToHttpParams } from '../../mappers/map-to-http-params';

@Injectable({ providedIn: 'root' })
export class ExercisesClient {
  private readonly url = 'exercises';

  constructor(private http: HttpClient) {}

  getExercisesList(query: ExerciseListParams): Observable<ExerciseListResponse> {
    return this.http.get<ExerciseListResponse>(`${this.url}`, { params: mapToHttpParams(query) });
  }

  likeExercise(params: LikeExerciseParams): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.url}/like`, params);
  }

  dislikeExercise(params: LikeExerciseParams): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.url}/dislike`, params);
  }
}
