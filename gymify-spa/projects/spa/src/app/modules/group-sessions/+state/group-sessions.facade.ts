import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';

import * as GroupSessionSelectors from './group-sessions.selectors';
import * as GroupSessionActions from './group-sessions.actions';
import { GroupSessionListFilters } from '../../../../../../api-client/src/lib/clients/group-sessions/params/group-session-list.filters';
import { UUID } from '../../../../../../api-client/src/lib/types/uuid.type';

@Injectable({ providedIn: 'root' })
export class GroupSessionsFacade {
  groupSessionsResponse$ = this.store.select(GroupSessionSelectors.getGroupSessionsResponse);
  query$ = this.store.select(GroupSessionSelectors.getGroupSessionsQuery);

  constructor(private store: Store) {}

  setFilters(params: Partial<GroupSessionListFilters>): void {
    this.store.dispatch(GroupSessionActions.setFilters({ params }));
  }

  fetchGroupSessions(): void {
    this.store.dispatch(GroupSessionActions.fetchGroupSessions());
  }

  bookIn(groupSessionUid: UUID): void {
    this.store.dispatch(GroupSessionActions.bookIn({ groupSessionUid }));
  }

  resign(groupSessionUid: UUID): void {
    this.store.dispatch(GroupSessionActions.resign({ groupSessionUid }));
  }
}
