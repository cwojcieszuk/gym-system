import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersRoutingModule } from './users-routing.module';
import { UsersListComponent } from './views/users-list/users-list.component';
import { UsersStoreModule } from './+state/users-store.module';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { UsersFiltersComponent } from './components/users-filters/users-filters.component';
import { TextInputComponent } from '../../shared/ui/text-input/text-input.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatSidenavModule } from '@angular/material/sidenav';
import { PaginatorComponent } from '../../shared/ui/paginator/paginator.component';
import { UserFormComponent } from './components/user-form/user-form.component';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    UsersListComponent,
    UsersFiltersComponent,
    UserFormComponent,
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    UsersStoreModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    TextInputComponent,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatDatepickerModule,
    MatInputModule,
    MatSidenavModule,
    PaginatorComponent,
    MatDialogModule,
  ],
})
export class UsersModule { }
