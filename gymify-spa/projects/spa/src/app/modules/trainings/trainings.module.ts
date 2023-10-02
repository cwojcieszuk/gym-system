import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrainingsRoutingModule } from './trainings-routing.module';
import { TrainingsStoreModule } from './+state/trainings-store.module';
import { TrainingsListComponent } from './views/trainings-list/trainings-list.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { PaginatorComponent } from '../../shared/ui/paginator/paginator.component';
import { TrainingAddComponent } from './views/training-add/training-add.component';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { NgxMatDatetimePickerModule, NgxMatNativeDateModule, NgxMatTimepickerModule } from '@angular-material-components/datetime-picker';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DateHourPipe } from '../../shared/pipe/date-hour.pipe';
import { DateDayPipe } from '../../shared/pipe/date-day.pipe';
import { FirstLetterUppercasePipe } from '../../shared/pipe/first-letter-uppercase.pipe';
import { MatCheckboxModule } from '@angular/material/checkbox';

@NgModule({
  declarations: [
    TrainingsListComponent,
    TrainingAddComponent,
  ],
  imports: [
    CommonModule,
    TrainingsRoutingModule,
    TrainingsStoreModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    PaginatorComponent,
    MatCardModule,
    MatInputModule,
    NgxMatDatetimePickerModule,
    NgxMatTimepickerModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    NgxMatNativeDateModule,
    MatAutocompleteModule,
    MatFormFieldModule,
    DateHourPipe,
    DateDayPipe,
    FirstLetterUppercasePipe,
    MatCheckboxModule,
  ],
})
export class TrainingsModule { }
