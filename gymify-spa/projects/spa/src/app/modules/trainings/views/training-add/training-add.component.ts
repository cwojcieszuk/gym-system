import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from '../../../../shared/components/base.component';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { UUID } from '../../../../../../../api-client/src/lib/types/uuid.type';
import { TrainingsFacade } from '../../+state/trainings.facade';
import { filter } from 'rxjs';

@Component({
  templateUrl: './training-add.component.html',
  styleUrls: ['./training-add.component.scss'],
})
export class TrainingAddComponent extends BaseComponent implements OnInit {
  readonly form = this.fb.group({
    name: this.fb.control<string>('', Validators.required),
    datetime: this.fb.control<Date | null>(null, Validators.required),
    templateUid: this.fb.control<UUID>('', Validators.required),
  });

  isNew = true;

  constructor(
    private route: ActivatedRoute,
    private fb: NonNullableFormBuilder,
    private facade: TrainingsFacade,
    private router: Router
  ) {
    super();
  }

  ngOnInit(): void {
    this.observe(this.route.paramMap)
      .subscribe(value => {
        const trainingUid = value.get('uid');

        if (trainingUid) {
          this.isNew = false;
          this.facade.selectTraining(trainingUid);
          this.facade.fetchTrainingDetails();
        }
      });

    this.observe(this.facade.trainingDetails$)
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.form.patchValue({
          name: value.trainingName,
          datetime: new Date(value.trainingDate),
          templateUid: value.templateUid,
        });
      });
  }

  moveBack(): void {
    this.router.navigate(['trainings']);
  }

  save(): void {
    if (this.form.invalid) {
      return;
    }

    if (this.isNew) {
      this.facade.createTraining({
        trainingName: this.form.controls.name.value,
        trainingDate: this.form.controls.datetime.value!,
        templateUid: this.form.controls.templateUid.value,
      });
    } else {
      this.facade.updateTraining(this.form.controls.name.value, this.form.controls.datetime.value!, this.form.controls.templateUid.value);
    }
  }
}
