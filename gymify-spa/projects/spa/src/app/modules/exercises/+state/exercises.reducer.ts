import { createReducer } from '@ngrx/store';

export const EXERCISES_FEATURE_KEY = 'exercises';

export interface ExercisesState {
  exercises: any;
}

const initialState: ExercisesState = {
  exercises: [],
};

export const exercisesReducer = createReducer(
  initialState
);
