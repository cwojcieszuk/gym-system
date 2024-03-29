import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { ProfileClient } from '../../../../../../api-client/src/lib/clients/profile/profile.client';
import { AuthFacade } from '../../../core/auth/+state/auth.facade';
import * as ProfileActions from './profile.actions';
import {
  catchError, EMPTY, filter, map, mergeMap, of, tap, withLatestFrom
} from 'rxjs';
import { ProfileFacade } from './profile.facade';
import { ToastrService } from 'ngx-toastr';

@Injectable({ providedIn: 'root' })
export class ProfileEffects {

  fetchUserData$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.fetchUserData),
      withLatestFrom(this.authFacade.user$),
      map(([, user]) => user?.userUid),
      filter(Boolean),
      mergeMap(userUid => this.profileClient.getUserData(userUid).pipe(
        map(result => ProfileActions.fetchUserDataSuccess({ response: result })),
        catchError(() => of(ProfileActions.fetchUserDataFailure()))
      ))
    )
  );

  updateUserData$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateUserData),
      withLatestFrom(this.authFacade.user$),
      filter(Boolean),
      mergeMap(([action, user]) => {
        if (!user) {
          return EMPTY;
        }

        return this.profileClient.updateUserData(user.userUid, action.body).pipe(
          map(() => ProfileActions.updateUserDataSuccess()),
          catchError(() => of(ProfileActions.updateUserDataFailure()))
        );
      })
    )
  );

  updateUserDataSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateUserDataSuccess),
      tap(() => {
        this.profileFacade.cancelEdit();
        this.toastr.success('Successfully updated data');
      }),
      map(() => ProfileActions.fetchUserData())
    )
  );

  updateUserDataFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateUserDataFailure),
      tap(() => this.toastr.error('Unable to update data'))
    ), { dispatch: false });

  updateUserPassword$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateUserPassword),
      withLatestFrom(this.authFacade.user$),
      filter(Boolean),
      mergeMap(([action, user]) => {
        if (!user) {
          return EMPTY;
        }

        return this.profileClient.updateUserPassword(user.userUid, action.body).pipe(
          map(() => ProfileActions.updateUserPasswordSuccess()),
          catchError(() => of(ProfileActions.updateUserPasswordFailure()))
        );
      })
    )
  );

  updateUserPasswordSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateUserPasswordSuccess),
      tap(() => {
        this.profileFacade.cancelPasswordEdit();
        this.toastr.success('Successfully updated password');
      })
    ), { dispatch: false });

  updateUserPasswordFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateUserPasswordFailure),
      tap(() => this.toastr.error('Unable to update password'))
    ), { dispatch: false });

  uploadAvatar$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.uploadAvatar),
      withLatestFrom(this.authFacade.user$, this.profileFacade.avatar$),
      mergeMap(([, user, avatar]) => {
        if (!user || !avatar) {
          return EMPTY;
        }

        return this.profileClient.uploadAvatar(user.userUid, avatar).pipe(
          map(() => ProfileActions.uploadAvatarSuccess()),
          catchError(() => of(ProfileActions.uploadAvatarFailure()))
        );
      })
    )
  );

  uploadAvatarSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.uploadAvatarSuccess),
      tap(() => {
        this.profileFacade.cancelEditAvatar();
        this.toastr.success('Successfully updated avatar');
      })
    ), { dispatch: false });

  uploadAvatarFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.uploadAvatarFailure),
      tap(() => this.toastr.error('Unable to upload avatar'))
    ), { dispatch: false });

  updateCoachDescription$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateCoachDescription),
      withLatestFrom(this.authFacade.user$),
      mergeMap(([{ description, categoryId }, user]) => {
        if (!user) {
          return EMPTY;
        }

        return this.profileClient.updateCoachDescription(user.userUid, description, categoryId).pipe(
          map(() => ProfileActions.updateCoachDescriptionSuccess()),
          catchError(() => of(ProfileActions.updateCoachDescriptionFailure()))
        );
      })
    )
  );

  updateCoachDescriptionSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateCoachDescriptionSuccess),
      tap(() => {
        this.profileFacade.cancelEditCoachDetails();
        this.toastr.success('Successfully updated coach data');
      })
    ), { dispatch: false });

  updateCoachDescriptionFailure = createEffect(() =>
    this.actions$.pipe(
      ofType(ProfileActions.updateCoachDescriptionFailure),
      tap(() => this.toastr.error('Unable to update coach data'))
    ), { dispatch: false });

  constructor(
    private actions$: Actions,
    private profileClient: ProfileClient,
    private authFacade: AuthFacade,
    private profileFacade: ProfileFacade,
    private toastr: ToastrService
  ) {}
}
