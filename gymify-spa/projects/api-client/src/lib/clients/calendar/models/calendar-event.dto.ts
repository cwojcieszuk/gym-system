import { CalendarEventType } from './calendar-event-type.enum';

export interface CalendarEventDTO {
  startDate: Date;
  endDate: Date;
  title: string;
  eventType: CalendarEventType;
}
