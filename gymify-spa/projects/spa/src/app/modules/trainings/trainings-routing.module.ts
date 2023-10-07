import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrainingsListComponent } from './views/trainings-list/trainings-list.component';
import { TrainingAddComponent } from './views/training-add/training-add.component';

const routes: Routes = [
  {
    path: '',
    component: TrainingsListComponent,
  },
  {
    path: 'new',
    component: TrainingAddComponent,
  },
  {
    path: ':uid',
    component: TrainingAddComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TrainingsRoutingModule { }
