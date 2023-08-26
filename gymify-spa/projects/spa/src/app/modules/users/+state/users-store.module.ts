import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { USERS_FEATURE_KEY, usersReducer } from './users.reducer';
import { EffectsModule } from '@ngrx/effects';
import { UsersEffects } from './users.effects';

@NgModule({
  imports: [
    StoreModule.forFeature(USERS_FEATURE_KEY, usersReducer),
    EffectsModule.forFeature([UsersEffects]),
  ],
})
export class UsersStoreModule { }
