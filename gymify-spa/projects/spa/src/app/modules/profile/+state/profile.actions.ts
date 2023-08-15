import { createAction, props } from '@ngrx/store';
import { UserDataResponse } from '../../../../../../api-client/src/lib/clients/profile/responses/user-data.response';
import {
  UpdateUserDataParams
} from '../../../../../../api-client/src/lib/clients/profile/params/update-user-data.params';
import {
  UpdateUserPasswordParams
} from '../../../../../../api-client/src/lib/clients/profile/params/update-user-password.params';

export const fetchUserData = createAction(
  '[Profile/API] Fetch User Data'
);

export const fetchUserDataSuccess = createAction(
  '[Profile/API] Fetch User Data Success',
  props<{ response: UserDataResponse }>()
);

export const fetchUserDataFailure = createAction(
  '[Profile/API] Fetch User Data Failure'
);

export const toggleEdit = createAction(
  '[Profile] Toggle edit'
);

export const cancelEdit = createAction(
  '[Profile] Cancel edit'
);

export const updateUserData = createAction(
  '[Profile/API] Update User Data',
  props<{ body: UpdateUserDataParams }>()
);

export const updateUserDataSuccess = createAction(
  '[Profile/API] Update User Data Success'
);

export const updateUserDataFailure = createAction(
  '[Profile/API] Update User Data Failure'
);

export const updateUserPassword = createAction(
  '[Profile/API] Update User Password',
  props<{ body: UpdateUserPasswordParams }>()
);

export const updateUserPasswordSuccess = createAction(
  '[Profile/API] Update User Password Success'
);

export const updateUserPasswordFailure = createAction(
  '[Profile/API] Update User Password Failure'
);

export const togglePasswordEdit = createAction(
  '[Profile] Toggle Password Edit'
);

export const cancelPasswordEdit = createAction(
  '[Profile] Cancel Password edit'
);
