import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GroupSessionsRoutingModule } from './group-sessions-routing.module';
import { GroupSessionsStoreModule } from './+state/group-sessions-store.module';
import { GroupSessionsListComponent } from './views/group-sessions-list/group-sessions-list.component';


@NgModule({
  declarations: [
    GroupSessionsListComponent,
  ],
  imports: [
    CommonModule,
    GroupSessionsRoutingModule,
    GroupSessionsStoreModule,
  ],
})
export class GroupSessionsModule { }
