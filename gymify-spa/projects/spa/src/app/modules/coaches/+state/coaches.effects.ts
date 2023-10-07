import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { CoachesClient } from '../../../../../../api-client/src/lib/clients/coaches/coaches.client';
import * as CoachActions from './coaches.actions';
import { catchError, map, mergeMap, of, tap, withLatestFrom } from 'rxjs';
import { CoachesFacade } from './coaches.facade';
import { ToastrService } from 'ngx-toastr';

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

  likeCoach$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CoachActions.likeCoach),
      mergeMap(({ coachUid }) => this.coachesClient.likeCoach(coachUid).pipe(
        map(() => CoachActions.likeCoachSuccess({ coachUid })),
        catchError(() => of(CoachActions.likeCoachFailure()))
      ))
    )
  );

  dislikeCoach$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CoachActions.dislikeCoach),
      mergeMap(({ coachUid }) => this.coachesClient.dislikeCoach(coachUid).pipe(
        map(() => CoachActions.dislikeCoachSuccess({ coachUid })),
        catchError(() => of(CoachActions.dislikeCoachFailure()))
      ))
    )
  );

  likeCoachSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CoachActions.likeCoachSuccess),
      tap(() => this.toastr.success('Successfully liked coach'))
    ), { dispatch: false });

  likeCoachFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CoachActions.likeCoachFailure),
      tap(() => this.toastr.error('Unable to like coach'))
    ), { dispatch: false });

  dislikeCoachSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CoachActions.dislikeCoachSuccess),
      tap(() => this.toastr.success('Successfully disliked coach'))
    ), { dispatch: false });

  dislikeCoachFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CoachActions.dislikeCoachFailure),
      tap(() => this.toastr.error('Unable to unlike coach'))
    ), { dispatch: false });

  constructor(
    private readonly actions$: Actions,
    private readonly coachesClient: CoachesClient,
    private readonly coachesFacade: CoachesFacade,
    private readonly toastr: ToastrService
  ) {}
}
