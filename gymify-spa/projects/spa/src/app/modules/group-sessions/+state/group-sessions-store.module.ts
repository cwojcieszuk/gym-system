import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { GroupSessionsEffects } from './group-sessions.effects';
import { StoreModule } from '@ngrx/store';
import { GROUP_SESSIONS_FEATURE_KEY, groupSessionsReducer } from './group-sessions.reducer';

@NgModule({
  imports: [
    StoreModule.forFeature(GROUP_SESSIONS_FEATURE_KEY, groupSessionsReducer),
    EffectsModule.forFeature([GroupSessionsEffects]),
  ],
})
export class GroupSessionsStoreModule { }
