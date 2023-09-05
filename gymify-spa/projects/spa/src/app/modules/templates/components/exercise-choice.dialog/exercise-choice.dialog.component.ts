import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { NonNullableFormBuilder } from '@angular/forms';
import { DictionariesFacade } from '../../../../core/dictionaries-state/dictionaries.facade';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BaseComponent } from '../../../../shared/components/base.component';
import { ImageService } from '../../../../shared/services/image.service';
import { TemplatesFacade } from '../../+state/templates.facade';
import { ExerciseDTO } from '../../../../../../../api-client/src/lib/clients/exercises/models/exercise.dto';

@Component({
  templateUrl: './exercise-choice.dialog.component.html',
  styleUrls: ['./exercise-choice.dialog.component.scss']
})
export class ExerciseChoiceDialogComponent extends BaseComponent implements OnInit, OnDestroy {
  readonly form = this.fb.group({
    name: this.fb.control<string>(''),
    bodyPartId: this.fb.control<number | undefined>(undefined),
    equipmentId: this.fb.control<number | undefined>(undefined),
    targetId: this.fb.control<number | undefined>(undefined),
    showFavorite: this.fb.control<boolean>(false),
  });

  selectedExercise?: ExerciseDTO;

  constructor(
    @Inject(MAT_DIALOG_DATA) private data: { index: number },
    private fb: NonNullableFormBuilder,
    public facade: TemplatesFacade,
    public dictionariesFacade: DictionariesFacade,
    private dialogRef: MatDialogRef<ExerciseChoiceDialogComponent>,
    public imgService: ImageService
  ) {
    super();
  }

  ngOnInit(): void {
    this.dictionariesFacade.fetchTargets();
    this.dictionariesFacade.fetchEquipments();
    this.dictionariesFacade.fetchBodyParts();

    this.facade.fetchExercises();

    this.observe(this.form.valueChanges)
      .subscribe(value => this.facade.setExerciseQuery({
        ...value,
        bodyPartId: value.bodyPartId ?? undefined,
        targetId: value.targetId ?? undefined,
        equipmentId: value.equipmentId ?? undefined,
      }));
  }

  override ngOnDestroy() {
    super.ngOnDestroy();

    this.facade.reset();
  }

  selectExercise(exercise: ExerciseDTO): void {
    this.selectedExercise = exercise;
  }

  close(): void {
    this.dialogRef.close(null);
  }

  choose(): void {
    this.dialogRef.close({ index: this.data.index, exercise: this.selectedExercise });
  }
}
