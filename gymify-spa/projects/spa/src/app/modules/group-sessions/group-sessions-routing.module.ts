import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GroupSessionsListComponent } from './views/group-sessions-list/group-sessions-list.component';

const routes: Routes = [
  {
    path: '',
    component: GroupSessionsListComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GroupSessionsRoutingModule { }
