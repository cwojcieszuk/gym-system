import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { TrainingsClient } from '../../../../../../api-client/src/lib/clients/trainings/trainings.client';
import * as TrainingActions from './trainings.actions';
import {
  catchError, EMPTY, filter, map, mergeMap, of, tap, withLatestFrom
} from 'rxjs';
import { TrainingsFacade } from './trainings.facade';
import { TemplatesClient } from '../../../../../../api-client/src/lib/clients/templates/templates.client';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

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

  createTraining$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TrainingActions.createTraining),
      mergeMap(action => this.client.createTraining(action).pipe(
        map(() => TrainingActions.createTrainingSuccess()),
        catchError(() => of(TrainingActions.createTrainingFailure()))
      ))
    )
  );

  createTrainingSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TrainingActions.createTrainingSuccess),
      tap(() => {
        this.toastr.success('Successfully created training');
        this.router.navigate(['trainings']);
      })
    ), { dispatch: false });

  createTrainingFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TrainingActions.createTrainingFailure),
      tap(() => this.toastr.error('Unable to create training'))
    ), { dispatch: false });

  fetchTrainingDetails$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TrainingActions.fetchTrainingDetails),
      withLatestFrom(this.facade.trainingUid$),
      map(([, trainingUid]) => trainingUid),
      filter(Boolean),
      mergeMap(trainingUid => this.client.getTraining(trainingUid).pipe(
        map(response => TrainingActions.fetchTrainingDetailsSuccess(response)),
        catchError(() => of(TrainingActions.fetchTrainingDetailsFailure()))
      ))
    )
  );

  updateTraining$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TrainingActions.updateTraining),
      withLatestFrom(this.facade.trainingUid$),
      mergeMap(([action, trainingUid]) => {
        if (!trainingUid) {
          return EMPTY;
        }

        return this.client.updateTraining({ trainingUid, trainingName: action.trainingName, trainingDate: action.trainingDate, templateUid: action.templateUid, isCyclical: action.isCyclical }).pipe(
          map(() => TrainingActions.updateTrainingSuccess()),
          catchError(() => of(TrainingActions.updateTrainingFailure()))
        );
      })
    )
  );

  updateTrainingSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TrainingActions.updateTrainingSuccess),
      tap(() => this.toastr.success('Successfully updated training'))
    ), { dispatch: false });

  updateTrainingFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TrainingActions.updateTrainingFailure),
      tap(() => this.toastr.error('Unable to update training'))
    ), { dispatch: false });

  fetchTemplatesBySearch$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TrainingActions.fetchTemplatesBySearch),
      mergeMap(({ search }) => this.templateClient.getTemplatesBySearch(search).pipe(
        map(response => TrainingActions.fetchTemplatesBySearchSuccess({ response })),
        catchError(() => of(TrainingActions.fetchTemplatesBySearchFailure()))
      ))
    )
  );

  constructor(
    private readonly actions$: Actions,
    private readonly client: TrainingsClient,
    private readonly facade: TrainingsFacade,
    private readonly templateClient: TemplatesClient,
    private readonly toastr: ToastrService,
    private readonly router: Router
  ) {}
}
