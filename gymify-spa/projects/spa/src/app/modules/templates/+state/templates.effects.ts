import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { TemplatesClient } from '../../../../../../api-client/src/lib/clients/templates/templates.client';
import * as TemplateActions from './templates.actions';
import { TemplatesFacade } from './templates.facade';
import { catchError, map, mergeMap, of, tap, withLatestFrom } from 'rxjs';
import { ExercisesClient } from '../../../../../../api-client/src/lib/clients/exercises/exercises.client';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class TemplatesEffects {

  fetchPersonalTemplates$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.fetchPersonalTemplates),
      withLatestFrom(this.facade.query$),
      mergeMap(([, query]) => this.client.getPersonalTemplates(query).pipe(
        map(response => TemplateActions.fetchPersonalTemplatesSuccess({ response })),
        catchError(() => of(TemplateActions.fetchPersonalTemplatesFailure()))
      ))
    )
  );

  fetchCommunityTemplates$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.fetchCommunityTemplates),
      withLatestFrom(this.facade.query$),
      mergeMap(([, query]) => this.client.getCommunityTemplates(query).pipe(
        map(response => TemplateActions.fetchCommunityTemplatesSuccess({ response })),
        catchError(() => of(TemplateActions.fetchCommunityTemplatesFailure()))
      ))
    )
  );

  fetchExercises$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.fetchExercises),
      withLatestFrom(this.facade.exercisesQuery$),
      mergeMap(([, query]) => this.exerciseClient.getExercisesList(query).pipe(
        map(response => TemplateActions.fetchExercisesSuccess({ response })),
        catchError(() => of(TemplateActions.fetchExercisesFailure()))
      ))
    )
  );

  setExercisesQuery$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.setExercisesQuery, TemplateActions.nextPage),
      map(() => TemplateActions.fetchExercises())
    )
  );

  createTemplate$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.createTemplate),
      mergeMap(({ params }) => this.client.createTemplate(params).pipe(
        map(() => TemplateActions.createTemplateSuccess()),
        catchError(() => of(TemplateActions.createTemplateFailure()))
      ))
    )
  );

  createTemplateFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.createTemplateFailure),
      tap(() => this.toastr.error('Unable to create template'))
    ), { dispatch: false });

  createTemplateSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.createTemplateSuccess),
      tap(() => {
        this.toastr.success('Successfully created template');
        this.router.navigate(['personal-templates']);
      })
    ), { dispatch: false });

  constructor(
    private actions$: Actions,
    private client: TemplatesClient,
    private facade: TemplatesFacade,
    private exerciseClient: ExercisesClient,
    private toastr: ToastrService,
    private router: Router
  ) {}
}
