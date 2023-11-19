import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { CALENDAR_FEATURE_KEY, calendarReducer } from './calendar.reducer';
import { EffectsModule } from '@ngrx/effects';
import { CalendarEffects } from './calendar.effects';

@NgModule({
  imports: [
    StoreModule.forFeature(CALENDAR_FEATURE_KEY, calendarReducer),
    EffectsModule.forFeature([CalendarEffects]),
  ],
})
export class CalendarStoreModule { }
