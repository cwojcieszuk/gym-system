import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardStoreModule } from './+state/dashboard-store.module';
import { DashboardViewComponent } from './views/dashboard-view/dashboard-view.component';
import { DashboardCardComponent } from './components/dashboard-card/dashboard-card.component';
import { FirstLetterUppercasePipe } from '../../shared/pipe/first-letter-uppercase.pipe';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ExercisesStoreModule } from '../exercises/+state/exercises-store.module';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@NgModule({
  declarations: [
    DashboardViewComponent,
    DashboardCardComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    DashboardStoreModule,
    FirstLetterUppercasePipe,
    MatButtonModule,
    MatIconModule,
    MatTooltipModule,
    ExercisesStoreModule,
    MatProgressSpinnerModule,
  ],
})
export class DashboardModule { }
