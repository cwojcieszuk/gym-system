import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from '../../../../shared/components/base.component';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { TrainingsFacade } from '../../+state/trainings.facade';
import { debounceTime, filter, startWith } from 'rxjs';
import { TemplateDetailsDTO } from '../../../../../../../api-client/src/lib/clients/templates/models/template.details.dto';
import { ImageService } from '../../../../shared/services/image.service';

@Component({
  templateUrl: './training-add.component.html',
  styleUrls: ['./training-add.component.scss'],
})
export class TrainingAddComponent extends BaseComponent implements OnInit, OnDestroy {
  readonly form = this.fb.group({
    name: this.fb.control<string>('', Validators.required),
    datetime: this.fb.control<Date | null>(null, Validators.required),
    templateSearch: this.fb.control<string>('', Validators.required),
    isCyclical: this.fb.control<boolean>(false, Validators.required),
  });

  isNew = true;
  selectedTemplate?: TemplateDetailsDTO;

  constructor(
    private route: ActivatedRoute,
    private fb: NonNullableFormBuilder,
    public facade: TrainingsFacade,
    private router: Router,
    public imgService: ImageService
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
          templateSearch: value.template.templateName,
          isCyclical: value.isCyclical,
        });

        this.setTemplate(value.template);
      });

    this.observe(this.form.controls.templateSearch.valueChanges)
      .pipe(debounceTime(500), startWith(''))
      .subscribe(value => this.facade.fetchTemplatesBySearch(value));
  }

  override ngOnDestroy(): void {
    super.ngOnDestroy();

    this.facade.reset();
  }

  moveBack(): void {
    this.router.navigate(['trainings']);
  }

  save(): void {
    if (this.form.invalid || !this.selectedTemplate) {
      return;
    }

    if (this.isNew) {
      this.facade.createTraining({
        trainingName: this.form.controls.name.value,
        trainingDate: this.fixDateHour(this.form.controls.datetime.value!),
        templateUid: this.selectedTemplate.templateUid,
        isCyclical: this.form.controls.isCyclical.value,
      });
    } else {
      this.facade.updateTraining(this.form.controls.name.value, this.fixDateHour(this.form.controls.datetime.value!), this.selectedTemplate.templateUid, this.form.controls.isCyclical.value);
    }
  }

  setTemplate(template: TemplateDetailsDTO): void {
    this.selectedTemplate = template;
  }

  private fixDateHour(date: Date): Date {
    date.setHours(date.getHours() + 2, date.getMinutes());

    return date;
  }
}
