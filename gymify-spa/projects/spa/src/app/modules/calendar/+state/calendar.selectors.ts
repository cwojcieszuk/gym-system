import { createFeatureSelector, createSelector } from '@ngrx/store';
import { CALENDAR_FEATURE_KEY, CalendarState } from './calendar.reducer';

export const getCalendarState = createFeatureSelector<CalendarState>(CALENDAR_FEATURE_KEY);

export const getCalendarEvents = createSelector(
  getCalendarState,
  state => state.calendarEvents
);

export const getSelectedDate = createSelector(
  getCalendarState,
  state => state.selectedDate
);

export const getCoachHours = createSelector(
  getCalendarState,
  state => state.coachHours
);
