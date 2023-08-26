import { Component, Inject, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { DictionariesFacade } from '../../../../core/dictionaries-state/dictionaries.facade';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { User } from '../../../../../../../api-client/src/lib/clients/users/responses/user.model';
import { UUID } from '../../../../../../../api-client/src/lib/types/uuid.type';

@Component({
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss'],
})
export class UserFormComponent implements OnInit {
  readonly form = this.fb.group({
    userUid: this.fb.control<UUID>(''),
    firstName: this.fb.control<string>('', [Validators.required]),
    lastName: this.fb.control<string>('', [Validators.required]),
    email: this.fb.control<string>('', [Validators.required]),
    role: this.fb.control<string>('', [Validators.required]),
    login: this.fb.control<string>('', Validators.required),
    gender: this.fb.control<string>('', [Validators.required]),
    password: this.fb.control<string>(''),
    currentPassword: this.fb.control<string>(''),
    phoneNumber: this.fb.control<string>('', [Validators.required]),
    birthDate: this.fb.control<Date | null>(null, Validators.required),
  });

  isNew: boolean;

  showPassword = false;

  get passwordInputType() {
    return this.showPassword ? 'text' : 'password';
  }

  constructor(
    @Inject(MAT_DIALOG_DATA) data: { isNew: boolean; user?: User },
    private dialogRef: MatDialogRef<UserFormComponent>,
    private fb: NonNullableFormBuilder,
    public dictionariesFacade: DictionariesFacade
  ) {
    this.isNew = data.isNew;

    if (this.isNew) {
      this.form.controls.password.addValidators([Validators.required]);
    }

    if (!this.isNew && data.user) {
      this.form.patchValue({
        userUid: data.user.userUid,
        firstName: data.user.firstName,
        lastName: data.user.lastName,
        email: data.user.email,
        role: data.user.role,
        gender: data.user.gender,
        login: data.user.login,
        phoneNumber: data.user.phoneNumber,
        birthDate: new Date(data.user.birthDate),
      });
    }
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

  togglePasswordVisibility(): void {
    this.showPassword = !this.showPassword;
  }

  generatePassword(): void {
    this.form.controls.password.patchValue(Math.random().toString(36).slice(-8));
  }
}
