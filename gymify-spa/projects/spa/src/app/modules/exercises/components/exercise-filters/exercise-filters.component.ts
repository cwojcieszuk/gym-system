import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NonNullableFormBuilder } from '@angular/forms';
import { ExercisesFacade } from '../../+state/exercises.facade';
import { DictionariesFacade } from '../../../../core/dictionaries-state/dictionaries.facade';
import { BaseComponent } from '../../../../shared/components/base.component';

@Component({
  selector: 'gym-exercise-filters',
  templateUrl: './exercise-filters.component.html',
  styleUrls: ['./exercise-filters.component.scss'],
})
export class ExerciseFiltersComponent extends BaseComponent implements OnInit {
  readonly form = this.fb.group({
    bodyPartId: this.fb.control<number | undefined>(undefined),
    equipmentId: this.fb.control<number | undefined>(undefined),
    targetId: this.fb.control<number | undefined>(undefined),
    name: this.fb.control<string | undefined>(undefined),
    showFavorite: this.fb.control<boolean | undefined>(undefined),
  });

  @Output()
  save = new EventEmitter<void>();

  constructor(
    private fb: NonNullableFormBuilder,
    private facade: ExercisesFacade,
    public dictionariesFacade: DictionariesFacade
  ) {
    super();
  }

  ngOnInit(): void {
    this.dictionariesFacade.fetchBodyParts();
    this.dictionariesFacade.fetchEquipments();
    this.dictionariesFacade.fetchTargets();

    this.observe(this.facade.query$)
      .subscribe(value => this.form.patchValue({
        bodyPartId: value.bodyPartId,
        targetId: value.targetId,
        equipmentId: value.equipmentId,
        name: value.name,
        showFavorite: value.showFavorite,
      }));
  }

  clear(): void {
    this.form.reset();
  }

  submit(): void {
    this.facade.setFilters({
      bodyPartId: this.form.controls.bodyPartId.value ?? undefined,
      equipmentId: this.form.controls.equipmentId.value ?? undefined,
      targetId: this.form.controls.targetId.value ?? undefined,
      name: this.form.controls.name.value ?? undefined,
      showFavorite: this.form.controls.showFavorite.value ?? undefined,
    });

    this.save.emit();
  }
}
