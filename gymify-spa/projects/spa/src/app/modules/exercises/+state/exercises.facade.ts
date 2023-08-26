import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';

import * as ExerciseSelectors from './exercises.selectors';
import * as ExerciseActions from './exercises.actions';
import { ExerciseListParams } from '../../../../../../api-client/src/lib/clients/exercises/params/exercise-list-params';
import { UUID } from '../../../../../../api-client/src/lib/types/uuid.type';

@Injectable({ providedIn: 'root' })
export class ExercisesFacade {
  exerciseResponse$ = this.store.select(ExerciseSelectors.getExerciseResponse);
  query$ = this.store.select(ExerciseSelectors.getExercisesQuery);
  isLoading$ = this.store.select(ExerciseSelectors.getIsLoading);

  constructor(private store: Store) {}

  fetchExercises(): void {
    this.store.dispatch(ExerciseActions.fetchExercises());
  }

  setFilters(filters: Partial<ExerciseListParams>): void {
    this.store.dispatch(ExerciseActions.setFilters({ filters }));
  }

  likeExercise(exerciseUid: UUID): void {
    this.store.dispatch(ExerciseActions.likeExercise({ exerciseUid }));
  }

  dislikeExercise(exerciseUid: UUID): void {
    this.store.dispatch(ExerciseActions.dislikeExercise({ exerciseUid }));
  }
}
