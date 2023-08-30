import { createReducer, on } from '@ngrx/store';
import * as TemplateActions from './templates.actions';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';
import { TemplatesResponse } from '../../../../../../api-client/src/lib/clients/templates/responses/templates.response';

export const TEMPLATES_FEATURE_KEY = 'templates';

export interface TemplatesState {
  templatesResponse?: TemplatesResponse;
  query: PagedRequest;
}

const initialState: TemplatesState = {
  query: {
    pageNumber: 1,
    pageSize: 10,
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
  }))
);
