import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { TemplatesClient } from '../../../../../../api-client/src/lib/clients/templates/templates.client';
import * as TemplateActions from './templates.actions';
import { TemplatesFacade } from './templates.facade';
import { catchError, map, mergeMap, of, withLatestFrom } from 'rxjs';

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

  constructor(
    private actions$: Actions,
    private client: TemplatesClient,
    private facade: TemplatesFacade
  ) {}
}
