import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { GroupSessionsClient } from '../../../../../../api-client/src/lib/clients/group-sessions/group-sessions.client';
import * as GroupSessionActions from './group-sessions.actions';
import {
  catchError, map, mergeMap, of, withLatestFrom
} from 'rxjs';
import { GroupSessionsFacade } from './group-sessions.facade';

@Injectable({ providedIn: 'root' })
export class GroupSessionsEffects {

  fetchGroupSessions$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.fetchGroupSessions),
      withLatestFrom(this.facade.query$),
      mergeMap(([, query]) => this.client.getGroupSessions(query).pipe(
        map(response => GroupSessionActions.fetchGroupSessionsSuccess({ response })),
        catchError(() => of(GroupSessionActions.fetchGroupSessionsFailure()))
      ))
    )
  );

  setFilters$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.setFilters),
      map(() => GroupSessionActions.fetchGroupSessions())
    ));

  constructor(
    private actions$: Actions,
    private client: GroupSessionsClient,
    private facade: GroupSessionsFacade
  ) {
  }
}
