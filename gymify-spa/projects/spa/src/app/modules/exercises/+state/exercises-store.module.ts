import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { EXERCISES_FEATURE_KEY, exercisesReducer } from './exercises.reducer';
import { EffectsModule } from '@ngrx/effects';
import { ExercisesEffects } from './exercises.effects';

@NgModule({
  imports: [
    StoreModule.forFeature(EXERCISES_FEATURE_KEY, exercisesReducer),
    EffectsModule.forFeature([ExercisesEffects]),
  ],
})
export class ExercisesStoreModule { }
