import { createAction, props } from '@ngrx/store';
import { CalendarEventDTO } from '../../../../../../api-client/src/lib/clients/calendar/models/calendar-event.dto';
import { AddCoachHourParams } from '../../../../../../api-client/src/lib/clients/calendar/params/add-coach-hour.params';

export const fetchCalendarEvents = createAction(
  '[Calendar/API] Fetch Calendar Events',
  props<{ date: Date }>()
);

export const fetchCalendarEventsSuccess = createAction(
  '[Calendar/API] Fetch Calendar Events Success',
  props<{ response: CalendarEventDTO[] }>()
);

export const fetchCalendarEventsFailure = createAction(
  '[Calendar/API] Fetch Calendar Events Failure'
);

export const selectDate = createAction(
  '[Calendar] Select Date',
  props<{ date: Date }>()
);

export const addCoachHour = createAction(
  '[Calendar/API] Add Coach Hour',
  props<{ params: AddCoachHourParams }>()
);

export const addCoachHourSuccess = createAction(
  '[Calendar/API] Add Coach Hour Success'
);

export const addCoachHourFailure = createAction(
  '[Calendar/API] Add Coach Hour Failure'
);
