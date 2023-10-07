import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';
import { CoachesClient } from '../../../../../../api-client/src/lib/clients/coaches/coaches.client';

@Injectable({ providedIn: 'root' })
export class CoachesEffects {

  constructor(
    private readonly actions$: Actions,
    private readonly coachesClient: CoachesClient
  ) {}
}
