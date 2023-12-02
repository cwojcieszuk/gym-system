import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import * as DashboardActions from './dashboard.actions';
import * as DashboardSelectors from './dashboard.selectors';

@Injectable({ providedIn: 'root' })
export class DashboardFacade {
  popularCoaches$ = this.store.select(DashboardSelectors.getPopularCoaches);
  popularExercises$ = this.store.select(DashboardSelectors.getPopularExercises);
  incomingGroupSessions$ = this.store.select(DashboardSelectors.getIncomingGroupSessions);
  recentTemplates$ = this.store.select(DashboardSelectors.getRecentTemplates);

  areExercisesLoading$ = this.store.select(DashboardSelectors.areExercisesLoading);
  areCoachesLoading$ = this.store.select(DashboardSelectors.areCoachesLoading);
  areTemplatesLoading$ = this.store.select(DashboardSelectors.areTemplatesLoading);
  areGroupSessionsLoading$ = this.store.select(DashboardSelectors.areGroupSessionsLoading);

  constructor(private store: Store) {}

  getPopularCoaches(): void {
    this.store.dispatch(DashboardActions.fetchPopularCoaches());
  }

  getPopularExercises(): void {
    this.store.dispatch(DashboardActions.fetchPopularExercises());
  }

  getIncomingGroupSessions(): void {
    this.store.dispatch(DashboardActions.fetchIncomingGroupSessions());
  }

  getRecentTemplates(): void {
    this.store.dispatch(DashboardActions.fetchRecentTemplates());
  }
}
