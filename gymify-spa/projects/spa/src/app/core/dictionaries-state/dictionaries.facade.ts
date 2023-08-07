import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import * as DictionariesActions from './dictionaries.actions';
import * as DictionariesSelectors from './dictionaries.selectors';

@Injectable({ providedIn: 'root' })
export class DictionariesFacade {
  userRoles$ = this.store.select(DictionariesSelectors.getUserRoles);

  constructor(private store: Store) {}

  fetchUserRoles(): void {
    this.store.dispatch(DictionariesActions.fetchUserRoles());
  }
}
