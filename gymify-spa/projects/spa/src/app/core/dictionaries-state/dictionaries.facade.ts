import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import * as DictionariesActions from './dictionaries.actions';
import * as DictionariesSelectors from './dictionaries.selectors';

@Injectable({ providedIn: 'root' })
export class DictionariesFacade {
  userRoles$ = this.store.select(DictionariesSelectors.getUserRoles);
  bodyParts$ = this.store.select(DictionariesSelectors.getBodyParts);
  equipments$ = this.store.select(DictionariesSelectors.getEquipments);
  targets$ = this.store.select(DictionariesSelectors.getTargets);
  difficultyLevels$ = this.store.select(DictionariesSelectors.getDifficultyLevels);
  coachCategories$ = this.store.select(DictionariesSelectors.getCoachCategories);

  constructor(private store: Store) {}

  fetchUserRoles(): void {
    this.store.dispatch(DictionariesActions.fetchUserRoles());
  }

  fetchBodyParts(): void {
    this.store.dispatch(DictionariesActions.fetchBodyParts());
  }

  fetchEquipments(): void {
    this.store.dispatch(DictionariesActions.fetchEquipments());
  }

  fetchTargets(): void {
    this.store.dispatch(DictionariesActions.fetchTargets());
  }

  fetchDifficultyLevels(): void {
    this.store.dispatch(DictionariesActions.fetchDifficultyLevels());
  }

  fetchCoachCategories(): void {
    this.store.dispatch(DictionariesActions.fetchCoachCategories());
  }
}
