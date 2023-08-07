import { createReducer, on } from '@ngrx/store';
import * as UsersActions from './users.actions';
import { UserListFilters } from '../../../../../../api-client/src/lib/clients/users/params/user-list.filters';
import { UserListResponse } from '../../../../../../api-client/src/lib/clients/users/responses/user-list.response';

export const USERS_FEATURE_KEY = 'users';

export interface UsersState {
  userFilters: UserListFilters;
  userListResponse?: UserListResponse;
}

const initialState: UsersState = {
  userFilters: {
    pageNumber: 1,
    pageSize: 10,
    name: '',
    role: '',
  },
};

export const usersReducer = createReducer(
  initialState,
  on(UsersActions.fetchUsersSuccess, (state, payload) => ({
    ...state,
    userListResponse: payload,
  })),
  on(UsersActions.setFilters, (state, payload) => ({
    ...state,
    userFilters: {
      ...state.userFilters,
      ...payload,
    },
  }))
);
