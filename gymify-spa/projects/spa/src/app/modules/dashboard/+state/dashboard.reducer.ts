import { createReducer } from '@ngrx/store';

export const DASHBOARD_FEATURE_KEY = 'dashboard';

export interface DashboardState {
  popularCoaches: any;
}

const initialState: DashboardState = {
  popularCoaches: [],
};

export const dashboardReducer = createReducer<DashboardState>(
  initialState
);
