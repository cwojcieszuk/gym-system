import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoachesRoutingModule } from './coaches-routing.module';
import { CoachesStoreModule } from './+state/coaches-store.module';
import { CoachesListComponent } from './views/coaches-list/coaches-list.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { PaginatorComponent } from '../../shared/ui/paginator/paginator.component';
import { CoachesListFiltersComponent } from './components/coaches-list-filters/coaches-list-filters.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CoachDetailsDialog } from './components/coach-details/coach-details.dialog';
import { JoinPipe } from '../../shared/pipe/join.pipe';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDatepickerModule } from '@angular/material/datepicker';

@NgModule({
  declarations: [
    CoachesListComponent,
    CoachesListFiltersComponent,
    CoachDetailsDialog,
  ],
  imports: [
    CommonModule,
    CoachesRoutingModule,
    CoachesStoreModule,
    MatSidenavModule,
    MatButtonModule,
    MatIconModule,
    PaginatorComponent,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    JoinPipe,
    MatDialogModule,
    MatDatepickerModule,
  ],
})
export class CoachesModule { }
