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

  constructor(
    private actions$: Actions,
    private dictionariesClient: DictionariesClient
  ) {}
}
