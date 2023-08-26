import { createFeatureSelector } from '@ngrx/store';
import { EXERCISES_FEATURE_KEY } from './exercises.reducer';

export const getExercisesState = createFeatureSelector(EXERCISES_FEATURE_KEY);
