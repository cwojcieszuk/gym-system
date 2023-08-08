import { Injectable } from '@angular/core';
import * as UsersActions from './users.actions';
import * as UsersSelectors from './users.selectors';
import { Store } from '@ngrx/store';
import { UserListFilters } from '../../../../../../api-client/src/lib/clients/users/params/user-list.filters';
import { AddUserParams } from '../../../../../../api-client/src/lib/clients/users/params/add-user.params';
import { EditUserParams } from '../../../../../../api-client/src/lib/clients/users/params/edit-user.params';

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

  addUser(params: AddUserParams): void {
    this.store.dispatch(UsersActions.addUser(params));
  }

  editUser(params: EditUserParams): void {
    this.store.dispatch(UsersActions.editUser(params));
  }
}
