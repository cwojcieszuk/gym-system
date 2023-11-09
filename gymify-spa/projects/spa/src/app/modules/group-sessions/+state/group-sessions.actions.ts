import { createAction, props } from '@ngrx/store';
import { GroupSessionListFilters } from '../../../../../../api-client/src/lib/clients/group-sessions/params/group-session-list.filters';
import { GroupSessionListResponse } from '../../../../../../api-client/src/lib/clients/group-sessions/responses/group-session-list.response';
import { UUID } from '../../../../../../api-client/src/lib/types/uuid.type';

export const setFilters = createAction(
  '[Group Sessions] Set Filters',
  props<{ params: Partial<GroupSessionListFilters> }>()
);

export const fetchGroupSessions = createAction(
  '[Group Sessions] Fetch Group Sessions'
);

export const fetchGroupSessionsSuccess = createAction(
  '[Group Sessions] Fetch Group Sessions Success',
  props<{ response: GroupSessionListResponse }>()
);

export const fetchGroupSessionsFailure = createAction(
  '[Group Sessions] Fetch Group Sessions Failure'
);

export const bookIn = createAction(
  '[Group Sessions] Book In',
  props<{ groupSessionUid: UUID }>()
);

export const bookInSuccess = createAction(
  '[Group Sessions] Book In Success'
);

export const bookInFailure = createAction(
  '[Group Sessions] Book In Failure'
);

export const resign = createAction(
  '[Group Sessions] Resign',
  props<{ groupSessionUid: UUID }>()
);

export const resignSuccess = createAction(
  '[Group Sessions] Resign Success'
);

export const resignFailure = createAction(
  '[Group Sessions] Resign Failure'
);