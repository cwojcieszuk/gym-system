import { createFeatureSelector, createSelector } from '@ngrx/store';
import { DASHBOARD_FEATURE_KEY, DashboardState } from './dashboard.reducer';

const getDashboardState = createFeatureSelector<DashboardState>(DASHBOARD_FEATURE_KEY);

export const getPopularCoaches = createSelector(
  getDashboardState,
  state => state.popularCoaches
);

export const getPopularExercises = createSelector(
  getDashboardState,
  state => state.popularExercises
);

export const getIncomingGroupSessions = createSelector(
  getDashboardState,
  state => state.incomingGroupSessions
);

export const getRecentTemplates = createSelector(
  getDashboardState,
  state => state.recentTemplates
);
