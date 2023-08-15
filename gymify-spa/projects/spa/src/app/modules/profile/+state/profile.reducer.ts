import { createReducer, on } from '@ngrx/store';
import * as ProfileActions from './profile.actions';
import { UserDataResponse } from '../../../../../../api-client/src/lib/clients/profile/responses/user-data.response';

export const PROFILE_FEATURE_KEY = 'profile';

export interface ProfileState {
  user?: UserDataResponse;
  isEditing: boolean;
  isPasswordEdit: boolean;
}

const initialState: ProfileState = {
  isEditing: false,
  isPasswordEdit: false,
};

export const profileReducer = createReducer(
  initialState,
  on(ProfileActions.fetchUserDataSuccess, (state, payload) => ({
    ...state,
    user: payload.response,
  })),
  on(ProfileActions.toggleEdit, state => ({
    ...state,
    isEditing: true,
  })),
  on(ProfileActions.cancelEdit, state => ({
    ...state,
    isEditing: false,
  })),
  on(ProfileActions.togglePasswordEdit, state => ({
    ...state,
    isPasswordEdit: true,
  })),
  on(ProfileActions.cancelPasswordEdit, state => ({
    ...state,
    isPasswordEdit: false,
  }))
);
