import { createAction, props } from '@ngrx/store';
import {
  ExerciseListResponse
} from '../../../../../../api-client/src/lib/clients/exercises/responses/exercise-list.response';
import { ExerciseListParams } from '../../../../../../api-client/src/lib/clients/exercises/params/exercise-list-params';

export const fetchExercises = createAction(
  '[Exercises/API] Fetch Exercises'
);

export const fetchExercisesSuccess = createAction(
  '[Exercises/API] Fetch Exercises Success',
  props<{ data: ExerciseListResponse }>()
);

export const fetchExercisesFailure = createAction(
  '[Exercises/API] Fetch Exercises Failure'
);

export const setFilters = createAction(
  '[Exercises] Set Filters',
  props<{ filters: Partial<ExerciseListParams> }>()
);
