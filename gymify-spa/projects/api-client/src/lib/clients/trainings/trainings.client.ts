import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TrainingsResponse } from './responses/trainings.response';
import { PagedRequest } from '../../models/paged-request';
import { mapToHttpParams } from '../../mappers/map-to-http-params';
import { CreateTrainingParams } from './params/create-training.params';
import { EmptyResponse } from '../../types/empty.response';
import { UUID } from '../../types/uuid.type';
import { UpdateTrainingParams } from './params/update-training.params';
import { TrainingDetailsDTO } from './models/training-details.dto';
import { HttpHelpers } from '../../helpers/http.helpers';

@Injectable({ providedIn: 'root' })
export class TrainingsClient {
  private readonly url = 'trainings';

  constructor(private http: HttpClient) {}

  getTrainings(query: PagedRequest): Observable<TrainingsResponse> {
    return this.http.get<TrainingsResponse>(this.url, { params: mapToHttpParams(query) });
  }

  createTraining(params: CreateTrainingParams): Observable<EmptyResponse> {
    return this.http.post<EmptyResponse>(this.url, HttpHelpers.getParamsWithFormattedDates(params));
  }

  getTraining(trainingUid: UUID): Observable<TrainingDetailsDTO> {
    return this.http.get<TrainingDetailsDTO>(`${this.url}/${trainingUid}`);
  }

  updateTraining(params: UpdateTrainingParams): Observable<EmptyResponse> {
    return this.http.put<EmptyResponse>(`${this.url}/${params.trainingUid}`, HttpHelpers.getParamsWithFormattedDates(params));
  }

  deleteTraining(trainingUid: UUID): Observable<EmptyResponse> {
    return this.http.delete<EmptyResponse>(`${this.url}/${trainingUid}`);
  }
}
