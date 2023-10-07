import { createReducer, on } from '@ngrx/store';
import { PagedResponse } from '../../../../../../api-client/src/lib/models/paged-response';
import { CoachDTO } from '../../../../../../api-client/src/lib/clients/coaches/models/coach.dto';
import { GetCoachesParams } from '../../../../../../api-client/src/lib/clients/coaches/params/get-coaches.params';

import * as CoachActions from './coaches.actions';

export const COACHES_FEATURE_KEY = 'coaches';

export interface CoachesState {
  coachesResponse?: PagedResponse<CoachDTO>;
  coachesQuery: GetCoachesParams;
  areCoachesLoading: boolean;
}

const initialState: CoachesState = {
  coachesQuery: {
    pageNumber: 1,
    pageSize: 10,
  },
  areCoachesLoading: false,
};

export const coachesReducer = createReducer<CoachesState>(
  initialState,
  on(CoachActions.fetchCoachesSuccess, (state, payload) => ({
    ...state,
    coachesResponse: payload.response,
  })),
  on(CoachActions.fetchCoaches, state => ({
    ...state,
    areCoachesLoading: true,
  })),
  on(CoachActions.fetchCoachesSuccess, CoachActions.fetchCoachesFailure, state => ({
    ...state,
    areCoachesLoading: false,
  })),
  on(CoachActions.setCoachesQuery, (state, payload) => ({
    ...state,
    coachesQuery: {
      ...state.coachesQuery,
      ...payload.query,
      pageNumber: 1,
    },
  })),
  on(CoachActions.pageChange, (state, payload) => ({
    ...state,
    coachesQuery: {
      ...state.coachesQuery,
      pageNumber: payload.page,
    },
  }))
);
