import { CalendarEventDTO } from '../../../../../../api-client/src/lib/clients/calendar/models/calendar-event.dto';
import { createReducer, on } from '@ngrx/store';
import * as CalendarActions from './calendar.actions';
import { CoachHour } from '../../../../../../api-client/src/lib/clients/calendar/models/coach-hour.model';
import { addHours } from 'date-fns';

export const CALENDAR_FEATURE_KEY = 'calendar';

export interface CalendarState {
  calendarEvents: CalendarEventDTO[];
  selectedDate: Date;
  coachHours: CoachHour[];
}

const initialState: CalendarState = {
  calendarEvents: [],
  selectedDate: new Date(),
  coachHours: [],
};

export const calendarReducer = createReducer<CalendarState>(
  initialState,
  on(CalendarActions.fetchCalendarEventsSuccess, (state, payload) => ({
    ...state,
    calendarEvents: payload.response,
  })),
  on(CalendarActions.selectDate, (state, payload) => ({
    ...state,
    selectedDate: addHours(payload.date, 1),
  })),
  on(CalendarActions.fetchCoachHoursSuccess, (state, payload) => ({
    ...state,
    coachHours: payload.response,
  }))
);
