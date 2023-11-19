import { createFeatureSelector } from '@ngrx/store';
import { CALENDAR_FEATURE_KEY, CalendarState } from './calendar.reducer';

export const getCalendarState = createFeatureSelector<CalendarState>(CALENDAR_FEATURE_KEY);

