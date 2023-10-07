import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { CoachesClient } from '../../../../../../api-client/src/lib/clients/coaches/coaches.client';
import * as CoachActions from './coaches.actions';
import { catchError, map, mergeMap, of, withLatestFrom } from 'rxjs';
import { CoachesFacade } from './coaches.facade';

@Injectable({ providedIn: 'root' })
export class CoachesEffects {

  fetchCoaches$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CoachActions.fetchCoaches),
      withLatestFrom(this.coachesFacade.coachesQuery$),
      mergeMap(([, query]) => this.coachesClient.getCoaches(query).pipe(
        map(response => CoachActions.fetchCoachesSuccess({ response })),
        catchError(() => of(CoachActions.fetchCoachesFailure()))
      ))
    )
  );

  refreshCoaches$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CoachActions.setCoachesQuery),
      map(() => CoachActions.fetchCoaches())
    )
  );

  constructor(
    private readonly actions$: Actions,
    private readonly coachesClient: CoachesClient,
    private readonly coachesFacade: CoachesFacade
  ) {}
}
