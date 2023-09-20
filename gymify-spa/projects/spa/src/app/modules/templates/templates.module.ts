import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TemplatesRoutingModule } from './templates-routing.module';
import { TemplateListComponent } from './views/template-list/template-list.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { TemplatesStoreModule } from './+state/templates-store.module';
import { MatTableModule } from '@angular/material/table';
import { PaginatorComponent } from '../../shared/ui/paginator/paginator.component';
import { TemplateAddComponent } from './views/template-add/template-add.component';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { ExerciseChoiceDialogComponent } from './components/exercise-choice.dialog/exercise-choice.dialog.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FirstLetterUppercasePipe } from '../../shared/pipe/first-letter-uppercase.pipe';
import { IntersectionObserverDirective } from '../../shared/directives/intersection-observer.directive';

@NgModule({
  declarations: [
    TemplateListComponent,
    TemplateAddComponent,
    ExerciseChoiceDialogComponent,
  ],
  imports: [
    CommonModule,
    TemplatesRoutingModule,
    TemplatesStoreModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    PaginatorComponent,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    FirstLetterUppercasePipe,
    IntersectionObserverDirective,
  ],
})
export class TemplatesModule { }
