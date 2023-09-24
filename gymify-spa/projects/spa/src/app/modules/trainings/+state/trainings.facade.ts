import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import * as TrainingSelectors from './trainings.selectors';
import * as TrainingActions from './trainings.actions';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';
import { CreateTrainingParams } from '../../../../../../api-client/src/lib/clients/trainings/params/create-training.params';
import { UUID } from '../../../../../../api-client/src/lib/types/uuid.type';

@Injectable({ providedIn: 'root' })
export class TrainingsFacade {
  templateResponse$ = this.store.select(TrainingSelectors.getTrainingsResponse);
  query$ = this.store.select(TrainingSelectors.getQuery);
  trainingUid$ = this.store.select(TrainingSelectors.getTrainingUid);
  trainingDetails$ = this.store.select(TrainingSelectors.getTrainingDetails);
  searchedTemplates$ = this.store.select(TrainingSelectors.getSearchTemplates);

  constructor(private store: Store) {}

  fetchTrainings(): void {
    this.store.dispatch(TrainingActions.fetchTrainings());
  }

  setQuery(query: Partial<PagedRequest>): void {
    this.store.dispatch(TrainingActions.setQuery({ query }));
  }

  createTraining(params: CreateTrainingParams): void {
    this.store.dispatch(TrainingActions.createTraining(params));
  }

  selectTraining(trainingUid: UUID): void {
    this.store.dispatch(TrainingActions.selectTraining({ trainingUid }));
  }

  fetchTrainingDetails(): void {
    this.store.dispatch(TrainingActions.fetchTrainingDetails());
  }

  updateTraining(trainingName: string, trainingDate: Date, templateUid: UUID): void {
    this.store.dispatch(TrainingActions.updateTraining({ trainingName, trainingDate, templateUid }));
  }

  fetchTemplatesBySearch(search: string): void {
    this.store.dispatch(TrainingActions.fetchTemplatesBySearch({ search }));
  }
}
