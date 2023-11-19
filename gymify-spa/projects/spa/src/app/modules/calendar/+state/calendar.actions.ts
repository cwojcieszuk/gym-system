import { createAction, props } from '@ngrx/store';
import { CalendarEventDTO } from '../../../../../../api-client/src/lib/clients/calendar/models/calendar-event.dto';

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
