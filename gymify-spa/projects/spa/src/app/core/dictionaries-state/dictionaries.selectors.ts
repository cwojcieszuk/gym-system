import { createFeatureSelector, createSelector } from '@ngrx/store';
import { DICTIONARIES_FEATURE_KEY, DictionariesState } from './dictionaries.reducer';

export const getDictionariesState = createFeatureSelector<DictionariesState>(DICTIONARIES_FEATURE_KEY);

export const getUserRoles = createSelector(
  getDictionariesState,
  state => state.userRoles
);

export const getBodyParts = createSelector(
  getDictionariesState,
  state => state.bodyParts
);

export const getEquipments = createSelector(
  getDictionariesState,
  state => state.equipments
);

export const getTargets = createSelector(
  getDictionariesState,
  state => state.targets
);

export const getDifficultyLevels = createSelector(
  getDictionariesState,
  state => state.difficultyLevels
);

export const getCoachCategories = createSelector(
  getDictionariesState,
  state => state.coachCategories
);

export const getPlaces = createSelector(
  getDictionariesState,
  state => state.places
);
