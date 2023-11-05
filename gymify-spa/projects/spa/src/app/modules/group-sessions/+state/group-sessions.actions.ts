import { createAction, props } from '@ngrx/store';
import { GroupSessionListFilters } from '../../../../../../api-client/src/lib/clients/group-sessions/params/group-session-list.filters';
import {
  GroupSessionListResponse
} from '../../../../../../api-client/src/lib/clients/group-sessions/responses/group-session-list.response';

export const setFilters = createAction(
  '[Group Sessions] Set Filters',
  props<{ params: Partial<GroupSessionListFilters> }>()
);

export const fetchGroupSessions = createAction(
  '[Group Sessions] Fetch Group Sessions'
);

export const fetchGroupSessionsSuccess = createAction(
  '[Group Sessions] Fetch Group Sessions Success',
  props<{ response: GroupSessionListResponse }>(),
);

export const fetchGroupSessionsFailure = createAction(
  '[Group Sessions] Fetch Group Sessions Failure'
);
