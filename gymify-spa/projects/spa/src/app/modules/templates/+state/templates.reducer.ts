import { createReducer, on } from '@ngrx/store';
import * as TemplateActions from './templates.actions';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';
import { TemplatesResponse } from '../../../../../../api-client/src/lib/clients/templates/responses/templates.response';
import { ExerciseDTO } from '../../../../../../api-client/src/lib/clients/exercises/models/exercise.dto';
import { ExerciseListParams } from '../../../../../../api-client/src/lib/clients/exercises/params/exercise-list-params';

export const TEMPLATES_FEATURE_KEY = 'templates';

export interface TemplatesState {
  templatesResponse?: TemplatesResponse;
  query: PagedRequest;

  exercises: ExerciseDTO[];
  totalExercises: number;
  isLoadingExercises: boolean;
  exerciseQuery: ExerciseListParams;
}

const initialState: TemplatesState = {
  query: {
    pageNumber: 1,
    pageSize: 10,
  },
  exercises: [],
  totalExercises: 0,
  isLoadingExercises: false,
  exerciseQuery: {
    pageNumber: 1,
    pageSize: 8,
  },
};

export const templatesReducer = createReducer(
  initialState,
  on(TemplateActions.fetchPersonalTemplatesSuccess, TemplateActions.fetchCommunityTemplatesSuccess, (state, action) => ({
    ...state,
    templatesResponse: action.response,
  })),
  on(TemplateActions.setQuery, (state, payload) => ({
    ...state,
    query: {
      ...state.query,
      ...payload.query,
    },
  })),
  on(TemplateActions.fetchExercisesSuccess, (state, payload) => ({
    ...state,
    exercises: state.exerciseQuery.pageNumber === 1 ? payload.response.content : state.exercises.concat(payload.response.content),
    totalExercises: payload.response.totalRecords,
    isLoadingExercises: false,
  })),
  on(TemplateActions.fetchExercises, state => ({
    ...state,
    isLoadingExercises: true,
  })),
  on(TemplateActions.fetchExercisesFailure, state => ({
    ...state,
    isLoadingExercises: false,
  })),
  on(TemplateActions.setExercisesQuery, (state, payload) => ({
    ...state,
    exerciseQuery: {
      ...state.exerciseQuery,
      ...payload.query,
    },
  })),
  on(TemplateActions.nextPage, state => ({
    ...state,
    exerciseQuery: {
      ...state.exerciseQuery,
      pageNumber: state.exerciseQuery.pageNumber + 1,
    },
  })),
  on(TemplateActions.reset, () => initialState),
);
