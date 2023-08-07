import { createAction, props } from '@ngrx/store';
import { UserRole } from '../../../../../api-client/src/lib/clients/dictionaries/responses/user-role.response';

export const fetchUserRoles = createAction(
  '[Dictionaries/API] Fetch User Roles'
);

export const fetchUserRolesSuccess = createAction(
  '[Dictionaries/API] Fetch User Roles Success',
  props<{ data: UserRole[] }>()
);

export const fetchUserRolesFailure = createAction(
  '[Dictionaries/API] Fetch User Roles Failure'
);
