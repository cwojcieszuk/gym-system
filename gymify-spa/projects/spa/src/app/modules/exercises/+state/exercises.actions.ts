import { createAction, props } from '@ngrx/store';
import {
  ExerciseListResponse
} from '../../../../../../api-client/src/lib/clients/exercises/responses/exercise-list.response';
import { ExerciseListParams } from '../../../../../../api-client/src/lib/clients/exercises/params/exercise-list-params';
import { UUID } from '../../../../../../api-client/src/lib/types/uuid.type';

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

export const likeExercise = createAction(
  '[Exercises/API] Like Exercise',
  props<{ exerciseUid: UUID }>()
);

export const likeExerciseSuccess = createAction(
  '[Exercises/API] Like Exercise Success',
  props<{ exerciseUid: UUID }>()
);

export const likeExerciseFailure = createAction(
  '[Exercises/API] Like Exercise Failure'
);

export const dislikeExercise = createAction(
  '[Exercises/API] Dislike Exercise',
  props<{ exerciseUid: UUID }>()
);

export const dislikeExerciseSuccess = createAction(
  '[Exercises/API] Dislike Exercise Success',
  props<{ exerciseUid: UUID }>()
);

export const dislikeExerciseFailure = createAction(
  '[Exercises/API] Dislike Exercise Failure'
);
