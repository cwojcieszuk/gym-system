import { createReducer } from '@ngrx/store';

export const TRAININGS_FEATURE_KEY = 'trainings';

export interface TrainingsState {
  trainings: any;
}

const initialState: TrainingsState = {
  trainings: [],
};

export const trainingsReducer = createReducer<TrainingsState>(
  initialState
);

