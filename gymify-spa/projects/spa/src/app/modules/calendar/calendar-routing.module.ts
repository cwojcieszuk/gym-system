import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CalendarViewComponent } from './views/calendar-view/calendar-view.component';
import { CoachHoursViewComponent } from './views/coach-hours-view/coach-hours-view.component';

const routes: Routes = [
  {
    path: '',
    component: CalendarViewComponent,
  },
  {
    path: 'coach-hours',
    component: CoachHoursViewComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CalendarRoutingModule { }
