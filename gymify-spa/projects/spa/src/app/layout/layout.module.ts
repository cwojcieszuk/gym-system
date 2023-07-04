import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './menu/menu.component';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    MenuComponent,
    ToolbarComponent,
  ],
  imports: [
    CommonModule,
    MatToolbarModule,
    MatListModule,
    MatInputModule,
  ],
  exports: [
    MenuComponent,
    ToolbarComponent,
  ],
})
export class LayoutModule { }
