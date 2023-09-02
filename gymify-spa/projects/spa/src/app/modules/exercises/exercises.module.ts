import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExercisesRoutingModule } from './exercises-routing.module';
import { ExercisesListComponent } from './views/exercises-list/exercises-list.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ExercisesStoreModule } from './+state/exercises-store.module';
import { FirstLetterUppercasePipe } from '../../shared/pipe/first-letter-uppercase.pipe';
import { PaginatorComponent } from '../../shared/ui/paginator/paginator.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ExerciseFiltersComponent } from './components/exercise-filters/exercise-filters.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatTooltipModule } from '@angular/material/tooltip';


@NgModule({
  declarations: [
    ExercisesListComponent,
    ExerciseFiltersComponent,
  ],
  imports: [
    CommonModule,
    ExercisesRoutingModule,
    MatSidenavModule,
    MatButtonModule,
    MatIconModule,
    ExercisesStoreModule,
    FirstLetterUppercasePipe,
    PaginatorComponent,
    MatProgressSpinnerModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatTooltipModule,
  ],
})
export class ExercisesModule { }
