import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TemplatesRoutingModule } from './templates-routing.module';
import { TemplateListComponent } from './views/template-list/template-list.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { TemplatesStoreModule } from './+state/templates-store.module';
import { MatTableModule } from '@angular/material/table';
import { PaginatorComponent } from '../../shared/ui/paginator/paginator.component';


@NgModule({
  declarations: [
    TemplateListComponent,
  ],
  imports: [
    CommonModule,
    TemplatesRoutingModule,
    TemplatesStoreModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    PaginatorComponent,
  ],
})
export class TemplatesModule { }
