import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { DictionariesClient } from '../../../../../api-client/src/lib/clients/dictionaries/dictionaries.client';
import * as DictionariesActions from './dictionaries.actions';
import { catchError, map, mergeMap, of } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class DictionariesEffects {

  fetchUserRoles$ = createEffect(() =>
    this.actions$.pipe(
      ofType(DictionariesActions.fetchUserRoles),
      mergeMap(() => this.dictionariesClient.getUserRoles().pipe(
        map(data => DictionariesActions.fetchUserRolesSuccess({ data })),
        catchError(() => of(DictionariesActions.fetchUserRolesFailure()))
      ))
    )
  );

  fetchBodyParts$ = createEffect(() =>
    this.actions$.pipe(
      ofType(DictionariesActions.fetchBodyParts),
      mergeMap(() => this.dictionariesClient.getBodyParts().pipe(
        map(data => DictionariesActions.fetchBodyPartsSuccess({ data })),
        catchError(() => of(DictionariesActions.fetchBodyPartsFailure()))
      ))
    )
  );

  fetchEquipments$ = createEffect(() =>
    this.actions$.pipe(
      ofType(DictionariesActions.fetchEquipments),
      mergeMap(() => this.dictionariesClient.getEquipments().pipe(
        map(data => DictionariesActions.fetchEquipmentsSuccess({ data })),
        catchError(() => of(DictionariesActions.fetchEquipmentsFailure()))
      ))
    )
  );

  fetchTargets$ = createEffect(() =>
    this.actions$.pipe(
      ofType(DictionariesActions.fetchTargets),
      mergeMap(() => this.dictionariesClient.getTargets().pipe(
        map(data => DictionariesActions.fetchTargetsSuccess({ data })),
        catchError(() => of(DictionariesActions.fetchTargetsFailure()))
      ))
    )
  );

  fetchDifficultyLevels$ = createEffect(() =>
    this.actions$.pipe(
      ofType(DictionariesActions.fetchDifficultyLevels),
      mergeMap(() => this.dictionariesClient.getDifficultyLevels().pipe(
        map(data => DictionariesActions.fetchDifficultyLevelsSuccess({ data })),
        catchError(() => of(DictionariesActions.fetchDifficultyLevelsFailure()))
      ))
    )
  );

  constructor(
    private actions$: Actions,
    private dictionariesClient: DictionariesClient
  ) {}
}
