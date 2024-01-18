import { Component, EventEmitter, Output } from '@angular/core';
import { DictionariesFacade } from '../../../../core/dictionaries-state/dictionaries.facade';
import { FormControl, FormGroup } from '@angular/forms';
import { UUID } from '../../../../../../../api-client/src/lib/types/uuid.type';
import { GroupSessionsFacade } from '../../+state/group-sessions.facade';

@Component({
  selector: 'gym-group-session-filters',
  templateUrl: './group-session-filters.component.html',
  styleUrls: ['./group-session-filters.component.scss'],
})
export class GroupSessionFiltersComponent {
  @Output()
  saveEmitter = new EventEmitter<void>();

  readonly form = new FormGroup({
    category: new FormControl<number | null>(null),
    coachUid: new FormControl<UUID | null>(null),
    date: new FormControl<Date | null>(null, { nonNullable: true }),
    name: new FormControl<string>(''),
  });

  constructor(
    public dictionariesFacade: DictionariesFacade,
    private facade: GroupSessionsFacade
  ) {
    this.dictionariesFacade.fetchCoachCategories();
  }

  clear(): void {
    this.form.reset();
  }

  save(): void {
    this.facade.setFilters({
      name: this.form.value.name ?? '',
      date: this.form.value.date ?? undefined,
      categoryId: this.form.value.category ?? undefined,
      coachUid: this.form.value.coachUid ?? undefined,
    });

    this.saveEmitter.emit();
  }
}
