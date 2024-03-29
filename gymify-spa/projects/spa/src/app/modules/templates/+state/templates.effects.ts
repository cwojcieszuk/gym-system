import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { TemplatesClient } from '../../../../../../api-client/src/lib/clients/templates/templates.client';
import * as TemplateActions from './templates.actions';
import { TemplatesFacade } from './templates.facade';
import {
  catchError, filter, map, mergeMap, of, tap, withLatestFrom
} from 'rxjs';
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

  fetchTemplate$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.fetchTemplate),
      withLatestFrom(this.facade.selectedTemplateUid$),
      map(([, templateUid]) => templateUid),
      filter(Boolean),
      mergeMap(templateUid => this.client.getTemplate(templateUid).pipe(
        map(template => TemplateActions.fetchTemplateSuccess({ template })),
        catchError(() => of(TemplateActions.fetchTemplateFailure()))
      ))
    )
  );

  shareTemplate$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.shareTemplate),
      mergeMap(({ templateUid }) => this.client.shareTemplate(templateUid).pipe(
        map(() => TemplateActions.shareTemplateSuccess()),
        catchError(() => of(TemplateActions.shareTemplateFailure()))
      ))
    )
  );

  shareTemplateSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.shareTemplateSuccess),
      tap(() => this.toastr.success('Successfully shared template')),
      map(() => TemplateActions.fetchPersonalTemplates())
    )
  );

  shareTemplateFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.shareTemplateFailure),
      tap(() => this.toastr.error('Unable to share template'))
    ), { dispatch: false });

  deleteTemplate$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.deleteTemplate),
      mergeMap(({ templateUid }) => this.client.deleteTemplate(templateUid).pipe(
        map(() => TemplateActions.deleteTemplateSuccess()),
        catchError(() => of(TemplateActions.deleteTemplateFailure()))
      ))
    )
  );

  deleteTemplateSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.deleteTemplateSuccess),
      tap(() => this.toastr.success('Successfully deleted template')),
      map(() => TemplateActions.fetchPersonalTemplates())
    )
  );

  deleteTemplateFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.deleteTemplateFailure),
      tap(() => this.toastr.error('Unable to delete template'))
    ), { dispatch: false });

  updateTemplate$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.updateTemplate),
      mergeMap(({ params }) => this.client.updateTemplate(params).pipe(
        map(() => TemplateActions.updateTemplateSuccess()),
        catchError(() => of(TemplateActions.updateTemplateFailure()))
      ))
    )
  );

  updateTemplateSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.updateTemplateSuccess),
      tap(() => this.toastr.success('Successfully updated template'))
    ), { dispatch: false });

  updateTemplateFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.updateTemplateFailure),
      tap(() => this.toastr.error('Unable to update template'))
    ), { dispatch: false });

  importTemplate$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.importTemplate),
      mergeMap(({ templateUid }) => this.client.importTemplate(templateUid).pipe(
        map(() => TemplateActions.importTemplateSuccess()),
        catchError(() => of(TemplateActions.importTemplateFailure()))
      ))
    )
  );

  importTemplateSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.importTemplateSuccess),
      tap(() => this.toastr.success('Successfully imported template'))
    ), { dispatch: false });

  importTemplateFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.importTemplateFailure),
      tap(() => this.toastr.error('Unable to import template'))
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
