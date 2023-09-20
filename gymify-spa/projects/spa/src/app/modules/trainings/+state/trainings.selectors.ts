import { createFeatureSelector, createSelector } from '@ngrx/store';
import { TRAININGS_FEATURE_KEY, TrainingsState } from './trainings.reducer';

export const getTrainingsState = createFeatureSelector<TrainingsState>(TRAININGS_FEATURE_KEY);

export const getTrainingsResponse = createSelector(
  getTrainingsState,
  state => state.trainingsResponse
);

export const getQuery = createSelector(
  getTrainingsState,
  state => state.query
);
