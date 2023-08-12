import { createFeatureSelector } from '@ngrx/store';
import { PROFILE_FEATURE_KEY, ProfileState } from './profile.reducer';

export const getProfileState = createFeatureSelector<ProfileState>(PROFILE_FEATURE_KEY);
