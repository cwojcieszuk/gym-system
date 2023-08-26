import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import * as ProfileSelectors from './profile.selectors';
import * as ProfileActions from './profile.actions';
import {
  UpdateUserDataParams
} from '../../../../../../api-client/src/lib/clients/profile/params/update-user-data.params';
import {
  UpdateUserPasswordParams
} from '../../../../../../api-client/src/lib/clients/profile/params/update-user-password.params';

@Injectable({ providedIn: 'root' })
export class ProfileFacade {
  user$ = this.store.select(ProfileSelectors.getUser);
  isEditing$ = this.store.select(ProfileSelectors.getIsEditing);
  isPasswordEdit$ = this.store.select(ProfileSelectors.getIsPasswordEdit);
  avatar$ = this.store.select(ProfileSelectors.getAvatar);
  isAvatarEdit$ = this.store.select(ProfileSelectors.getIsEditAvatar);

  constructor(private store: Store) {}

  fetchUserData(): void {
    this.store.dispatch(ProfileActions.fetchUserData());
  }

  toggleEdit(): void {
    this.store.dispatch(ProfileActions.toggleEdit());
  }

  cancelEdit(): void {
    this.store.dispatch(ProfileActions.cancelEdit());
  }

  updateUserData(body: UpdateUserDataParams): void {
    this.store.dispatch(ProfileActions.updateUserData({ body }));
  }

  togglePasswordEdit(): void {
    this.store.dispatch(ProfileActions.togglePasswordEdit());
  }

  cancelPasswordEdit(): void {
    this.store.dispatch(ProfileActions.cancelPasswordEdit());
  }

  updateUserPassword(body: UpdateUserPasswordParams): void {
    this.store.dispatch(ProfileActions.updateUserPassword({ body }));
  }

  setAvatar(file: File): void {
    this.store.dispatch(ProfileActions.setAvatar({ avatar: file }));
  }

  uploadAvatar(): void {
    this.store.dispatch(ProfileActions.uploadAvatar());
  }

  editAvatar(): void {
    this.store.dispatch(ProfileActions.editAvatar());
  }

  cancelEditAvatar(): void {
    this.store.dispatch(ProfileActions.cancelEditAvatar());
  }
}
