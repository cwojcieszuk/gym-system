import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { TrainingsEffects } from './trainings.effects';
import { StoreModule } from '@ngrx/store';
import { TRAININGS_FEATURE_KEY, trainingsReducer } from './trainings.reducer';

@NgModule({
  imports: [
    StoreModule.forFeature(TRAININGS_FEATURE_KEY, trainingsReducer),
    EffectsModule.forFeature([TrainingsEffects]),
  ],
})
export class TrainingsStoreModule { }
