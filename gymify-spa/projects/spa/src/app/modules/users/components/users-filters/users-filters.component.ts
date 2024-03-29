import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NonNullableFormBuilder } from '@angular/forms';
import { UUID } from '../../../../../../../api-client/src/lib/types/uuid.type';
import { UsersFacade } from '../../+state/users.facade';
import { DictionariesFacade } from '../../../../core/dictionaries-state/dictionaries.facade';

@Component({
  selector: 'gym-users-filters',
  templateUrl: './users-filters.component.html',
  styleUrls: ['./users-filters.component.scss'],
})
export class UsersFiltersComponent implements OnInit {
  form = this.fb.group({
    name: this.fb.control<string>(''),
    role: this.fb.control<UUID>(''),
    birthDate: this.fb.control<Date | undefined>(undefined),
  });

  @Output()
  saveEmitter = new EventEmitter<void>();

  constructor(
    private fb: NonNullableFormBuilder,
    private facade: UsersFacade,
    public dictionariesFacade: DictionariesFacade
  ) {}

  ngOnInit(): void {
    this.dictionariesFacade.fetchUserRoles();
  }

  clear(): void {
    this.form.reset();
  }

  save(): void {
    this.facade.setFilters({
      name: this.form.value.name,
      role: this.form.value.role,
      birthDate: this.form.value.birthDate == null ? undefined : this.form.value.birthDate,
    });
    this.saveEmitter.emit();
  }
}
