import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import * as CalendarActions from './calendar.actions';
import * as CalendarSelectors from './calendar.selectors';
import { AddCoachHourParams } from '../../../../../../api-client/src/lib/clients/calendar/params/add-coach-hour.params';

@Injectable({ providedIn: 'root' })
export class CalendarFacade {
  calendarEvents$ = this.store.select(CalendarSelectors.getCalendarEvents);
  selectedDate$ = this.store.select(CalendarSelectors.getSelectedDate);
  coachHours$ = this.store.select(CalendarSelectors.getCoachHours);

  constructor(private store: Store) {}

  fetchCalendarEvents(date: Date): void {
    this.store.dispatch(CalendarActions.fetchCalendarEvents({ date }));
  }

  selectDate(date: Date): void {
    this.store.dispatch(CalendarActions.selectDate({ date }));
  }

  addCoachHour(params: AddCoachHourParams): void {
    this.store.dispatch(CalendarActions.addCoachHour({ params }));
  }

  fetchCoachHours(): void {
    this.store.dispatch(CalendarActions.fetchCoachHours());
  }
}
