import { createReducer, on } from '@ngrx/store';
import { PagedResponse } from '../../../../../../api-client/src/lib/models/paged-response';
import { CoachDTO } from '../../../../../../api-client/src/lib/clients/coaches/models/coach.dto';
import { GetCoachesParams } from '../../../../../../api-client/src/lib/clients/coaches/params/get-coaches.params';

import * as CoachActions from './coaches.actions';
import { CoachHourDTO } from '../../../../../../api-client/src/lib/clients/coaches/models/coach-hour.dto';
import { UUID } from '../../../../../../api-client/src/lib/types/uuid.type';

export const COACHES_FEATURE_KEY = 'coaches';

export interface CoachesState {
  coachesResponse?: PagedResponse<CoachDTO>;
  coachesQuery: GetCoachesParams;
  areCoachesLoading: boolean;
  coachHours: CoachHourDTO[];
  selectedCoachHour?: UUID;
  coachHoursDate: Date | null;
}

const initialState: CoachesState = {
  coachesQuery: {
    pageNumber: 1,
    pageSize: 10,
  },
  areCoachesLoading: false,
  coachHours: [],
  coachHoursDate: null,
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
  })),
  on(CoachActions.likeCoachSuccess, (state, payload) => ({
    ...state,
    coachesResponse: state.coachesResponse == null ? undefined : {
      ...state.coachesResponse,
      content: state.coachesResponse.content.map(coach => coach.coachUid === payload.coachUid ? ({ ...coach, isFavorite: true }) : coach),
    },
  })),
  on(CoachActions.dislikeCoachSuccess, (state, payload) => ({
    ...state,
    coachesResponse: state.coachesResponse == null ? undefined : {
      ...state.coachesResponse,
      content: state.coachesResponse.content.map(coach => coach.coachUid === payload.coachUid ? ({ ...coach, isFavorite: false }) : coach),
    },
  })),
  on(CoachActions.getCoachHoursByDateSuccess, (state, payload) => ({
    ...state,
    coachHours: payload.hours,
    selectedCoachHour: undefined,
  })),
  on(CoachActions.selectHour, (state, payload) => ({
    ...state,
    selectedCoachHour: payload.coachHourUid,
  })),
  on(CoachActions.signupForCoachSuccess, state => ({
    ...state,
    selectedCoachHour: undefined,
  }))
);
