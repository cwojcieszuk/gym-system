import { Component, EventEmitter, inject, Output } from '@angular/core';
import { NonNullableFormBuilder } from '@angular/forms';
import { CoachesFacade } from '../../+state/coaches.facade';

@Component({
  selector: 'gym-coaches-list-filters',
  templateUrl: './coaches-list-filters.component.html',
  styleUrls: ['./coaches-list-filters.component.scss'],
})
export class CoachesListFiltersComponent {
  fb = inject(NonNullableFormBuilder);
  facade = inject(CoachesFacade);

  readonly form = this.fb.group({
    name: this.fb.control<string | undefined>(undefined),
    categoryId: this.fb.control<number | undefined>(undefined),
  });

  @Output()
  saveEmitter = new EventEmitter<void>();

  save(): void {
    const value = this.form.value;
    this.facade.setCoachesQuery({ name: value.name ?? '', categoryId: value.categoryId ?? undefined });

    this.saveEmitter.emit();
  }
}
