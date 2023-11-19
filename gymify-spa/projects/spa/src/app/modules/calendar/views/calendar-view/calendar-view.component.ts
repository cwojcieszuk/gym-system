import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../shared/components/base.component';
import { CalendarEvent, CalendarEventTimesChangedEvent, CalendarView } from 'angular-calendar';
import { EventColor } from 'calendar-utils';
import { isSameDay, isSameMonth } from 'date-fns';
import { filter, Subject } from 'rxjs';
import { CalendarFacade } from '../../+state/calendar.facade';

const colors: EventColor[] = [
  {
    primary: '#ad2121',
    secondary: '#FAE3E3',
  },
  {
    primary: '#1e90ff',
    secondary: '#D1E8FF',
  },
  {
    primary: '#e3bc08',
    secondary: '#FDF1BA',
  },
];

@Component({
  templateUrl: './calendar-view.component.html',
  styleUrls: ['./calendar-view.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CalendarViewComponent extends BaseComponent implements OnInit {
  view: CalendarView = CalendarView.Month;
  CalendarView = CalendarView;
  viewDate: Date = new Date();
  refresh = new Subject<void>();
  events: CalendarEvent[] = [];
  activeDayIsOpen = true;

  constructor(
    private facade: CalendarFacade
  ) {
    super();
  }

  ngOnInit(): void {
    this.facade.fetchCalendarEvents(this.viewDate);

    this.observe(this.facade.calendarEvents$)
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.events = value.map(event => ({
          start: new Date(event.startDate),
          end: new Date(event.endDate),
          title: event.title,
          color: { ...colors[event.eventType] },
        }));

        this.refresh.next();
      });
  }

  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if ((isSameDay(this.viewDate, date) && this.activeDayIsOpen) || events.length === 0) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
      this.viewDate = date;
    }
  }

  eventTimesChanged({
    event,
    newStart,
    newEnd,
  }: CalendarEventTimesChangedEvent): void {
    this.events = this.events.map((iEvent) => {
      if (iEvent === event) {
        return {
          ...event,
          start: newStart,
          end: newEnd,
        };
      }
      return iEvent;
    });
  }

  setView(view: CalendarView): void {
    this.view = view;
  }

  closeOpenMonthViewDay(): void {
    this.activeDayIsOpen = false;

    this.facade.fetchCalendarEvents(this.viewDate);
  }
}
