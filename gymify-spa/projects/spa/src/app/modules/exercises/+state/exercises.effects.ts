import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';

@Injectable({ providedIn: 'root' })
export class ExercisesEffects {

  constructor(
    private readonly actions$: Actions
  ) {
  }
}
