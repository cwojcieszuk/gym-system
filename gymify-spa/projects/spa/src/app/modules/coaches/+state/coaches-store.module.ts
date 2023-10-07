import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { COACHES_FEATURE_KEY, coachesReducer } from './coaches.reducer';
import { EffectsModule } from '@ngrx/effects';
import { CoachesEffects } from './coaches.effects';

@NgModule({
  imports: [
    StoreModule.forFeature(COACHES_FEATURE_KEY, coachesReducer),
    EffectsModule.forFeature([CoachesEffects]),
  ],
})
export class CoachesStoreModule { }
