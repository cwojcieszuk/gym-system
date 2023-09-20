import { createFeatureSelector } from '@ngrx/store';
import { TRAININGS_FEATURE_KEY, TrainingsState } from './trainings.reducer';

export const getTrainingsState = createFeatureSelector<TrainingsState>(TRAININGS_FEATURE_KEY);
