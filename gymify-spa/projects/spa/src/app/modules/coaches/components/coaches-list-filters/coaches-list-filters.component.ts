import { Component, EventEmitter, inject, OnInit, Output } from '@angular/core';
import { NonNullableFormBuilder } from '@angular/forms';
import { CoachesFacade } from '../../+state/coaches.facade';
import { DictionariesFacade } from '../../../../core/dictionaries-state/dictionaries.facade';

@Component({
  selector: 'gym-coaches-list-filters',
  templateUrl: './coaches-list-filters.component.html',
  styleUrls: ['./coaches-list-filters.component.scss'],
})
export class CoachesListFiltersComponent implements OnInit {
  fb = inject(NonNullableFormBuilder);
  facade = inject(CoachesFacade);
  dictionariesFacade = inject(DictionariesFacade);

  readonly form = this.fb.group({
    name: this.fb.control<string | undefined>(undefined),
    categoryId: this.fb.control<number | undefined>(undefined),
  });

  @Output()
  saveEmitter = new EventEmitter<void>();

  ngOnInit(): void {
    this.dictionariesFacade.fetchCoachCategories();
  }

  save(): void {
    const value = this.form.value;
    this.facade.setCoachesQuery({ name: value.name ?? '', categoryId: value.categoryId ?? undefined });

    this.saveEmitter.emit();
  }

  clear(): void {
    this.form.patchValue({
      name: undefined,
      categoryId: undefined,
    });
  }
}
