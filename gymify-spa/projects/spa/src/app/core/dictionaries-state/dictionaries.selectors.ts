import { createFeatureSelector, createSelector } from '@ngrx/store';
import { DICTIONARIES_FEATURE_KEY, DictionariesState } from './dictionaries.reducer';

export const getDictionariesState = createFeatureSelector<DictionariesState>(DICTIONARIES_FEATURE_KEY);

export const getUserRoles = createSelector(
  getDictionariesState,
  state => state.userRoles
);
