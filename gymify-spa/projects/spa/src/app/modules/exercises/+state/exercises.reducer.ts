import { createReducer, on } from '@ngrx/store';
import { ExerciseListParams } from '../../../../../../api-client/src/lib/clients/exercises/params/exercise-list-params';

import * as ExerciseActions from './exercises.actions';
import {
  ExerciseListResponse
} from '../../../../../../api-client/src/lib/clients/exercises/responses/exercise-list.response';

export const EXERCISES_FEATURE_KEY = 'exercises';

export interface ExercisesState {
  exerciseResponse?: ExerciseListResponse;
  query: ExerciseListParams;
  isLoading: boolean;
}

const initialState: ExercisesState = {
  query: {
    pageNumber: 1,
    pageSize: 10,
  },
  isLoading: false,
};

export const exercisesReducer = createReducer(
  initialState,
  on(ExerciseActions.fetchExercisesSuccess, (state, payload) => ({
    ...state,
    exerciseResponse: payload.data,
  })),
  on(ExerciseActions.setFilters, (state, payload) => ({
    ...state,
    query: {
      ...state.query,
      ...payload.filters,
      pageNumber: payload.filters.pageNumber == null ? 1 : payload.filters.pageNumber,
    },
  })),
  on(ExerciseActions.fetchExercises, state => ({
    ...state,
    isLoading: true,
  })),
  on(ExerciseActions.fetchExercisesSuccess, ExerciseActions.fetchExercisesFailure, state => ({
    ...state,
    isLoading: false,
  })),
  on(ExerciseActions.likeExerciseSuccess, (state, payload) => ({
    ...state,
    exerciseResponse: state.exerciseResponse == null ? undefined : {
      ...state.exerciseResponse,
      content: state.exerciseResponse.content.map(ex => ex.exerciseUid !== payload.exerciseUid ? ex : ({ ...ex, isFavorite: true })),
    },
  })),
  on(ExerciseActions.dislikeExerciseSuccess, (state, payload) => ({
    ...state,
    exerciseResponse: state.exerciseResponse == null ? undefined : {
      ...state.exerciseResponse,
      content: state.exerciseResponse.content.map(ex => ex.exerciseUid !== payload.exerciseUid ? ex : ({ ...ex, isFavorite: false })),
    },
  }))
);
