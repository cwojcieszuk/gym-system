import { createAction, props } from '@ngrx/store';
import { UserListResponse } from '../../../../../../api-client/src/lib/clients/users/responses/user-list.response';
import { UserListFilters } from '../../../../../../api-client/src/lib/clients/users/params/user-list.filters';
import { AddUserParams } from '../../../../../../api-client/src/lib/clients/users/params/add-user.params';
import { EditUserParams } from '../../../../../../api-client/src/lib/clients/users/params/edit-user.params';
import { UUID } from '../../../../../../api-client/src/lib/types/uuid.type';

export const fetchUsers = createAction(
  '[Users/API] Fetch Users'
);

export const fetchUsersSuccess = createAction(
  '[Users/API] Fetch Users Success',
  props<UserListResponse>()
);

export const fetchUsersFailure = createAction(
  '[Users/API] Fetch Users Failure'
);

export const setFilters = createAction(
  '[Users] Set Filters',
  props<Partial<UserListFilters>>()
);

export const addUser = createAction(
  '[Users/API] Add User',
  props<AddUserParams>()
);

export const addUserSuccess = createAction(
  '[Users/API] Add User Success'
);

export const addUserFailure = createAction(
  '[Users/API] Add User Failure'
);

export const editUser = createAction(
  '[Users/API] Edit User',
  props<EditUserParams>()
);

export const editUserSuccess = createAction(
  '[Users/API] Edit User Success'
);

export const editUserFailure = createAction(
  '[Users/API] Edit User Failure'
);

export const deleteUser = createAction(
  '[Users/API] Delete User',
  props<{ userUid: UUID }>()
);

export const deleteUserSuccess = createAction(
  '[Users/API] Delete User Success'
);

export const deleteUserFailure = createAction(
  '[Users/API] Delete User Failure'
);
