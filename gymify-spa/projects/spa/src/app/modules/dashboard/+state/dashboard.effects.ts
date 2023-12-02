import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as DashboardActions from './dashboard.actions';
import { catchError, map, mergeMap, of } from 'rxjs';
import { DashboardClient } from '../../../../../../api-client/src/lib/clients/dashboard/dashboard.client';
import * as ExerciseActions from '../../exercises/+state/exercises.actions';

@Injectable({ providedIn: 'root' })
export class DashboardEffects {

  fetchPopularCoaches$ = createEffect(() =>
    this.actions$.pipe(
      ofType(DashboardActions.fetchPopularCoaches),
      mergeMap(() => this.client.getPopularCoaches().pipe(
        map(response => DashboardActions.fetchPopularCoachesSuccess({ response })),
        catchError(() => of(DashboardActions.fetchPopularCoachesFailure()))
      ))
    )
  );

  fetchPopularExercises$ = createEffect(() =>
    this.actions$.pipe(
      ofType(DashboardActions.fetchPopularExercises),
      mergeMap(() => this.client.getPopularExercises().pipe(
        map(response => DashboardActions.fetchPopularExercisesSuccess({ response })),
        catchError(() => of(DashboardActions.fetchPopularExercisesFailure()))
      ))
    )
  );

  fetchIncomingGroupSessions$ = createEffect(() =>
    this.actions$.pipe(
      ofType(DashboardActions.fetchIncomingGroupSessions),
      mergeMap(() => this.client.getIncomingGroupSessions().pipe(
        map(response => DashboardActions.fetchIncomingGroupSessionsSuccess({ response })),
        catchError(() => of(DashboardActions.fetchIncomingGroupSessionsFailure()))
      ))
    )
  );

  fetchRecentTemplates$ = createEffect(() =>
    this.actions$.pipe(
      ofType(DashboardActions.fetchRecentTemplates),
      mergeMap(() => this.client.getRecentTemplates().pipe(
        map(response => DashboardActions.fetchRecentTemplatesSuccess({ response })),
        catchError(() => of(DashboardActions.fetchRecentTemplatesFailure()))
      ))
    )
  );

  likeExerciseSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ExerciseActions.dislikeExerciseSuccess, ExerciseActions.likeExerciseSuccess),
      map(() => DashboardActions.fetchPopularExercises())
    ));

  constructor(
    private actions$: Actions,
    private client: DashboardClient
  ) {}
}
