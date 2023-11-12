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
    date: new FormControl<Date>(new Date(), { nonNullable: true }),
    name: new FormControl<string>(''),
  });

  constructor(
    public dictionariesFacade: DictionariesFacade,
    private facade: GroupSessionsFacade
  ) {
    this.dictionariesFacade.fetchCoachCategories();
  }

  save(): void {
    this.facade.setFilters({
      name: this.form.value.name ?? '',
      date: this.form.value.date,
      categoryId: this.form.value.category == null ? undefined : this.form.value.category,
      coachUid: this.form.value.coachUid == null ? undefined : this.form.value.coachUid,
    });

    this.saveEmitter.emit();
  }
}
