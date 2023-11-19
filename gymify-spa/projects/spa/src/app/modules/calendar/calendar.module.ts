import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CalendarRoutingModule } from './calendar-routing.module';
import { CalendarStoreModule } from './+state/calendar-store.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CalendarRoutingModule,
    CalendarStoreModule,
  ],
})
export class CalendarModule { }
