import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { UsersClient } from '../../../../../../api-client/src/lib/clients/users/users.client';
import { UsersFacade } from './users.facade';
import * as UsersActions from './users.actions';
import { catchError, map, mergeMap, of, tap, withLatestFrom } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({ providedIn: 'root' })
export class UsersEffects {

  fetchUsers$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.fetchUsers),
      withLatestFrom(this.facade.filters$),
      mergeMap(([, filters]) => this.usersClient.fetch(filters).pipe(
        map(result => UsersActions.fetchUsersSuccess(result)),
        catchError(() => of(UsersActions.fetchUsersFailure()))
      ))
    ));

  setFilters$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.setFilters),
      map(() => UsersActions.fetchUsers())
    ));

  fetchUsersFail$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.fetchUsersFailure),
      tap(() => this.toastr.error('Unable to fetch users'))
    ), { dispatch: false });

  addUser$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.addUser),
      mergeMap(params => this.usersClient.addUser(params).pipe(
        map(() => UsersActions.addUserSuccess()),
        catchError(() => of(UsersActions.addUserFailure()))
      ))
    ));

  addUserSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.addUserSuccess),
      tap(() => this.toastr.success('Successfully added user')),
      map(() => UsersActions.fetchUsers())
    )
  );

  addUserFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.addUserFailure),
      tap(() => this.toastr.error('Unable to add user'))
    ), { dispatch: false });

  editUser$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.editUser),
      mergeMap(params => this.usersClient.editUser(params).pipe(
        map(() => UsersActions.editUserSuccess()),
        catchError(() => of(UsersActions.editUserFailure()))
      ))
    )
  );

  editUserSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.editUserSuccess),
      tap(() => this.toastr.success('Successfully edited user')),
      map(() => UsersActions.fetchUsers())
    )
  );

  editUserFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.editUserFailure),
      tap(() => this.toastr.error('Unable to edit user'))
    ), { dispatch: false });

  deleteUser$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.deleteUser),
      mergeMap(action => this.usersClient.deleteUser(action.userUid).pipe(
        map(() => UsersActions.deleteUserSuccess()),
        catchError(() => of(UsersActions.deleteUserFailure()))
      ))
    )
  );

  deleteUserSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.deleteUserSuccess),
      tap(() => this.toastr.success('Successfully deleted user')),
      map(() => UsersActions.fetchUsers())
    ));

  deleteUserFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.deleteUserFailure),
      tap(() => this.toastr.error('Unable to delete user'))
    ), { dispatch: false });

  constructor(
    private actions$: Actions,
    private usersClient: UsersClient,
    private facade: UsersFacade,
    private toastr: ToastrService
  ) {
  }
}
