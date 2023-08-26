import { createFeatureSelector, createSelector } from '@ngrx/store';
import { USERS_FEATURE_KEY, UsersState } from './users.reducer';

export const getUsersState = createFeatureSelector<UsersState>(USERS_FEATURE_KEY);

export const getUsersResponse = createSelector(
  getUsersState,
  state => state.userListResponse
);

export const getFilters = createSelector(
  getUsersState,
  state => state.userFilters
);
