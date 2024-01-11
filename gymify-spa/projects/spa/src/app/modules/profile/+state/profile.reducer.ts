import { createReducer, on } from '@ngrx/store';
import * as ProfileActions from './profile.actions';
import { UserDataResponse } from '../../../../../../api-client/src/lib/clients/profile/responses/user-data.response';

export const PROFILE_FEATURE_KEY = 'profile';

export interface ProfileState {
  user?: UserDataResponse;
  isEditing: boolean;
  isPasswordEdit: boolean;
  isAvatarEdit: boolean;
  avatar?: File;
  isCoachDetailsEdit: boolean;
}

const initialState: ProfileState = {
  isEditing: false,
  isPasswordEdit: false,
  isAvatarEdit: false,
  isCoachDetailsEdit: false,
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
  })),
  on(ProfileActions.setAvatar, (state, payload) => ({
    ...state,
    avatar: payload.avatar,
  })),
  on(ProfileActions.editAvatar, state => ({
    ...state,
    isAvatarEdit: true,
  })),
  on(ProfileActions.cancelEditAvatar, state => ({
    ...state,
    isAvatarEdit: false,
  })),
  on(ProfileActions.editCoachDetails, state => ({
    ...state,
    isCoachDetailsEdit: true,
  })),
  on(ProfileActions.cancelEditCoachDetails,state => ({
    ...state,
    isCoachDetailsEdit: false,
  }))
);
