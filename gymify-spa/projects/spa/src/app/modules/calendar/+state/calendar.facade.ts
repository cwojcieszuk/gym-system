import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';

@Injectable({ providedIn: 'root' })
export class CalendarFacade {

  constructor(private store: Store) {}
}
