import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import * as CalendarActions from './calendar.actions';
import * as CalendarSelectors from './calendar.selectors';

@Injectable({ providedIn: 'root' })
export class CalendarFacade {
  calendarEvents$ = this.store.select(CalendarSelectors.getCalendarEvents);

  constructor(private store: Store) {}

  fetchCalendarEvents(date: Date): void {
    this.store.dispatch(CalendarActions.fetchCalendarEvents({ date }));
  }
}
