import { createReducer } from '@ngrx/store';

export const GROUP_SESSIONS_FEATURE_KEY = 'group-sessions';

export interface GroupSessionsState {
  groupSessionsResponse?: any;
}

const initialState: GroupSessionsState = {

};

export const groupSessionsReducer = createReducer(
  initialState,
);
