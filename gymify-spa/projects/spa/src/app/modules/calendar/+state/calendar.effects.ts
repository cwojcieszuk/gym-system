import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as CalendarActions from './calendar.actions';
import { catchError, map, mergeMap, of, tap } from 'rxjs';
import { CalendarClient } from '../../../../../../api-client/src/lib/clients/calendar/calendar.client';
import { ToastrService } from 'ngx-toastr';

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

  addCoachHour$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CalendarActions.addCoachHour),
      mergeMap(({ params }) => this.client.addCoachHour(params).pipe(
        map(() => CalendarActions.addCoachHourSuccess()),
        catchError(() => of(CalendarActions.addCoachHourFailure()))
      ))
    )
  );

  addCoachHourSuccess$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CalendarActions.addCoachHourSuccess),
      tap(() => this.toastr.success('Successfully added coach hour'))
    ), { dispatch: false });

  addCoachHourFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CalendarActions.addCoachHourFailure),
      tap(() => this.toastr.success('Unable to add coach hour'))
    ), { dispatch: false });

  constructor(
    private actions$: Actions,
    private client: CalendarClient,
    private toastr: ToastrService
  ) {
  }
}
