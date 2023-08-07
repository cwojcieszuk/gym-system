import { Injectable } from '@angular/core';
import * as UsersActions from './users.actions';
import * as UsersSelectors from './users.selectors';
import { Store } from '@ngrx/store';
import { UserListFilters } from '../../../../../../api-client/src/lib/clients/users/params/user-list.filters';

@Injectable({ providedIn: 'root' })
export class UsersFacade {
  usersResponse$ = this.store.select(UsersSelectors.getUsersResponse);
  filters$ = this.store.select(UsersSelectors.getFilters);

  constructor(private store: Store) {}

  fetchUsers(): void {
    this.store.dispatch(UsersActions.fetchUsers());
  }

  setFilters(filters: Partial<UserListFilters>): void {
    this.store.dispatch(UsersActions.setFilters(filters));
  }
}
