import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as ExerciseActions from './exercises.actions';
import { catchError, map, mergeMap, of, tap, withLatestFrom } from 'rxjs';
import { ExercisesFacade } from './exercises.facade';
import { ExercisesClient } from '../../../../../../api-client/src/lib/clients/exercises/exercises.client';
import { ToastrService } from 'ngx-toastr';

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
    ))
  ;

  constructor(
    private readonly actions$: Actions,
    private readonly facade: ExercisesFacade,
    private readonly client: ExercisesClient,
    private readonly toastr: ToastrService
  ) {
  }
}
