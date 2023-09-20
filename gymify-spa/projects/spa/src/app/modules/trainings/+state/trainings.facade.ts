import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';

import * as TrainingSelectors from './trainings.selectors';
import * as TrainingActions from './trainings.actions';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';

@Injectable({ providedIn: 'root' })
export class TrainingsFacade {
  templateResponse$ = this.store.select(TrainingSelectors.getTrainingsResponse);
  query$ = this.store.select(TrainingSelectors.getQuery);

  constructor(private store: Store) {}

  fetchTrainings(): void {
    this.store.dispatch(TrainingActions.fetchTrainings());
  }

  setQuery(query: Partial<PagedRequest>): void {
    this.store.dispatch(TrainingActions.setQuery(query));
  }
}
