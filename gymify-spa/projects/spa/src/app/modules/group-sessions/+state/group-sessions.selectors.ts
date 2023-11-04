import { createFeatureSelector } from '@ngrx/store';
import { GROUP_SESSIONS_FEATURE_KEY, GroupSessionsState } from './group-sessions.reducer';

export const getGroupSessionsState = createFeatureSelector<GroupSessionsState>(GROUP_SESSIONS_FEATURE_KEY);
