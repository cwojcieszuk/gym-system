import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { TEMPLATES_FEATURE_KEY, templatesReducer } from './templates.reducer';
import { EffectsModule } from '@ngrx/effects';
import { TemplatesEffects } from './templates.effects';

@NgModule({
  imports: [
    StoreModule.forFeature(TEMPLATES_FEATURE_KEY, templatesReducer),
    EffectsModule.forFeature([TemplatesEffects]),
  ],
})
export class TemplatesStoreModule { }
