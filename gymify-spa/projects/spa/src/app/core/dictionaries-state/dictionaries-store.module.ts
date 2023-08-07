import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { DICTIONARIES_FEATURE_KEY, dictionariesReducer } from './dictionaries.reducer';
import { EffectsModule } from '@ngrx/effects';
import { DictionariesEffects } from './dictionaries.effects';

@NgModule({
  imports: [
    StoreModule.forFeature(DICTIONARIES_FEATURE_KEY, dictionariesReducer),
    EffectsModule.forFeature([DictionariesEffects]),
  ],
})
export class DictionariesStoreModule { }
