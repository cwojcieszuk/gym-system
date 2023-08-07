import { Component, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { DictionariesFacade } from '../../../../core/dictionaries-state/dictionaries.facade';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss'],
})
export class UserFormComponent implements OnInit {
  readonly form = this.fb.group({
    firstName: this.fb.control<string>('', [Validators.required]),
    lastName: this.fb.control<string>('', [Validators.required]),
    email: this.fb.control<string>('', [Validators.required]),
    role: this.fb.control<string>('', [Validators.required]),
    login: this.fb.control<string>('', Validators.required),
    gender: this.fb.control<string>('', [Validators.required]),
    password: this.fb.control<string>('', [Validators.required]),
    phoneNumber: this.fb.control<string>('', [Validators.required]),
    birthDate: this.fb.control<Date | null>(null, Validators.required),
  });

  constructor(
    private dialogRef: MatDialogRef<UserFormComponent>,
    private fb: NonNullableFormBuilder,
    public dictionariesFacade: DictionariesFacade
  ) {
  }

  ngOnInit(): void {
    this.dictionariesFacade.fetchUserRoles();
  }

  cancel(): void {
    this.dialogRef.close();
  }

  save(): void {
    this.dialogRef.close(this.form.value);
  }
}
