import { Component } from '@angular/core';
import { CalendarFacade } from '../../+state/calendar.facade';
import { filter } from 'rxjs';
import { addHours } from 'date-fns';

@Component({
  templateUrl: './coach-hours-view.component.html',
  styleUrls: ['./coach-hours-view.component.scss'],
})
export class CoachHoursViewComponent {
  startDate = new Date();
  endDate = new Date();

  constructor(
    public facade: CalendarFacade
  ) {
    this.facade.selectedDate$
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.startDate = value;
        this.endDate = addHours(value, 1);
      });
  }

  addCoachHour(): void {
    this.facade.addCoachHour({ startDate: this.startDate, endDate: this.endDate });
  }
}
