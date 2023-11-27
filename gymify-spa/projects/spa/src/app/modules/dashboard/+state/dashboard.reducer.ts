import { createReducer, on } from '@ngrx/store';
import * as DashboardActions from './dashboard.actions';
import { PopularCoachDTO } from '../../../../../../api-client/src/lib/clients/dashboard/models/popular-coach.dto';
import { PopularExerciseDTO } from '../../../../../../api-client/src/lib/clients/dashboard/models/popular-exercise.dto';
import {
  IncomingGroupSessionDTO
} from '../../../../../../api-client/src/lib/clients/dashboard/models/incoming-group-session.dto';
import { RecentTemplateDTO } from '../../../../../../api-client/src/lib/clients/dashboard/models/recent-template.dto';

export const DASHBOARD_FEATURE_KEY = 'dashboard';

export interface DashboardState {
  popularCoaches: PopularCoachDTO[];
  popularExercises: PopularExerciseDTO[];
  incomingGroupSessions: IncomingGroupSessionDTO[];
  recentTemplates: RecentTemplateDTO[];

  areCoachesLoading: boolean;
  areExercisesLoading: boolean;
  areGroupSessionsLoading: boolean;
  areTemplatesLoading: boolean;
}

const initialState: DashboardState = {
  popularCoaches: [],
  popularExercises: [],
  incomingGroupSessions: [],
  recentTemplates: [],
  areCoachesLoading: false,
  areExercisesLoading: false,
  areGroupSessionsLoading: false,
  areTemplatesLoading: false,
};

export const dashboardReducer = createReducer<DashboardState>(
  initialState,
  on(DashboardActions.fetchPopularCoachesSuccess, (state, payload) => ({
    ...state,
    popularCoaches: payload.response,
  })),
  on(DashboardActions.fetchPopularExercisesSuccess, (state, payload) => ({
    ...state,
    popularExercises: payload.response,
  })),
  on(DashboardActions.fetchIncomingGroupSessionsSuccess, (state, payload) => ({
    ...state,
    incomingGroupSessions: payload.response,
  })),
  on(DashboardActions.fetchRecentTemplatesSuccess, (state, payload) => ({
    ...state,
    recentTemplates: payload.response,
  })),
  on(DashboardActions.fetchPopularCoaches, state => ({
    ...state,
    areCoachesLoading: true,
  })),
  on(DashboardActions.fetchPopularCoachesSuccess, DashboardActions.fetchPopularCoachesFailure, state => ({
    ...state,
    areCoachesLoading: false,
  })),
  on(DashboardActions.fetchPopularExercises, state => ({
    ...state,
    areExercisesLoading: true,
  })),
  on(DashboardActions.fetchPopularExercisesSuccess, DashboardActions.fetchPopularExercisesFailure, state => ({
    ...state,
    areExercisesLoading: false,
  })),
  on(DashboardActions.fetchRecentTemplates, state => ({
    ...state,
    areTemplatesLoading: true,
  })),
  on(DashboardActions.fetchRecentTemplatesSuccess, DashboardActions.fetchRecentTemplatesFailure, state => ({
    ...state,
    areTemplatesLoading: false,
  })),
  on(DashboardActions.fetchIncomingGroupSessions, state => ({
    ...state,
    areGroupSessionsLoading: true,
  })),
  on(DashboardActions.fetchIncomingGroupSessionsSuccess, DashboardActions.fetchIncomingGroupSessionsFailure, state => ({
    ...state,
    areGroupSessionsLoading: false,
  }))
);
