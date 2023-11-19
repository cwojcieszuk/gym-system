import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';

@Injectable({ providedIn: 'root' })
export class CalendarEffects {

  constructor(
    private actions$: Actions
  ) {
  }
}
