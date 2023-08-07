import { Component, EventEmitter, Output } from '@angular/core';
import { NonNullableFormBuilder } from '@angular/forms';
import { UUID } from '../../../../../../../api-client/src/lib/types/uuid.type';
import { UsersFacade } from '../../+state/users.facade';

@Component({
  selector: 'gym-users-filters',
  templateUrl: './users-filters.component.html',
  styleUrls: ['./users-filters.component.scss'],
})
export class UsersFiltersComponent {
  form = this.fb.group({
    name: this.fb.control<string>(''),
    role: this.fb.control<UUID>(''),
    registerDate: this.fb.control<Date | undefined>(undefined),
  });

  @Output()
  saveEmitter = new EventEmitter<void>();

  constructor(
    private fb: NonNullableFormBuilder,
    private facade: UsersFacade
  ) {
  }

  save(): void {
    this.facade.setFilters(this.form.value);
    this.saveEmitter.emit();
  }
}
