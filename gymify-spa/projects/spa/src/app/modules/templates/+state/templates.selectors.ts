import { createFeatureSelector, createSelector } from '@ngrx/store';
import { TEMPLATES_FEATURE_KEY, TemplatesState } from './templates.reducer';

export const getTemplatesState = createFeatureSelector<TemplatesState>(TEMPLATES_FEATURE_KEY);

export const getTemplatesResponse = createSelector(
  getTemplatesState,
  state => state.templatesResponse
);

export const getQuery = createSelector(
  getTemplatesState,
  state => state.query
);

export const getExercises = createSelector(
  getTemplatesState,
  state => state.exercises
);

export const getExercisesQuery = createSelector(
  getTemplatesState,
  state => state.exerciseQuery
);

export const areAllExercisesLoaded = createSelector(
  getTemplatesState,
  state => state.exercises.length === state.totalExercises
);

export const isLoadingExercises = createSelector(
  getTemplatesState,
  state => state.isLoadingExercises
);
