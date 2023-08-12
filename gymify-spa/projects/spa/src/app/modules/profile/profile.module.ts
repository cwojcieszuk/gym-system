import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileRoutingModule } from './profile-routing.module';
import { ProfileViewComponent } from './views/profile-view/profile-view.component';
import { ProfileStoreModule } from './+state/profile-store.module';

@NgModule({
  declarations: [
    ProfileViewComponent,
  ],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    ProfileStoreModule,
  ],
})
export class ProfileModule { }
