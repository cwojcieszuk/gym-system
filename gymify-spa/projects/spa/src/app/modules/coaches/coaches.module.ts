import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoachesRoutingModule } from './coaches-routing.module';
import { CoachesStoreModule } from './+state/coaches-store.module';
import { CoachesListComponent } from './views/coaches-list/coaches-list.component';

@NgModule({
  declarations: [
    CoachesListComponent
  ],
  imports: [
    CommonModule,
    CoachesRoutingModule,
    CoachesStoreModule,
  ],
})
export class CoachesModule { }
