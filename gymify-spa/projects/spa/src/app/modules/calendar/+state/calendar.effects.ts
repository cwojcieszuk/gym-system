import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as CalendarActions from './calendar.actions';
import {
  catchError,
  map,
  mergeMap,
  of,
  tap,
  withLatestFrom
} from 'rxjs';
import { CalendarClient } from '../../../../../../api-client/src/lib/clients/calendar/calendar.client';
import { ToastrService } from 'ngx-toastr';
import { CalendarFacade } from './calendar.facade';

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
      tap(() => this.toastr.success('Successfully added coach hour')),
      map(() => CalendarActions.fetchCoachHours())
    ));

  addCoachHourFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CalendarActions.addCoachHourFailure),
      tap(() => this.toastr.error('Unable to add coach hour'))
    ), { dispatch: false });

  fetchCoachHours$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CalendarActions.fetchCoachHours),
      withLatestFrom(this.facade.selectedDate$),
      mergeMap(([, date]) => this.client.getCoachHours(date).pipe(
        map(response => CalendarActions.fetchCoachHoursSuccess({ response })),
        catchError(() => of(CalendarActions.fetchCoachHoursFailure()))
      ))
    )
  );

  fetchCoachHoursFailure$ = createEffect(() =>
    this.actions$.pipe(
      ofType(CalendarActions.fetchCoachHoursFailure),
      tap(() => this.toastr.error('Unable to fetch coach hours'))
    ), { dispatch: false });

  constructor(
    private actions$: Actions,
    private client: CalendarClient,
    private toastr: ToastrService,
    private facade: CalendarFacade
  ) {
  }
}
