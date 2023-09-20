import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { TrainingsClient } from '../../../../../../api-client/src/lib/clients/trainings/trainings.client';
import * as TrainingActions from './trainings.actions';
import { catchError, map, mergeMap, of, withLatestFrom } from 'rxjs';
import { TrainingsFacade } from './trainings.facade';

@Injectable({ providedIn: 'root' })
export class TrainingsEffects {

  fetchTrainings$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TrainingActions.fetchTrainings),
      withLatestFrom(this.facade.query$),
      mergeMap(([, query]) =>  this.client.getTrainings(query).pipe(
        map(response => TrainingActions.fetchTrainingsSuccess(response)),
        catchError(() => of(TrainingActions.fetchTrainingsFailure()))
      ))
    )
  );

  setQuery$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TrainingActions.setQuery),
      map(() => TrainingActions.fetchTrainings())
    )
  );

  constructor(
    private readonly actions$: Actions,
    private readonly client: TrainingsClient,
    private readonly facade: TrainingsFacade
  ) {}
}
