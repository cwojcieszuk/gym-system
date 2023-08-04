import { Component } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { AuthFacade } from '../../../auth/+state/auth.facade';

@Component({
  selector: 'gym-login-view',
  templateUrl: './login-view.component.html',
  styleUrls: ['./login-view.component.scss'],
})
export class LoginViewComponent {
  readonly form = this.fb.group({
    email: this.fb.control<string>('', Validators.required),
    password: this.fb.control<string>('', Validators.required),
  });

  constructor(
    private fb: NonNullableFormBuilder,
    public facade: AuthFacade
  ) {
  }

  submit(): void {
    if (this.form.invalid) {
      for (const control in this.form.controls) {
        this.form.get(control)?.markAsDirty();
      }

      this.form.markAsTouched();

      return;
    }

    this.facade.login(this.form.getRawValue());
  }
}
