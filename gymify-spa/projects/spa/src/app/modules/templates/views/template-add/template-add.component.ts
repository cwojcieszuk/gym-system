import { Component, OnDestroy, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { DictionariesFacade } from '../../../../core/dictionaries-state/dictionaries.facade';
import { BaseComponent } from '../../../../shared/components/base.component';
import { UUID } from '../../../../../../../api-client/src/lib/types/uuid.type';
import { ExerciseDTO } from '../../../../../../../api-client/src/lib/clients/exercises/models/exercise.dto';
import { ImageService } from '../../../../shared/services/image.service';
import { MatDialog } from '@angular/material/dialog';
import { ExerciseChoiceDialogComponent } from '../../components/exercise-choice.dialog/exercise-choice.dialog.component';
import { filter } from 'rxjs';
import { TemplatesFacade } from '../../+state/templates.facade';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: './template-add.component.html',
  styleUrls: ['./template-add.component.scss'],
})
export class TemplateAddComponent extends BaseComponent implements OnInit, OnDestroy {
  readonly form = this.fb.group({
    templateName: this.fb.control<string>('', Validators.required),
    difficultyLevelUid: this.fb.control<UUID | null>(null, Validators.required),
    estimatedTime: this.fb.control<number>(0, Validators.required),
  });

  readonly exercisesForm = this.fb.array([
    this.fb.group({
      exercise: this.fb.control<ExerciseDTO | null>(null),
      numberOfSets: this.fb.control<number>(0),
      numberOfReps: this.fb.control<number>(0),
      comments: this.fb.control<string>(''),
    }),
  ]);

  isShared = false;
  difficultyLevel = '';
  templateUid?: UUID;

  exerciseControl(index: number): ExerciseDTO | null {
    return this.exercisesForm.at(index).controls.exercise.value;
  }

  get canSave(): boolean {
    return this.form.valid && this.exercisesForm.controls.every(c => c.controls.exercise.value !== null);
  }

  constructor(
    private fb: NonNullableFormBuilder,
    public dictionariesFacade: DictionariesFacade,
    public imgService: ImageService,
    private dialog: MatDialog,
    private facade: TemplatesFacade,
    private router: Router,
    private route: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    this.dictionariesFacade.fetchDifficultyLevels();
    //this.facade.fetchTemplate();

    this.observe(this.route.paramMap)
      .subscribe(value => {
        const uid = value.get('uid');

        if (uid) {
          this.templateUid = uid;
          this.facade.selectTemplate(uid);
          this.facade.fetchTemplate();
        }
      });

    this.observe(this.facade.template$)
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.form.patchValue({
          templateName: value.templateName,
          difficultyLevelUid: value.difficultyLevelUid,
          estimatedTime: value.estimatedTime,
        }, { emitEvent: false });

        this.exercisesForm.removeAt(0);

        value.exercises.forEach(ex => {
          this.exercisesForm.push(this.fb.group({ exercise: ex.exercise, numberOfReps: ex.numberOfReps, numberOfSets: ex.numberOfSets, comments: ex.comments ?? '' }), { emitEvent: false });
        });

        this.isShared = value.isShared;
        this.difficultyLevel = value.difficultyLevelName;
      });
  }

  override ngOnDestroy(): void {
    super.ngOnDestroy();

    this.facade.reset();
  }

  goBack(): void {
    this.router.navigate(['..'], { relativeTo: this.route });
  }

  addExercise(): void {
    this.exercisesForm.push(this.fb.group({
      exercise: this.fb.control<ExerciseDTO | null>(null),
      numberOfSets: this.fb.control<number>(0),
      numberOfReps: this.fb.control<number>(0),
      comments: this.fb.control<string>(''),
    }));
  }

  removeExercise(index: number): void {
    this.exercisesForm.removeAt(index);
  }

  chooseExercise(index: number): void {
    const dialog = this.dialog.open(ExerciseChoiceDialogComponent, {
      width: '900px',
      height: '800px',
      data: {
        index,
      },
    });

    dialog.afterClosed()
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.exercisesForm.at(value.index).patchValue({
          exercise: value.exercise,
        });
      });
  }

  save(): void {
    if (!this.canSave) {
      return;
    }

    if (this.templateUid) {
      this.facade.updateTemplate({ templateUid: this.templateUid, ...this.getTemplateParams() });
    } else {
      this.facade.createTemplate(this.getTemplateParams());
    }
  }

  // eslint-disable-next-line @typescript-eslint/explicit-function-return-type
  private getTemplateParams() {
    return {
      templateName: this.form.controls.templateName.value,
      estimatedTime: this.form.controls.estimatedTime.value,
      difficultyLevelUid: this.form.controls.difficultyLevelUid.value as string,
      exercises: this.exercisesForm.controls.map(x => ({
        exerciseUid: x.controls.exercise.value?.exerciseUid as string,
        numberOfReps: x.controls.numberOfReps.value,
        numberOfSets: x.controls.numberOfSets.value,
        comments: x.controls.comments.value,
      }))
    }
  }
}
