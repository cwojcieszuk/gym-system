import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CalendarRoutingModule } from './calendar-routing.module';
import { CalendarStoreModule } from './+state/calendar-store.module';
import { CalendarViewComponent } from './views/calendar-view/calendar-view.component';
import {
  CalendarCommonModule,
  CalendarDayModule,
  CalendarMonthModule,
  CalendarWeekModule,
  CalendarModule as CalendarModuleModule
} from 'angular-calendar';
import { MatNativeDateModule } from '@angular/material/core';
import { FlatpickrModule } from 'angularx-flatpickr';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { DateAdapter } from 'angular-calendar';
import { CoachHoursViewComponent } from './views/coach-hours-view/coach-hours-view.component';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [
    CalendarViewComponent,
    CoachHoursViewComponent,
  ],
  imports: [
    CommonModule,
    CalendarRoutingModule,
    CalendarStoreModule,
    CalendarWeekModule,
    CalendarMonthModule,
    CalendarCommonModule,
    CalendarDayModule,
    MatNativeDateModule,
    CalendarModuleModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),
    FlatpickrModule,
    MatDatepickerModule,
    FormsModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
  ],
})
export class CalendarModule { }
