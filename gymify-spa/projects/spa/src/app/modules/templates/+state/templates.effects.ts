import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { TemplatesClient } from '../../../../../../api-client/src/lib/clients/templates/templates.client';
import * as TemplateActions from './templates.actions';
import { TemplatesFacade } from './templates.facade';
import { catchError, map, mergeMap, of, withLatestFrom } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class TemplatesEffects {

  fetchTemplates$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TemplateActions.fetchTemplates),
      withLatestFrom(this.facade.query$),
      mergeMap(([, query]) => this.client.getPersonalTemplates(query).pipe(
        map(response => TemplateActions.fetchTemplatesSuccess({ response })),
        catchError(() => of(TemplateActions.fetchTemplatesFailure()))
      ))
    )
  );

  constructor(
    private actions$: Actions,
    private client: TemplatesClient,
    private facade: TemplatesFacade
  ) {}
}
