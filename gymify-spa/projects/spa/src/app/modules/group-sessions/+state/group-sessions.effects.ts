import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { GroupSessionsClient } from '../../../../../../api-client/src/lib/clients/group-sessions/group-sessions.client';
import * as GroupSessionActions from './group-sessions.actions';
import {
  catchError, map, mergeMap, of, tap, withLatestFrom
} from 'rxjs';
import { GroupSessionsFacade } from './group-sessions.facade';
import { ToastrService } from 'ngx-toastr';

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

  bookIn$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.bookIn),
      mergeMap(({ groupSessionUid }) => this.client.bookIn(groupSessionUid).pipe(
        map(() => GroupSessionActions.bookInSuccess()),
        catchError(() => of(GroupSessionActions.bookInFailure()))
      ))
    )
  );

  bookInSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.bookInSuccess),
      tap(() => this.toastr.success('Successfully booked in')),
      map(() => GroupSessionActions.fetchGroupSessions())
    ));

  bookInFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.bookInFailure),
      tap(() => this.toastr.error('Unable to book in'))
    ), { dispatch: false });

  resign$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.resign),
      mergeMap(({ groupSessionUid }) => this.client.resign(groupSessionUid).pipe(
        map(() => GroupSessionActions.resignSuccess()),
        catchError(() => of(GroupSessionActions.resignFailure()))
      ))
    )
  );

  resignSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.resignSuccess),
      tap(() => this.toastr.success('Successfully resigned')),
      map(() => GroupSessionActions.fetchGroupSessions())
    ));

  resignFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.resignFailure),
      tap(() => this.toastr.error('Unable to resign'))
    ), { dispatch: false });

  createGroupSession$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.createGroupSession),
      mergeMap(({ params }) => this.client.createGroupSession(params).pipe(
        map(() => GroupSessionActions.createGroupSessionSuccess()),
        catchError(() => of(GroupSessionActions.createGroupSessionFailure()))
      ))
    )
  );

  createGroupSessionSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.createGroupSessionSuccess),
      tap(() => this.toastr.success('Successfully created group session')),
      map(() => GroupSessionActions.fetchGroupSessions())
    ));

  createGroupSessionFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.createGroupSessionFailure),
      tap(() => this.toastr.error('Unable to create group session'))
    ), { dispatch: false });

  editGroupSession$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.editGroupSession),
      mergeMap(({ params }) => this.client.editGroupSession(params).pipe(
        map(() => GroupSessionActions.editGroupSessionSuccess()),
        catchError(() => of(GroupSessionActions.editGroupSessionFailure()))
      ))
    ));

  editGroupSessionSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.editGroupSessionSuccess),
      tap(() => this.toastr.success('Successfully edited group session')),
      map(() => GroupSessionActions.fetchGroupSessions())
    ));

  editGroupSessionFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.createGroupSessionFailure),
      tap(() => this.toastr.error('Unable to edit group session'))
    ), { dispatch: false });

  deleteGroupSession$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.deleteGroupSession),
      mergeMap(({ groupSessionUid }) => this.client.deleteGroupSession(groupSessionUid).pipe(
        map(() => GroupSessionActions.deleteGroupSessionSuccess()),
        catchError(() => of(GroupSessionActions.deleteGroupSessionFailure()))
      ))
    ));

  deleteGroupSessionSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.deleteGroupSessionSuccess),
      tap(() => this.toastr.success('Successfully deleted group session')),
      map(() => GroupSessionActions.fetchGroupSessions())
    ));

  deleteGroupSessionFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(GroupSessionActions.deleteGroupSessionFailure),
      tap(() => this.toastr.error('Unable to delete group session'))
    ), { dispatch: false });

  constructor(
    private actions$: Actions,
    private client: GroupSessionsClient,
    private facade: GroupSessionsFacade,
    private toastr: ToastrService
  ) {
  }
}
