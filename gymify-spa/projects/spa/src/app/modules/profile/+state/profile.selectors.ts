import { createFeatureSelector, createSelector } from '@ngrx/store';
import { PROFILE_FEATURE_KEY, ProfileState } from './profile.reducer';

export const getProfileState = createFeatureSelector<ProfileState>(PROFILE_FEATURE_KEY);

export const getUser = createSelector(
  getProfileState,
  state => state.user
);

export const getIsEditing = createSelector(
  getProfileState,
  state => state.isEditing
);

export const getIsPasswordEdit = createSelector(
  getProfileState,
  state => state.isPasswordEdit
);

export const getAvatar = createSelector(
  getProfileState,
  state => state.avatar
);

export const getIsEditAvatar = createSelector(
  getProfileState,
  state => state.isAvatarEdit
);

export const getIsCoachDetailsEdit = createSelector(
  getProfileState,
  state => state.isCoachDetailsEdit
);
