import { Component } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { DictionariesFacade } from '../../../../core/dictionaries-state/dictionaries.facade';
import { CreateGroupSessionParams } from '../../../../../../../api-client/src/lib/clients/group-sessions/params/create-group-session.params';
import { dateValidator } from '../../../../shared/validators/date.validator';

@Component({
  templateUrl: './create-session.component.html',
  styleUrls: ['./create-session.component.scss'],
})
export class CreateSessionComponent {
  readonly form = this.fb.group({
    name: this.fb.control<string>('', [Validators.required, Validators.maxLength(128)]),
    startDate: this.fb.control<Date | null>(null, Validators.required),
    endDate: this.fb.control<Date | null>(null, Validators.required),
    slots: this.fb.control<number | null>(null, [Validators.required, Validators.min(1)]),
    placeId: this.fb.control<number | null>(null, Validators.required),
    description: this.fb.control<string>('', [Validators.required, Validators.maxLength(300)]),
  }, { validators: [dateValidator] });

  constructor(
    private fb: NonNullableFormBuilder,
    private dialogRef: MatDialogRef<CreateSessionComponent>,
    public dictionariesFacade: DictionariesFacade
  ) {
    this.dictionariesFacade.fetchPlaces();
  }

  cancel(): void {
    this.dialogRef.close();
  }

  save(): void {
    if (this.form.invalid) {
      return;
    }

    this.dialogRef.close({
      sessionName: this.form.value.name,
      placeId: this.form.value.placeId,
      sessionStartDate: this.form.value.startDate,
      sessionEndDate: this.form.value.endDate,
      description: this.form.value.description,
      slots: Number(this.form.value.slots),
    } as CreateGroupSessionParams);
  }
}
