import { Component } from '@angular/core';
import { CalendarFacade } from '../../+state/calendar.facade';
import { filter } from 'rxjs';
import { addHours } from 'date-fns';
import { MatTableDataSource } from '@angular/material/table';
import { CoachHour } from '../../../../../../../api-client/src/lib/clients/calendar/models/coach-hour.model';

@Component({
  templateUrl: './coach-hours-view.component.html',
  styleUrls: ['./coach-hours-view.component.scss'],
})
export class CoachHoursViewComponent {
  startDate = new Date();
  endDate = new Date();

  displayedColumns = ['date', 'time', 'client'];
  dataSource = new MatTableDataSource<CoachHour>([]);

  constructor(
    public facade: CalendarFacade
  ) {
    this.facade.selectedDate$
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.startDate = value;
        this.endDate = addHours(value, 1);
      });

    this.facade.fetchCoachHours();

    this.facade.coachHours$
      .subscribe(value => {
        this.dataSource.data = value;
      });
  }

  addCoachHour(): void {
    this.facade.addCoachHour({ startDate: this.startDate, endDate: this.endDate });
  }
}
