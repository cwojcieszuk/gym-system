import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';

@Injectable({ providedIn: 'root' })
export class ExercisesFacade {

  constructor(private store: Store) {}
}
