import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';

@Injectable({ providedIn: 'root' })
export class GroupSessionsFacade {

  constructor(private store: Store) {}
}
