import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TemplateListComponent } from './views/template-list/template-list.component';
import { TemplateAddComponent } from './views/template-add/template-add.component';

const routes: Routes = [
  {
    path: '',
    component: TemplateListComponent,
  },
  {
    path: 'new',
    component: TemplateAddComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TemplatesRoutingModule { }
