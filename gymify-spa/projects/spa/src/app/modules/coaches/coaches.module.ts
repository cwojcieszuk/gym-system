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

@NgModule({
  declarations: [
    CoachesListComponent,
    CoachesListFiltersComponent,
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
  ],
})
export class CoachesModule { }
