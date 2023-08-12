import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';
import { ProfileClient } from '../../../../../../api-client/src/lib/clients/profile/profile.client';

@Injectable({ providedIn: 'root' })
export class ProfileEffects {

  constructor(
    private actions$: Actions,
    private profileClient: ProfileClient,
  ) {}
}
