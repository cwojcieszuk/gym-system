import { createReducer } from '@ngrx/store';

export const COACHES_FEATURE_KEY = 'coaches';

export interface CoachesState {
  coaches: any;
}

const initialState: CoachesState = {
  coaches: [],
};

export const coachesReducer = createReducer<CoachesState>(
  initialState
);
