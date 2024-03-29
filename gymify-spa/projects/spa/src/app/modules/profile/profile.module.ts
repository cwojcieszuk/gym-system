import { NgModule } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { ProfileRoutingModule } from './profile-routing.module';
import { ProfileViewComponent } from './views/profile-view/profile-view.component';
import { ProfileStoreModule } from './+state/profile-store.module';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [
    ProfileViewComponent,
  ],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    ProfileStoreModule,
    MatInputModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatButtonModule,
    MatIconModule,
    NgOptimizedImage,
    MatSelectModule,
  ],
})
export class ProfileModule { }
