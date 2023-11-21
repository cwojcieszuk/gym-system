import { createFeatureSelector } from '@ngrx/store';
import { DASHBOARD_FEATURE_KEY, DashboardState } from './dashboard.reducer';

const getDashboardState = createFeatureSelector<DashboardState>(DASHBOARD_FEATURE_KEY);
