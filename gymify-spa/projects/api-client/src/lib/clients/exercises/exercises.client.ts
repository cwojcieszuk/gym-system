import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ExerciseListParams } from './params/exercise-list-params';
import { Observable } from 'rxjs';
import { ExerciseListResponse } from './responses/exercise-list.response';
import { LikeExerciseParams } from './params/like-exercise.params';
import { EmptyResponse } from '../../types/empty.response';

@Injectable({ providedIn: 'root' })
export class ExercisesClient {
  private readonly url = 'exercises';

  constructor(private http: HttpClient) {}

  getExercisesList(query: ExerciseListParams): Observable<ExerciseListResponse> {
    const params = new HttpParams({
      fromObject: JSON.parse(JSON.stringify(query)),
    });

    return this.http.get<ExerciseListResponse>(`${this.url}`, { params });
  }

  likeExercise(params: LikeExerciseParams): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.url}/like`, params);
  }

  dislikeExercise(params: LikeExerciseParams): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(`${this.url}/dislike`, params);
  }
}
