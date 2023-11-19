import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as CalendarActions from './calendar.actions';
import { catchError, map, mergeMap, of } from 'rxjs';
import { CalendarClient } from '../../../../../../api-client/src/lib/clients/calendar/calendar.client';

@Injectable({ providedIn: 'root' })
export class CalendarEffects {

  fetchCalendarEvents$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CalendarActions.fetchCalendarEvents),
      mergeMap(({ date }) => this.client.getCalendarEvents(date).pipe(
        map(response => CalendarActions.fetchCalendarEventsSuccess({ response })),
        catchError(() => of(CalendarActions.fetchCalendarEventsFailure()))
      ))
    )
  );

  constructor(
    private actions$: Actions,
    private client: CalendarClient
  ) {
  }
}
