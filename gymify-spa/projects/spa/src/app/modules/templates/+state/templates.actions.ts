import { createAction, props } from '@ngrx/store';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';
import { TemplatesResponse } from '../../../../../../api-client/src/lib/clients/templates/responses/templates.response';

export const fetchTemplates = createAction(
  '[Templates/API] Fetch Templates'
);

export const fetchTemplatesSuccess = createAction(
  '[Templates/API] Fetch Templates Success',
  props<{ response: TemplatesResponse }>()
);

export const fetchTemplatesFailure = createAction(
  '[Templates/API] Fetch Templates Failure'
);

export const setQuery = createAction(
  '[Templates] Set Query',
  props<{ query: Partial<PagedRequest> }>()
);
