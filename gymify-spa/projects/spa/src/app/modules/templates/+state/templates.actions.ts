import { createAction, props } from '@ngrx/store';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';
import { TemplatesResponse } from '../../../../../../api-client/src/lib/clients/templates/responses/templates.response';
import {
  ExerciseListResponse
} from '../../../../../../api-client/src/lib/clients/exercises/responses/exercise-list.response';
import { ExerciseListParams } from '../../../../../../api-client/src/lib/clients/exercises/params/exercise-list-params';
import {
  CreateTemplateParams
} from '../../../../../../api-client/src/lib/clients/templates/params/create-template.params';

export const fetchPersonalTemplates = createAction(
  '[Templates/API] Fetch Personal Templates'
);

export const fetchPersonalTemplatesSuccess = createAction(
  '[Templates/API] Fetch Personal Templates Success',
  props<{ response: TemplatesResponse }>()
);

export const fetchPersonalTemplatesFailure = createAction(
  '[Templates/API] Fetch Personal Templates Failure'
);

export const fetchCommunityTemplates = createAction(
  '[Templates/API] Fetch Community Templates'
);

export const fetchCommunityTemplatesSuccess = createAction(
  '[Templates/API] Fetch Community Templates Success',
  props<{ response: TemplatesResponse }>()
);

export const fetchCommunityTemplatesFailure = createAction(
  '[Templates/API] Fetch Community Templates Failure'
);

export const setQuery = createAction(
  '[Templates] Set Query',
  props<{ query: Partial<PagedRequest> }>()
);

export const fetchExercises = createAction(
  '[Templates/API] Fetch Exercises'
);

export const fetchExercisesSuccess = createAction(
  '[Templates/API] Fetch Exercises Success',
  props<{ response: ExerciseListResponse }>()
);

export const fetchExercisesFailure = createAction(
  '[Templates/API] Fetch Exercises Failure'
);

export const setExercisesQuery = createAction(
  '[Templates] Set Exercises Query',
  props<{ query: Partial<ExerciseListParams> }>()
);

export const nextPage = createAction(
  '[Templates] Next Page'
);

export const createTemplate = createAction(
  '[Templates/API] Create Template',
  props<{ params: CreateTemplateParams }>()
);

export const createTemplateSuccess = createAction(
  '[Templates/API] Create Template Success'
);

export const createTemplateFailure = createAction(
  '[Templates/API] Create Template Failure'
);

export const reset = createAction(
  '[Templates] Reset'
);
