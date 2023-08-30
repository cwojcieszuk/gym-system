import { createAction, props } from '@ngrx/store';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';
import { TemplatesResponse } from '../../../../../../api-client/src/lib/clients/templates/responses/templates.response';

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
