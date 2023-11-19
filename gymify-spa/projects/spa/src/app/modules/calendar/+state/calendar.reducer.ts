import { CalendarEventDTO } from '../../../../../../api-client/src/lib/clients/calendar/models/calendar-event.dto';
import { createReducer, on } from '@ngrx/store';
import * as CalendarActions from './calendar.actions';

export const CALENDAR_FEATURE_KEY = 'calendar';

export interface CalendarState {
  calendarEvents: CalendarEventDTO[];
  selectedDate: Date;
}

const initialState: CalendarState = {
  calendarEvents: [],
  selectedDate: new Date(),
};

export const calendarReducer = createReducer<CalendarState>(
  initialState,
  on(CalendarActions.fetchCalendarEventsSuccess, (state, payload) => ({
    ...state,
    calendarEvents: payload.response,
  })),
  on(CalendarActions.selectDate, (state, payload) => ({
    ...state,
    selectedDate: payload.date,
  }))
);
