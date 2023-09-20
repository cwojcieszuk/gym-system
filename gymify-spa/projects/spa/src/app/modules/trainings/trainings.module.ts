import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrainingsRoutingModule } from './trainings-routing.module';
import { TrainingsStoreModule } from './+state/trainings-store.module';
import { TrainingsListComponent } from './views/trainings-list/trainings-list.component';

@NgModule({
  declarations: [
    TrainingsListComponent
  ],
  imports: [
    CommonModule,
    TrainingsRoutingModule,
    TrainingsStoreModule,
  ],
})
export class TrainingsModule { }
