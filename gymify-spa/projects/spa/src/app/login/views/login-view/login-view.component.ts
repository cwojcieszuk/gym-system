import { Component } from '@angular/core';
import { NonNullableFormBuilder } from '@angular/forms';

@Component({
  selector: 'gym-login-view',
  templateUrl: './login-view.component.html',
  styleUrls: ['./login-view.component.scss'],
})
export class LoginViewComponent {
  readonly form = this.fb.group({
    login: this.fb.control<string>(''),
    password: this.fb.control<string>(''),
  });

  constructor(
    private fb: NonNullableFormBuilder
  ) {
  }
}
