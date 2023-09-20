import { createReducer, on } from '@ngrx/store';
import { TrainingsResponse } from '../../../../../../api-client/src/lib/clients/trainings/responses/trainings.response';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';
import * as TrainingActions from './trainings.actions';

export const TRAININGS_FEATURE_KEY = 'trainings';

export interface TrainingsState {
  trainingsResponse?: TrainingsResponse;
  query: PagedRequest;
}

const initialState: TrainingsState = {
  query: {
    pageNumber: 1,
    pageSize: 10,
  },
};

export const trainingsReducer = createReducer<TrainingsState>(
  initialState,
  on(TrainingActions.fetchTrainingsSuccess, (state, payload) => ({
    ...state,
    trainingsResponse: payload,
  })),
  on(TrainingActions.setQuery, (state, payload) => ({
    ...state,
    query: {
      ...state.query,
      ...payload,
    },
  }))
);

