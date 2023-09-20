import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrainingsRoutingModule } from './trainings-routing.module';
import { TrainingsStoreModule } from './+state/trainings-store.module';
import { TrainingsListComponent } from './views/trainings-list/trainings-list.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { PaginatorComponent } from '../../shared/ui/paginator/paginator.component';

@NgModule({
  declarations: [
    TrainingsListComponent
  ],
  imports: [
    CommonModule,
    TrainingsRoutingModule,
    TrainingsStoreModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    PaginatorComponent,
  ],
})
export class TrainingsModule { }
