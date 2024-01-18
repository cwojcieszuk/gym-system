import { createReducer, on } from '@ngrx/store';
import { GroupSessionListResponse } from '../../../../../../api-client/src/lib/clients/group-sessions/responses/group-session-list.response';

import * as GroupSessionActions from './group-sessions.actions';
import { GroupSessionListFilters } from '../../../../../../api-client/src/lib/clients/group-sessions/params/group-session-list.filters';

export const GROUP_SESSIONS_FEATURE_KEY = 'group-sessions';

export interface GroupSessionsState {
  groupSessionsResponse?: GroupSessionListResponse;
  query: GroupSessionListFilters;
}

const initialState: GroupSessionsState = {
  query: {
    pageNumber: 1,
    pageSize: 15,
    name: '',
  },
};

export const groupSessionsReducer = createReducer(
  initialState,
  on(GroupSessionActions.fetchGroupSessionsSuccess, (state, payload) => ({
    ...state,
    groupSessionsResponse: payload.response,
  })),
  on(GroupSessionActions.setFilters, (state, payload) => ({
    ...state,
    query: {
      ...state.query,
      ...payload.params,
    },
  }))
);
