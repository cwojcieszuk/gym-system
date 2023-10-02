import { createReducer, on } from '@ngrx/store';
import { TrainingsResponse } from '../../../../../../api-client/src/lib/clients/trainings/responses/trainings.response';
import { PagedRequest } from '../../../../../../api-client/src/lib/models/paged-request';
import * as TrainingActions from './trainings.actions';
import { TrainingDetailsDTO } from '../../../../../../api-client/src/lib/clients/trainings/models/training-details.dto';
import { UUID } from '../../../../../../api-client/src/lib/types/uuid.type';
import { TemplateDetailsDTO } from '../../../../../../api-client/src/lib/clients/templates/models/template.details.dto';

export const TRAININGS_FEATURE_KEY = 'trainings';

export interface TrainingsState {
  trainingsResponse?: TrainingsResponse;
  query: PagedRequest;
  trainingDetails?: TrainingDetailsDTO;

  selectedTraining?: UUID;
  searchedTemplates: TemplateDetailsDTO[];
}

const initialState: TrainingsState = {
  query: {
    pageNumber: 1,
    pageSize: 10,
  },
  searchedTemplates: [],
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
      ...payload.query,
    },
  })),
  on(TrainingActions.selectTraining, (state, payload) => ({
    ...state,
    selectedTraining: payload.trainingUid,
  })),
  on(TrainingActions.fetchTrainingDetailsSuccess, (state, payload) => ({
    ...state,
    trainingDetails: payload,
  })),
  on(TrainingActions.fetchTemplatesBySearchSuccess, (state, payload) => ({
    ...state,
    searchedTemplates: payload.response,
  })),
  on(TrainingActions.reset, () => initialState)
);

