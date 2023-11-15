import { createFeatureSelector, createSelector } from '@ngrx/store';
import { GROUP_SESSIONS_FEATURE_KEY, GroupSessionsState } from './group-sessions.reducer';

export const getGroupSessionsState = createFeatureSelector<GroupSessionsState>(GROUP_SESSIONS_FEATURE_KEY);

export const getGroupSessionsResponse = createSelector(
  getGroupSessionsState,
  state => state.groupSessionsResponse
);

export const getGroupSessionsQuery = createSelector(
  getGroupSessionsState,
  state => state.query
);
