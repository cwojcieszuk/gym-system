import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { DASHBOARD_FEATURE_KEY, dashboardReducer } from './dashboard.reducer';
import { EffectsModule } from '@ngrx/effects';
import { DashboardEffects } from './dashboard.effects';

@NgModule({
  imports: [
    StoreModule.forFeature(DASHBOARD_FEATURE_KEY, dashboardReducer),
    EffectsModule.forFeature([DashboardEffects]),
  ],
})
export class DashboardStoreModule { }
