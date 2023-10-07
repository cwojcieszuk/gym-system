import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';

import * as CoachSelectors from './coaches.selectors';
import * as CoachActions from './coaches.actions';
import { GetCoachesParams } from '../../../../../../api-client/src/lib/clients/coaches/params/get-coaches.params';

@Injectable({ providedIn: 'root' })
export class CoachesFacade {
  coachesQuery$ = this.store.select(CoachSelectors.getCoachesQuery);
  coachesResponse$ = this.store.select(CoachSelectors.getCoachesResponse);
  areCoachesLoading$ = this.store.select(CoachSelectors.areCoachesLoading);

  constructor(private store: Store) {}

  fetchCoaches(): void {
    this.store.dispatch(CoachActions.fetchCoaches());
  }

  pageChange(page: number): void {
    this.store.dispatch(CoachActions.pageChange({ page }));
  }

  setCoachesQuery(query: Partial<GetCoachesParams>): void {
    this.store.dispatch(CoachActions.setCoachesQuery({ query }));
  }
}
