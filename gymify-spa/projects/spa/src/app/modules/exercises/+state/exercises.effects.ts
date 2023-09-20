import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as ExerciseActions from './exercises.actions';
import {
  catchError, EMPTY, map, mergeMap, of, tap, withLatestFrom
} from 'rxjs';
import { ExercisesFacade } from './exercises.facade';
import { ExercisesClient } from '../../../../../../api-client/src/lib/clients/exercises/exercises.client';
import { ToastrService } from 'ngx-toastr';
import { AuthFacade } from '../../../core/auth/+state/auth.facade';

@Injectable({ providedIn: 'root' })
export class ExercisesEffects {

  fetchExercises$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ExerciseActions.fetchExercises),
      withLatestFrom(this.facade.query$),
      mergeMap(([, query]) => this.client.getExercisesList(query).pipe(
        map(data => ExerciseActions.fetchExercisesSuccess({ data })),
        catchError(() => of(ExerciseActions.fetchExercisesFailure()))
      ))
    )
  );

  fetchExercisesFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ExerciseActions.fetchExercisesFailure),
      tap(() => this.toastr.error('Unable to fetch data'))
    ), { dispatch: false });

  setFilters$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ExerciseActions.setFilters),
      map(() => ExerciseActions.fetchExercises())
    )
  );

  likeExercise$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ExerciseActions.likeExercise),
      withLatestFrom(this.authFacade.user$),
      mergeMap(([action, user]) => {
        if (!user) {
          return EMPTY;
        }

        return this.client.likeExercise({ userUid: user.userUid, exerciseUid: action.exerciseUid }).pipe(
          map(() => ExerciseActions.likeExerciseSuccess({ exerciseUid: action.exerciseUid })),
          catchError(() => of(ExerciseActions.likeExerciseFailure()))
        );
      })
    )
  );

  dislikeExercise$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ExerciseActions.dislikeExercise),
      withLatestFrom(this.authFacade.user$),
      mergeMap(([action, user]) => {
        if (!user) {
          return EMPTY;
        }

        return this.client.dislikeExercise({ userUid: user.userUid, exerciseUid: action.exerciseUid }).pipe(
          map(() => ExerciseActions.dislikeExerciseSuccess({ exerciseUid: action.exerciseUid })),
          catchError(() => of(ExerciseActions.dislikeExerciseFailure()))
        );
      })
    )
  );

  // likeExerciseSuccess$ = createEffect(() =>
  //   this.actions$.pipe(
  //     ofType(ExerciseActions.likeExerciseSuccess, ExerciseActions.dislikeExerciseSuccess),
  //     map(() => ExerciseActions.fetchExercises())
  //   )
  // );

  constructor(
    private readonly actions$: Actions,
    private readonly facade: ExercisesFacade,
    private readonly client: ExercisesClient,
    private readonly toastr: ToastrService,
    private readonly authFacade: AuthFacade
  ) {}
}
