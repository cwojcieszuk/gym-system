import { Component, OnDestroy } from '@angular/core';
import { Observable, Subject, takeUntil } from 'rxjs';

@Component({ template: '', standalone: true })
export class BaseComponent implements OnDestroy {
  private unsubscribe$: Subject<void> = new Subject<void>();

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  observe<T>(observable: Observable<T>): Observable<T> {
    return observable.pipe(takeUntil(this.unsubscribe$));
  }
}
