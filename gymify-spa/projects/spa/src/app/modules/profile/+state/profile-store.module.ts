import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { PROFILE_FEATURE_KEY, profileReducer } from './profile.reducer';
import { EffectsModule } from '@ngrx/effects';
import { ProfileEffects } from './profile.effects';

@NgModule({
  imports: [
    StoreModule.forFeature(PROFILE_FEATURE_KEY, profileReducer),
    EffectsModule.forFeature([ProfileEffects]),
  ],
})
export class ProfileStoreModule { }
