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
