import { createFeatureSelector, createSelector } from '@ngrx/store';
import { COACHES_FEATURE_KEY, CoachesState } from './coaches.reducer';

export const getCoachesState = createFeatureSelector<CoachesState>(COACHES_FEATURE_KEY);

export const getCoachesResponse = createSelector(
  getCoachesState,
  state => state.coachesResponse
);

export const getCoachesQuery = createSelector(
  getCoachesState,
  state => state.coachesQuery
);

export const areCoachesLoading = createSelector(
  getCoachesState,
  state => state.areCoachesLoading
);

export const getCoachHours$ = createSelector(
  getCoachesState,
  state => state.coachHours
);

export const getSelectedCoachHour = createSelector(
  getCoachesState,
  state => state.selectedCoachHour
);

export const getCoachHoursDate = createSelector(
  getCoachesState,
  state => state.coachHoursDate
);
