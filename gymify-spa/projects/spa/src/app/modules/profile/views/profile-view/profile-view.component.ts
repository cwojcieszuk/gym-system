import { Component, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { ProfileFacade } from '../../+state/profile.facade';
import { BaseComponent } from '../../../../shared/components/base.component';
import { filter } from 'rxjs';

@Component({
  selector: 'gym-profile-view',
  templateUrl: './profile-view.component.html',
  styleUrls: ['./profile-view.component.scss'],
})
export class ProfileViewComponent extends BaseComponent implements OnInit {
  readonly form = this.fb.group({
    firstName: this.fb.control<string>('', Validators.required),
    lastName: this.fb.control<string>('', Validators.required),
    birthDate: this.fb.control<Date | null>(null, Validators.required),
    email: this.fb.control<string>('', Validators.required),
    login: this.fb.control<string>('', Validators.required),
    password: this.fb.control<string>(''),
    newPassword: this.fb.control<string>(''),
    confirmPassword: this.fb.control<string>(''),
  });

  constructor(
    private fb: NonNullableFormBuilder,
    public profileFacade: ProfileFacade
  ) {
    super();
  }

  ngOnInit(): void {
    this.profileFacade.fetchUserData();

    this.observe(this.profileFacade.user$)
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.form.patchValue({
          firstName: value.firstName,
          lastName: value.lastName,
          login: value.login,
          email: value.email,
          birthDate: value.birthDate,
        });
      });
  }

  save(): void {
    this.profileFacade.updateUserData({
      firstName: this.form.controls.firstName.value,
      lastName: this.form.controls.lastName.value,
      login: this.form.controls.login.value,
      email: this.form.controls.email.value,
      birthDate: this.form.controls.birthDate.value!,
    });
  }

  updateUserPassword(): void {
    this.profileFacade.updateUserPassword({
      password: this.form.controls.password.value,
      newPassword: this.form.controls.newPassword.value,
      confirmPassword: this.form.controls.confirmPassword.value,
    });
  }
}
