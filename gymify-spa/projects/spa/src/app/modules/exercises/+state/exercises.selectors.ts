import { createFeatureSelector, createSelector } from '@ngrx/store';
import { EXERCISES_FEATURE_KEY, ExercisesState } from './exercises.reducer';

export const getExercisesState = createFeatureSelector<ExercisesState>(EXERCISES_FEATURE_KEY);

export const getExerciseResponse = createSelector(
  getExercisesState,
  state => state.exerciseResponse
);

export const getExercisesQuery = createSelector(
  getExercisesState,
  state => state.query
);

export const getIsLoading = createSelector(
  getExercisesState,
  state => state.isLoading
);
