import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GroupSessionsRoutingModule } from './group-sessions-routing.module';
import { GroupSessionsStoreModule } from './+state/group-sessions-store.module';
import { GroupSessionsListComponent } from './views/group-sessions-list/group-sessions-list.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { PaginatorComponent } from '../../shared/ui/paginator/paginator.component';
import { GroupSessionFiltersComponent } from './components/group-session-filters/group-session-filters.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { TextInputComponent } from '../../shared/ui/text-input/text-input.component';
import { BookInGroupSessionComponent } from './dialogs/book-in-group-session/book-in-group-session.component';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    GroupSessionsListComponent,
    GroupSessionFiltersComponent,
    BookInGroupSessionComponent,
  ],
  imports: [
    CommonModule,
    GroupSessionsRoutingModule,
    GroupSessionsStoreModule,
    MatSidenavModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    PaginatorComponent,
    FormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatOptionModule,
    MatSelectModule,
    ReactiveFormsModule,
    TextInputComponent,
    MatDialogModule,
  ],
})
export class GroupSessionsModule { }
